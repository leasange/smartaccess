using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SmartAccess.Common.EncDec
{
    /// <summary>
    /// 加密解密类
    /// </summary>
    public class EncDecClass
    {
        private static byte[] GetKey(string strKey)
        {
            byte[] key = new byte[32];
            for (int i = 0; i < key.Length; i++)
            {
                key[i] = 0;
            }
            if (strKey.Length > 32)
            {
                strKey = strKey.Substring(0, 32);
            }
            byte[] sss = Encoding.UTF8.GetBytes(strKey);
            sss.CopyTo(key, 0);
            return key;
        }
        private static byte[] GetIV(byte[] iv)
        {
            byte[] key = new byte[16];
            for (int i = 0; i < key.Length; i++)
            {
                if (i<iv.Length)
                {
                    key[i] = iv[i];
                }
                else
                {
                    key[i] = 0;
                }
            }
            
            return key;
        }
        /// AES加密
        /// </summary>
        /// <param name="inputdata">输入的数据</param>
        /// <param name="iv">向量128位</param>
        /// <param name="strKey">加密密钥</param>
        /// <returns></returns>
        public static byte[] AESEncrypt(byte[] inputdata, byte[] iv, string strKey)
        {
            //分组加密算法   
            SymmetricAlgorithm des = Rijndael.Create();
            byte[] inputByteArray = inputdata;//得到需要加密的字节数组       
            //设置密钥及密钥向量
            des.Key = GetKey(strKey);
            des.IV = GetIV(iv);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    byte[] cipherBytes = ms.ToArray();//得到加密后的字节数组   
                    cs.Close();
                    ms.Close();
                    return cipherBytes;
                }
            }
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="inputdata">输入的数据</param>
        /// <param name="iv">向量128</param>
        /// <param name="strKey">key</param>
        /// <returns></returns>
        public static byte[] AESDecrypt(byte[] inputdata, byte[] iv, string strKey)
        {
            SymmetricAlgorithm des = Rijndael.Create();
            des.Key = GetKey(strKey);
            des.IV = GetIV(iv);
            byte[] decryptBytes = new byte[inputdata.Length];
            using (MemoryStream ms = new MemoryStream(inputdata))
            {
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    cs.Read(decryptBytes, 0, decryptBytes.Length);
                    cs.Close();
                    ms.Close();
                }
            }
            return decryptBytes;
        }

        public static string AESEncryptRetBase64(byte[] inputdata, byte[] iv, string strKey)
        {
            byte[] enc = AESEncrypt(inputdata, iv, strKey);
            string base64= Convert.ToBase64String(enc);
            return base64;
        }
        public static byte[] AESDecryptInBase64(string inputbase64, byte[] iv, string strKey)
        {
            byte[] enc = Convert.FromBase64String(inputbase64);
            enc = AESDecrypt(enc, iv, strKey);
            return enc;
        }
    }
}
