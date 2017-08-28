using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerService_PSR.Utilities
{
    //Dealing with JSON Dates in ASP.NET MVC
    //will convert Json date of '/Date(836418600000)/' to '1996-07-04T00:00:00' 
    //at the end of method, instead of return Json(YOURJSONMODEL, JsonRequestBehavior.AllowGet);
    //you write: return new JsonNetResult() { Data = YOURJSONMODEL };
    public class JsonNetResult : JsonResult
    {
        public new object Data { get; set; }

        public JsonNetResult()
        {
        }

        public override void ExecuteResult(ControllerContext context)
        {
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = "application/json";
            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;
            if (Data != null)
            {
                JsonTextWriter writer = new JsonTextWriter(response.Output) { Formatting = Formatting.Indented };
                JsonSerializer serializer = JsonSerializer.Create(new JsonSerializerSettings());
                serializer.Serialize(writer, Data);
                writer.Flush();
            }
        }
    }
}