using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Hesint.Lib.Security
{
    public static class SHA
    {
        /// <summary>
        /// 获取SHA512加密后的值
        /// </summary>
        /// <param name="source">待加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string SHA512(string source)
        {
            byte[] data = Encoding.UTF8.GetBytes(source);
            SHA512 shaM = new SHA512Managed();
            byte[] result = shaM.ComputeHash(data);
            StringBuilder EnText = new StringBuilder();
            foreach (byte iByte in result)
            {
                EnText.AppendFormat("{0:x2}", iByte);
            }
            return EnText.ToString();
        }
    }
}
