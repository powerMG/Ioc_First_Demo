using Core.Contract;
using Hesint.Lib.Models.ResponeModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hesint.Lib.HttpClient;
namespace Core.Service
{
    public class AreaService : IAreaContract
    {
        public Task<AreaItem> GetItem(int id)
        {
          return  Post<AreaItem>.PostAsync("http://area/hesint.net", new { id });
        }

        public Task<List<AreaItem>> GetList(int id)
        {
            return Post<List<AreaItem>>.PostAsync("http://area.hesint.net", new { id, isResult = false });
        }
    }
}
