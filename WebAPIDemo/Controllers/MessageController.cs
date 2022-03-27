using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebAPIDemo.BusinessLayer;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    [RoutePrefix("api/message")]
    public class MessageController : ApiController
    {
        private bool CheckBasicAuth()
        {
            bool result = false;

            var request = HttpContext.Current.Request;
            var authHeader = request.Headers["Authorization"];
            if (authHeader != null)
            {
                if (authHeader == "Bearer 12345")
                    return true;
            }

            return result;
        }

        [HttpPost]
        public IHttpActionResult Message(object input)
        {
            //基本認證
            if (!CheckBasicAuth())
                return BadRequest();

            var result = new ApiResult();

            if (input != null)
            {
                var message = Newtonsoft.Json.JsonConvert.DeserializeObject<Message>(input.ToString());

                switch (message.messageSource)
                {
                    case "UniCalc":
                        if (message.messageSubject == "stdf")
                        {
                            result.Message = MessageSTDFLogic.Process(message);
                        }
                        else if (message.messageSubject == "lot end message")
                        {
                            //

                        }
                        else if (message.messageSubject == "offline binning")
                        {
                            //
                        }
                        else
                        {
                            result.Message = $"{message.messageType} messageSubject undefinded:{message.messageSubject}";
                        }
                        break;

                    case "OLB_01":

                        break;

                    default:

                        result.Message = $"messageType undefinded:{message.messageType}";

                        break;
                }
            }


            return Ok(result);
        }
    }
}
