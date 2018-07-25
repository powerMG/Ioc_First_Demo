using System;
using System.Collections.Generic;
using System.Text;

namespace Hesint.Lib.Server
{
    /// <summary>
    /// 系统帮助类
    /// </summary>
    public static class SystemHelper
    {
        /// <summary>
        /// 获取应用程序根目录
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetRootPath(string path)
        {
            return Environment.CurrentDirectory;
        }
    }
}
