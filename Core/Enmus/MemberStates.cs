using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Enmus
{
    public enum MemberStates
    {
        /// <summary>
        /// 已经激活
        /// </summary>
        Actived=0,

        /// <summary>
        /// 已经通过微信分享了，待用户激活
        /// </summary>
        UnActived=1,

        /// <summary>
        /// 用户已经被禁止登录了
        /// </summary>
        Baned=2
    }
}
