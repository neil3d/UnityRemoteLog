using System.IO;
using System.Text;
using System.Drawing;
using SuperSocket.SocketBase;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace URLogWin
{
    /// <summary>
    /// 主窗体
    /// </summary>
    public partial class MainForm : Form
    {
        public static ConcurrentQueue<NetEvent> NetEventQueue = new ConcurrentQueue<NetEvent>();

        bool m_showLog;
        bool m_showWarning;
        bool m_showError;
        List<LogItem> m_logList = new List<LogItem>();

        public MainForm()
        {
            InitializeComponent();

            //--
            m_showLog = true;
            m_showWarning = true;
            m_showError = true;
            this.splitContainer.Visible = false;
        }

        /// <summary>
        /// Unity客户端连接
        /// </summary>
        public void appServerNewSessionConnected(AppSession session)
        {
            NetEventQueue.Enqueue(
                new NetEvent(ENetEvent.Connected, "")
                );
        }


        /// <summary>
        /// Unity客户端连接断开
        /// </summary>
        public void appServerSessionClosed(AppSession session, SuperSocket.SocketBase.CloseReason value)
        {
            NetEventQueue.Enqueue(
                new NetEvent(ENetEvent.Disconnected, "")
                );
        }

        /// <summary>
        /// 主线程事件驱动Timer相应
        /// </summary>
        private void eventTickTimer_Tick(object sender, System.EventArgs e)
        {
            NetEvent evt = null;
            while (!NetEventQueue.IsEmpty && NetEventQueue.TryDequeue(out evt))
            {
                switch (evt.evt)
                {
                    case ENetEvent.Connected:
                        this.pictureBoxLog.Visible = false;
                        this.labelTips.Visible = false;
                        this.splitContainer.Visible = true;
                        this.lbStatus.Text = "Connected";
                        break;
                    case ENetEvent.Disconnected:
                        this.lbStatus.Text = "Disonnected";
                        break;
                    case ENetEvent.Start:
                        this.lbStatus.Text = "App Start";
                        this.pictureBoxLog.Visible = false;
                        this.labelTips.Visible = false;
                        this.splitContainer.Visible = true;
                        break;
                    case ENetEvent.Log:
                        this.lbStatus.Text = "Log";
                        if (evt.log != null)
                        {
                            ShowLog(evt.log);
                            m_logList.Add(evt.log);
                        }
                        else
                        {
                            ListViewItem view = this.listViewLog.Items.Add("", 0);
                            view.SubItems.Add(evt.data);
                        }
                        this.pictureBoxLog.Visible = false;
                        this.labelTips.Visible = false;
                        this.splitContainer.Visible = true;
                        break;
                    default:
                        this.lbStatus.Text = "Unknown Net Event";
                        break;
                }// end of switch
            }// end of while
        }

        /// <summary>
        /// 在ListView插入一项Log
        /// </summary>
        void ShowLog(LogItem log)
        {
            if (!FilterLog(log))
                return;
            int imgIndex = 0;
            Color clr = Color.Black;
            switch (log.type)
            {
                case LogType.Error:
                case LogType.Exception:
                case LogType.Assert:
                    imgIndex = 2;
                    clr = Color.Red;
                    break;
                case LogType.Warning:
                    imgIndex = 1;
                    clr = Color.Yellow;
                    break;
                case LogType.Log:
                    imgIndex = 0;
                    clr = Color.Black;
                    break;
            }

            ListViewItem view = this.listViewLog.Items.Insert(0, string.Empty, imgIndex);
            view.SubItems.Add(log.log);
            view.ForeColor = clr;
            view.Tag = log;
        }


        /// <summary>
        /// 工具栏“清空”按钮相应
        /// </summary>
        private void btnClear_Click(object sender, System.EventArgs e)
        {
            this.listViewLog.Items.Clear();
            this.m_logList.Clear();
            this.textBoxDetail.Text = string.Empty;
        }

        private void checkBtnInfo_CheckedChanged(object sender, System.EventArgs e)
        {
            m_showLog = this.checkBtnInfo.Checked;
            this.RefreshLogList();
        }

        private void checkBtnWarning_CheckedChanged(object sender, System.EventArgs e)
        {
            m_showWarning = this.checkBtnWarning.Checked;
            this.RefreshLogList();
        }

        private void checkBtnError_CheckedChanged(object sender, System.EventArgs e)
        {
            m_showError = this.checkBtnError.Checked;
            this.RefreshLogList();
        }

        private void MainForm_SizeChanged(object sender, System.EventArgs e)
        {
            this.columnHeader1.Width = 24;
            this.columnHeader2.Width = this.ClientSize.Width - 24 - 32;
        }

        /// <summary>
        /// 选中一项Log之后，显示详细信息
        /// </summary>
        private void listViewLog_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var selItems = this.listViewLog.SelectedItems;
            if (selItems.Count >= 1)
            {
                ListViewItem item = selItems[0];
                LogItem log = item.Tag as LogItem;
                if (log != null)
                {
                    this.textBoxDetail.Text = log.ToString();
                }
            }
        }

        /// <summary>
        /// 使用过滤器，刷新Log列表内容
        /// </summary>
        void RefreshLogList()
        {
            this.listViewLog.BeginUpdate();
            this.listViewLog.Items.Clear();
            foreach (LogItem log in m_logList)
            {
                ShowLog(log);
            }
            this.listViewLog.EndUpdate();
        }

        /// <summary>
        /// 过滤：列表项是否可见
        /// </summary>
        bool FilterLog(LogItem log)
        {
            bool viz = true;
            switch (log.type)
            {
                case LogType.Error:
                case LogType.Assert:
                case LogType.Exception:
                    viz = m_showError;
                    break;
                case LogType.Warning:
                    viz = m_showWarning;
                    break;
                case LogType.Log:
                    viz = m_showLog;
                    break;
            }
            return viz;
        }

        /// <summary>
        /// 保存日志到文件
        /// </summary>
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            dlg.FilterIndex = 2;
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string path = dlg.FileName;
                using (StreamWriter writer = File.CreateText(path))
                {
                    foreach(LogItem log in m_logList)
                    {
                        writer.WriteLine(log.ToString());
                    }
                    writer.Close();
                }
                this.lbStatus.Text = "Log Saved to " + path;
            }
        }

        /// <summary>
        /// 打开Help/Option窗口
        /// </summary>
        private void btnHelp_Click(object sender, System.EventArgs e)
        {
            OptionsDlg dlg = new OptionsDlg();
            dlg.ShowDialog(this);
        }

    }
}
