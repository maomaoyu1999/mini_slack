﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Linq;

namespace Server.Encryption
{
    public static class AesEncrypter
    {

        private static readonly int AESKeyLength = 32;          //AES加密的密码为32位
        private static readonly char AESFillChar = 'Z';         //AES密码填充字符

        public static string DefaultPassword = "123456abc";     //Default password


        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="str">要加密的 string 字符串</param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Encrypt(string str, string key)
        {
            try
            {
                ///Format Key to AESKeyLength
                key = FmtPassword(key);
                byte[] keyArray = Encoding.UTF8.GetBytes(key);
                byte[] toEncryptArray = Encoding.UTF8.GetBytes(str);

                RijndaelManaged rDel = new RijndaelManaged
                {
                    Key = keyArray,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };

                ICryptoTransform cTransform = rDel.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch { }
            return str;
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="array">要加密的 byte[] 数组</param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static byte[] Encrypt(byte[] array, string key)
        {
            try
            {
                key = FmtPassword(key);
                byte[] keyArray = Encoding.UTF8.GetBytes(key);

                RijndaelManaged rDel = new RijndaelManaged();
                rDel.Key = keyArray;
                rDel.Mode = CipherMode.ECB;
                rDel.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = rDel.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(array, 0, array.Length);

                return resultArray;
            }
            catch { }
            return array;
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="str">要解密的 string 字符串</param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Decrypt(string str, string key)
        {
            try
            {
                key = FmtPassword(key);
                byte[] keyArray = Encoding.UTF8.GetBytes(key);
                byte[] toEncryptArray = Convert.FromBase64String(str);

                RijndaelManaged rDel = new RijndaelManaged();
                rDel.Key = keyArray;
                rDel.Mode = CipherMode.ECB;
                rDel.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = rDel.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                return Encoding.UTF8.GetString(resultArray);
            }
            catch { }
            return str;
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="array">要解密的 byte[] 数组</param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static byte[] Decrypt(byte[] array, string key)
        {
            try
            {
                key = FmtPassword(key);
                byte[] keyArray = Encoding.UTF8.GetBytes(key);

                RijndaelManaged rDel = new RijndaelManaged
                {
                    Key = keyArray,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };

                ICryptoTransform cTransform = rDel.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(array, 0, array.Length);

                return resultArray;
            }
            catch { }
            return array;
        }

        /// <summary>
        /// 格式化密码
        /// </summary>
        /// <param name="s">要格式化的密码</param>
        /// <returns></returns>
        public static string FmtPassword(string s)
        {
            string password = s ?? "";

            //格式化密码
            if (password.Length < AESKeyLength)
            {
                //补足不够长的密码
                password = password + new string(AESFillChar, AESKeyLength - password.Length);
            }
            else if (password.Length > AESKeyLength)
            {
                //截取过长的密码
                password = password.Substring(0, AESKeyLength);
            }
            return password;
        }
    }
}

