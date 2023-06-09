﻿using System;
using System.Net.Sockets;

namespace Server.SocketAsyncCore
{
    //这个类是将UserToken进行了再次封装，MSDN对于异步Socket的介绍中总会提到：  
    //若在异步回调中需要查询更多的信息，则应该建立一个小型类来管理回调时传递的Object对象  
    //UserToken其实就是那个传递的参数，AsyncUserToken就是对UserToken的封装，建立的小型类  

    public class AsyncUserToken
    {
        private Socket socket = null;
        public Socket Socket
        {
            get { return socket; }
            set { socket = value; }
        }

        public string RsaPrivateKey { get; set; }

        public string RsaPublicKey { get; set; }

        public byte[] AesKey { get; set; }

        public byte[] AesIV { get; set; }

        public SocketAsyncRingBuffer Rb { get; private set; }

        public string GUID { get; set; }

        protected DateTime m_ActiveDateTime;

        public DateTime ActiveDateTime { get { return m_ActiveDateTime; } set { m_ActiveDateTime = value; } }

        protected DateTime m_ConnectDateTime;
        public DateTime ConnectDateTime { get { return m_ConnectDateTime; } set { m_ConnectDateTime = value; } }
        public void SetRingBuffer(int size = 2048)
        {
            Rb = new SocketAsyncRingBuffer(size);
        }
    }
}
