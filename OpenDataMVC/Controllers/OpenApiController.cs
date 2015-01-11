using Newtonsoft.Json;
using OpenDataMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Xml;

namespace OpenDataMvc.Controllers
{
    public class OpenApiController : ApiController
    {
        private HttpService httpService = new HttpService();

        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        /// <summary>
        /// 颱風RSS-中央氣象局
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// https://alerts.ncdr.nat.gov.tw/RssAtomFeed.ashx?AlertType=5
        /// </remarks>
        public string Get()
        {
            //// To convert an XML node contained in string xml into a JSON string   
            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml(xml);
            //string jsonText = JsonConvert.SerializeXmlNode(doc);

            //// To convert JSON text contained in string json into an XML node
            //XmlDocument doc = JsonConvert.DeserializeXmlNode(json);

            string uri = @"https://alerts.ncdr.nat.gov.tw/RssAtomFeed.ashx";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(httpService.GetResponse(uri));
            doc.RemoveChild(doc.FirstChild);

            return JsonConvert.SerializeXmlNode(doc);

            //return @"{""Name"":""Alice"",""Age"":23,""Pets"":[""Fido"",""Polly"",""Spot""]}";
        }

        // GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}
        public string Get(string id)
        {
            //string uri = System.Web.HttpUtility.UrlEncode(id);
            string uri = id;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(httpService.GetResponse(uri));
            doc.RemoveChild(doc.FirstChild);

            return JsonConvert.SerializeXmlNode(doc);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}