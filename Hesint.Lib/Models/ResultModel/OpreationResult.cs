using System;
using System.Collections.Generic;
using System.Text;

namespace Hesint.Lib.Models.ResultModel
{
    public class OpreationResult<T> : OpreationResult where T : class
    {
        internal OpreationResult()
        {
        }
        /// <summary>
        /// 返回的操作数据
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 初始化一个结果类
        /// </summary>
        /// <param name="type">操作类型</param>
        /// <param name="data">返回的对象</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作结果</returns>
        public static OpreationResult<T> Init(OpreationResuleType type, T data, string message = "操作成功")
        {
            return new OpreationResult<T>() { Data = data, Message = message, ResuleType = type };
        }
    }

    public class OpreationResult
    {
        /// <summary>
        /// 只能使用Init初始化
        /// </summary>
        internal OpreationResult()
        {

        }
        /// <summary>
        /// 操作结果描述信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 返回的操作结果类型
        /// </summary>
        public OpreationResuleType ResuleType { get; set; }

        /// <summary>
        /// 初始化一个操作结果
        /// </summary>
        /// <param name="type">操作类型</param>
        /// <param name="message">操作信息</param>
        /// <returns></returns>
        public static OpreationResult Init(OpreationResuleType type, string message = "操作成功")
        {
            return new OpreationResult() { Message = message, ResuleType = type };
        }
    }

    public enum OpreationResuleType
    {
        /// <summary>
        /// 操作成功
        /// </summary>
        Success = 200,

        /// <summary>
        /// 服务器错误
        /// </summary>
        Error = 500,

        /// <summary>
        /// 信息验证失败
        /// </summary>
        ValidtorError = 403,

        /// <summary>
        /// 信息查询为空
        /// </summary>
        QueryNull = 404,

        /// <summary>
        /// 用户未登陆
        /// </summary>
        UnLogin=-403
    }
}
