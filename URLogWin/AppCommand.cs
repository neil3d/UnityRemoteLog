using System.Text;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace URLogWin
{
    public static class LogType
    {
        public const string Error= "Error";
        public const string Assert= "Assert";
        public const string Exception= "Exception";
        public const string Warning= "Warning";
        public const string Log= "Log";
    }

    public enum ENetEvent
    {
        Connected,
        Disconnected,
        Start,
        Log,
    }

    public class LogItem
    {
        public string log;
        public string stack;
        public string type;

        public void ConvertBase64()
        {
            log =  System.Text.Encoding.UTF8.GetString(
                System.Convert.FromBase64String(log)
                    );
            stack = System.Text.Encoding.UTF8.GetString(
                System.Convert.FromBase64String(stack)
                    );
            type = System.Text.Encoding.UTF8.GetString(
                System.Convert.FromBase64String(type)
                    );
        }

        public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this.type != LogType.Exception)
                sb.AppendFormat("{0}: {1}", this.type, this.log);
            else
                sb.Append(this.log);
            sb.AppendLine();
            sb.AppendLine(this.stack);
            return sb.ToString();
        }
    }

    public class NetEvent
    {
        public ENetEvent evt;
        public string data;
        public LogItem log;

        public NetEvent(ENetEvent e, string d)
        {
            evt = e;
            data = d;
        }
    }

    public class CMD_START : CommandBase<AppSession, StringRequestInfo>
    {
        public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)
        {
            MainForm.NetEventQueue.Enqueue(
                new NetEvent(ENetEvent.Start, requestInfo.Body)
                );
        }
    }

    public class CMD_LOG : CommandBase<AppSession, StringRequestInfo>
    {
        public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)
        {
            NetEvent evt = new NetEvent(ENetEvent.Log, requestInfo.Body);
            evt.data = requestInfo.Body;
            try
            {
                LogItem log = Newtonsoft.Json.JsonConvert.DeserializeObject<LogItem>(requestInfo.Body);
                if (log != null)
                    log.ConvertBase64();
                evt.log = log;
            }
            catch (System.Exception ex)
            { 
            }
            
            MainForm.NetEventQueue.Enqueue(evt);
        }
    }

}
