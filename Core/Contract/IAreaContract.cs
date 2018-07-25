using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hesint.Lib;
using Hesint.Lib.Models.ResponeModel;

namespace Core.Contract
{
    public interface IAreaContract
    {
        Task<List<AreaItem>> GetList(int id);

        Task<AreaItem> GetItem(int id);
    }
}
