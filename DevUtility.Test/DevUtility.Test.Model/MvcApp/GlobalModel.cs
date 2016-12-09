using Fleck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Model.MvcApp
{
    public class GlobalModel
    {
        #region Variables

        volatile static GlobalModel instance = null;

        static readonly object locker = new object();

        bool isStarted { set; get; }

        WebSocketServer webSocketServer { set; get; }

        List<IWebSocketConnection> socketConnectionList { set; get; }

        #endregion

        #region Properties

        public static GlobalModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new GlobalModel();
                            instance.isStarted = false;
                        }
                    }
                }

                return instance;
            }
        }

        #endregion

        #region Constructor

        public GlobalModel()
        {
            isStarted = false;
        }

        #endregion

        #region Start

        public bool Start()
        {
            if (isStarted)
            {
                return false;
            }

            socketConnectionList = new List<IWebSocketConnection>();
            webSocketServer = new WebSocketServer("ws://0.0.0.0:8181");

            webSocketServer.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    socketConnectionList.Add(socket);
                };
                socket.OnClose = () =>
                {
                    socketConnectionList.Remove(socket);
                };
                socket.OnMessage = message =>
                {
                    socketConnectionList.ToList().ForEach(s => s.Send("Echo: " + message));
                };
            });

            isStarted = true;
            return true;
        }

        #endregion

        #region Stop

        public void Stop()
        {
            socketConnectionList.ToList().ForEach(s =>
            {
                s.Send("Stop!");
                s.Close();
            });

            socketConnectionList.Clear();
            webSocketServer.Dispose();
            isStarted = false;
        }

        #endregion
    }
}