using System;
using System.Collections.Generic;
using System.Text;

namespace Hesint.Core.Businesses
{
    public interface IPage
    {
        int PageSize { get; set; }

        int PageIndex { get; set; }

        /// <summary>
        /// 总条数
        /// </summary>
        int TotalCount { get; set; }

        /// <summary>
        /// 总页数 
        /// </summary>
        int TotalPageCount { get; set; }
    }
}
