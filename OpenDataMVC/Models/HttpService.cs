using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace OpenDataMvc.Models
{
    public class HttpService
    {
        public string GetResponse(string uri)
        {
            string result = string.Empty;

            ////Prepare OAuth request 
            //WebRequest webRequest = WebRequest.Create(uri);
            //webRequest.ContentType = "application/x-www-form-urlencoded";
            //webRequest.Method = "GET";
            //using (Stream outputStream = webRequest.GetRequestStream())
            //{
            //    System.Runtime.Serialization.DataContractSerializer dcs = new System.Runtime.Serialization.DataContractSerializer(Type.GetType("System.String"));
            //    result = (string)dcs.ReadObject(outputStream);
            //}

            //uri = System.Web.HttpUtility.UrlDecode(uri);
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            WebResponse response = null;
            try
            {
                response = httpWebRequest.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    //System.Runtime.Serialization.DataContractSerializer dcs = new System.Runtime.Serialization.DataContractSerializer(Type.GetType("System.String"));
                    //result = (string)dcs.ReadObject(stream);

                    using (StreamReader myStreamReader = new StreamReader(stream))
                    {
                        result = myStreamReader.ReadToEnd();
                    }
                }

                return result;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
            }
        }
    }

    public enum DataTypeEnum
    {
        None,
        XML,
        JSON,
        JSONP,
        CAP,
    }
}