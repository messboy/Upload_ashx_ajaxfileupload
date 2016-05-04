using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Web;

namespace WebApplication2
{
    /// <summary>
    /// Handler1 的摘要描述
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpFileCollection files = context.Request.Files;

            string id = "id";
            string name = "name";
            result rlt = new result() { id = id, name = name };
            DataContractJsonSerializer json = new DataContractJsonSerializer(rlt.GetType());
            json.WriteObject(context.Response.OutputStream, rlt);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public class result
        {
            public string id { get; set; }
            public string name { get; set; }
        }
    }
}