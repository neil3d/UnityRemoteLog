using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using System;
using System.Windows.Forms;

namespace URLogWin
{
    static class Program
    {
        static AppServer appServer;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //-- 启动一个服务器
            appServer = new AppServer();

            var serverConfig = new ServerConfig
            {
                Port = 2010, //set the listening port
                TextEncoding = "UTF-8",
            };

            //Setup the appServer
            if (!appServer.Setup(serverConfig))
            {
                System.Diagnostics.Debug.Write("创建App Server失败");
            }

            //Try to start the appServer
            if (!appServer.Start())
            {
                System.Diagnostics.Debug.Write("启动App Server失败");
            }

            var mainFrm = new MainForm();
            appServer.NewSessionConnected += mainFrm.appServerNewSessionConnected;
            appServer.SessionClosed += mainFrm.appServerSessionClosed;
            Application.Run(mainFrm);

            //Stop the appServer
            appServer.Stop();
        }

    }
}
