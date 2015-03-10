using UnityEngine;
using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Collections.Generic;

/// <summary>
/// 将Unity的Log发送到一台PC机的UnityRemoteLogWindow程序上
/// </summary>
public class RemoteLog
{
    struct LogItem
    {
        public string log;
        public string stack;
        public LogType type;

        public string ToJsonString()
        {

            StringBuilder sb = new StringBuilder();
            sb.Append('{');
            sb.Append("\"log\":");
            sb.AppendFormat("\"{0}\",", Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(log)));
            sb.Append("\"stack\":");
            sb.AppendFormat("\"{0}\",", Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(stack)));
            sb.Append("\"type\":");
            sb.AppendFormat("\"{0}\"", Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(type.ToString())));
            sb.Append('}');
            return sb.ToString();
        }
    }

    static RemoteLog s_instance = new RemoteLog();
    List<LogItem> m_logList = new List<LogItem>();
    string m_app;

    Socket m_socket;
    int m_connect;
    int m_sending;
    string m_host;
    int m_port;

    public static RemoteLog Instance
    {
        get { return s_instance; }
    }
    /// <summary>
    /// 调用此函数启动RemoteLog
    /// </summary>
    public void Start(string host, int port)
    {
        m_host = host;
        m_port = port;

        m_sending = 0;
        m_connect = 0;
        m_app = Application.platform.ToString();

        ConnectHost();

        //--
        Application.RegisterLogCallback(this.UnityLogHandler);
    }

    void ConnectHost()
    {
        if (m_connect == 1  // connected
            || m_connect == 2)
            return;
        try
        {
            Interlocked.Exchange(ref m_connect, 2); // connecting

            // 发起异步连接操作
            IPEndPoint point = new IPEndPoint(IPAddress.Parse(m_host), m_port);
            m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            m_socket.NoDelay = true;
            m_socket.BeginConnect(point,
                new AsyncCallback(this.ConnectCallback),
                null);
        }
        catch (System.Exception exp)
        {
            Debug.LogWarning("RemoteLog网络错误：" + exp.Message);
        }
    }

    /// <summary>
    /// Socket异步Connect回调
    /// </summary>
    void ConnectCallback(IAsyncResult ar)
    {
        try
        {
            m_socket.EndConnect(ar);
            Interlocked.Exchange(ref m_connect, 1);

            //--发送启动LOG
            string startLog = string.Format("CMD_START {0}\r\n", m_app);
            SendLog(startLog);

        }
        catch (System.Exception exp)
        {
            Interlocked.Exchange(ref m_connect, 0);
            Debug.LogWarning("RemoteLog网络错误：" + exp.Message);
        }
    }

    bool SendLog(string log)
    {
        if (m_connect == 2)
            return false;
        if (m_connect == 0)
        {
            ConnectHost();
            return false;
        }
        if (string.IsNullOrEmpty(log))
            return true;

        // 发送到Socket
        try
        {
            Interlocked.Exchange(ref m_sending, 1);
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(log);
            m_socket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None,
                new AsyncCallback(this.SendCallback), null);
            return true;
        }
        catch (Exception exp)
        {
            Disconnect();
            Debug.LogWarning("RemoteLog网络错误：" + exp.Message);
            return false;
        }
    }

    bool SendLog(LogItem log)
    {
        string jsonStr = log.ToJsonString();
        return SendLog(
            string.Format("CMD_LOG {0}\r\n", jsonStr)
            );
    }

    /// <summary>
    /// 发送请求的异步回调
    /// </summary>
    void SendCallback(IAsyncResult ar)
    {
        Interlocked.Exchange(ref m_sending, 0);
        try
        {
            int bytes = m_socket.EndSend(ar);
            if (bytes <= 0)
            {
                Disconnect();
                Debug.LogWarning("RemoteLog网络连接已经断开。");
            }
            else
            {
                //-- 发送剩余的Log
                lock (m_logList)
                {
                    if (m_logList.Count > 0)
                    {
                        LogItem log = m_logList[0];
                        if (SendLog(log))
                            m_logList.RemoveAt(0);
                    }
                    else
                    {
                        Interlocked.Exchange(ref m_sending, 0);
                    }
                }
            }

        }
        catch (Exception exp)
        {
            Interlocked.Exchange(ref m_connect, 0);
            Debug.LogWarning("RemoteLog网络错误：" + exp.Message);
        }
    }

    /// <summary>
    /// 停用
    /// </summary>
    public void Disconnect()
    {
        if (m_connect != 0)
        {
            m_socket.Shutdown(SocketShutdown.Both);
            m_socket.Close();
            Interlocked.Exchange(ref m_connect, 0);
        }
    }

    /// <summary>
    /// Unity Engine callback
    /// </summary>
    void UnityLogHandler(string logString, string stackTrace, LogType type)
    {
        lock (m_logList)
        {
            LogItem newItem = new LogItem();
            newItem.log = logString;
            newItem.stack = stackTrace;
            newItem.type = type;

            if (m_sending == 0)
            {
                if (!SendLog(newItem))
                    m_logList.Add(newItem);
            }
            else
            {
                m_logList.Add(newItem);
            }
        }
    }
}
