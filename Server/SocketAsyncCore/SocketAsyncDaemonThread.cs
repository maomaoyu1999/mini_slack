﻿using System;
using System.Threading;
using System.Net.Sockets;


namespace Server.SocketAsyncCore
{
    class SocketAsyncDaemonThread : object
    {
        private Thread m_thread;
        private SocketAsyncTcpServer m_asyncSocketServer;

        public SocketAsyncDaemonThread(SocketAsyncTcpServer asyncSocketServer)
        {
            m_asyncSocketServer = asyncSocketServer;
            m_thread = new Thread(DaemonThreadStart);
            m_thread.Start();
        }

        public void DaemonThreadStart()
        {
            while (m_thread.IsAlive)
            {
                SocketAsyncEventArgs[] userTokenArray = null;
                m_asyncSocketServer.SocketUserTokenList.CopyList(ref userTokenArray);
                for (int i = 0; i < userTokenArray.Length; i++)
                {
                    if (!m_thread.IsAlive)
                        break;
                    try
                    {
                        AsyncUserToken userToke = userTokenArray[i].UserToken as AsyncUserToken;
                        if (userToke.Socket != null && userToke.Socket.Connected && (DateTime.Now - userToke.ActiveDateTime).Milliseconds > m_asyncSocketServer.SocketTimeOutMS) //超时Socket断开
                        //if ((DateTime.Now - userToke.ActiveDateTime).Milliseconds > m_asyncSocketServer.SocketTimeOutMS) //超时Socket断开
                        {
                            lock (userTokenArray[i])
                            {
                                m_asyncSocketServer.CloseClientSocket(userTokenArray[i]);
                            }
                        }
                    }
                    catch (Exception E)
                    {
                        Log4Debug(string.Format("Daemon thread check timeout socket error, message: {0}", E.Message));
                        Log4Debug(E.StackTrace);
                    }
                }

                for (int i = 0; i < 60 * 1000 / 10; i++) //每分钟检测一次
                {
                    if (!m_thread.IsAlive)
                        break;
                    Thread.Sleep(10);
                }
            }
        }

        public void Close()
        {
            m_thread.Abort();
            m_thread.Join();
        }

        public void Log4Debug(string msg)
        {
            Console.WriteLine("notice:" + msg);
        }
    }
}
