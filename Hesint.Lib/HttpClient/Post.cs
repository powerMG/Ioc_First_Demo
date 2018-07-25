using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Hesint.Lib.HttpClient
{
    internal class PostEntity
    {
       internal string Url { get; set; }

       internal object Data { get; set; }
    }
    public static class Post<T>
    {

        public static async Task<T> PostAsync (string url,object data)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                var postStr = "";
                if (data != null)
                {
                    postStr = JsonConvert.SerializeObject(data);
                }
                var responeData = "";
                using(WebResponse respone=await request.GetResponseAsync())
                {
                    using (StreamReader reader = new StreamReader(respone.GetResponseStream()))
                    {
                        responeData = await reader.ReadToEndAsync();
                    }
                }
                return JsonConvert.DeserializeObject<T>(responeData);
            }
            catch (Exception e)
            {
                //这里写入日志
                return default(T);
            }
        }
    }
}
