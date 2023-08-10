using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Service.APIHandler
{
    public class APIHandler : IAPIHandler
    {
        public T GetApi<T>(string url)
        {
            try
            {
                var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                httpRequest.Method = "GET";
                httpRequest.ContentType = "application/json";
                
                var response = httpRequest.GetResponse();
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var result = reader.ReadToEnd();
                    var model = JsonConvert.DeserializeObject<T>(result);
                    response.Close();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public T PostApi<T>(dynamic dynamicModel, string Url)
        {
            try
            {
                var httpRequest = (HttpWebRequest)WebRequest.Create(Url);
                httpRequest.Method = "POST";
                httpRequest.ContentType = "application/json";
                httpRequest.Headers.Add("Authorization", "Bearer ");
                string JsonData = JsonConvert.SerializeObject(dynamicModel);
                byte[] byteArray = Encoding.UTF8.GetBytes(JsonData);
                httpRequest.ContentLength = byteArray.Length;
                using (var stream = httpRequest.GetRequestStream())
                {
                    stream.Write(byteArray, 0, byteArray.Length);
                    stream.Close();
                }

                var response = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    T model = JsonConvert.DeserializeObject<T>(result);
                    response.Close();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
    }
}
