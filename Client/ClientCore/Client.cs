﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net.WebSockets;
using System.Threading;
using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading.Tasks;

using Client.Encryption;
using Client.FileHandler;
using Client.Commons;


namespace Client.ClientCore
{
    public class Client
    {
        //private readonly Dictionary<string, object> jsonData = JsonFileHandler.LoadJsonObjFromFile(@"UserData.json");
        private const string UserFileName = @"UserData.json";
        private Dictionary<string, object> jsonData = new Dictionary<string, object>() { };

        public Client(string ip, int port)
        {
        }

        //public async Task<bool> Register(string username, string password)
        //{
        //    return await PerfromRegister(username, password);
        //}

        ////private async Task<bool> PerfromRegister(string username, string password)
        ////{
        ////}

        //public async Task<bool> CheckLogin()
        //{
        //    if (!File.Exists(UserFileName))
        //    {
        //        return false;
        //    }
        //    string UserDataStr = File.ReadAllText(UserFileName);
        //    Dictionary<string, string> UserDataDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(UserDataStr);
        //    string username = UserDataDict["username"];
        //    string password = UserDataDict["password"];
        //    bool res = await PerformLogin(username, password);
        //    return res;
        //}

        //public async Task<bool> Login(string username, string password)
        //{
        //    return await PerformLogin(username, password);
        //}

        /// <summary>
        /// Perform login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        //private async Task<bool> PerformLogin(string username, string password)
        //{
        //    Request request = new Request("login", username, password);
        //    string jsonStr = request.GetJsonStr();
        //    try
        //    {
        //        // 发送登录消息
        //        await TcpSendStr(jsonStr);

        //        // 接受登录验证响应
        //        string recv = await TcpRecvStr();

        //        // 解析响应
        //        Response response = new Response(recv);
        //        Dictionary<string, string> jsonDict = response.Get();
        //        bool getActionRes = jsonDict.TryGetValue("action", out string action);
        //        if (getActionRes == false)
        //        {
        //            return false;
        //        }
        //        if (action.Equals("login") == false)
        //        {
        //            return false;
        //        }
        //        if (!jsonDict.TryGetValue("result", out string getResultRes))
        //        {
        //            return false;
        //        }
        //        Console.WriteLine(jsonDict["msg"]);
        //        return bool.Parse(getResultRes);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Login error..." + e.Message);
        //    }
        //    return false;
        //}

        public void ActionHandler(Dictionary<string, string> jsonDict)
        {
            throw new NotImplementedException();
        }




        //public Response SendMsg(string username, string msg)
        //{
        //}
        //public Response AddFriend()
        //{
        //}
        //public Response GetFriendList()
        //{
        //}
        //public Response DelFriend()
        //{
        //}
        //public Response JoinGroup()
        //{
        //}
        //public Response LeaveGroup()
        //{
        //}

    }
}