using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIDemo.Models;
using Newtonsoft.Json.Converters;

namespace WebAPIDemo.BusinessLayer
{
    public class MessageSTDFLogic
    {
        public static string Process(Message message)
        {
            var result = string.Empty;

            result += WriteMessage($"code:{message.code}");
            result += WriteMessage($"messageSource:{message.messageSource}");
            result += WriteMessage($"messageSubject:{message.messageSubject}");
            result += WriteMessage($"mesdsateStatus:{message.mesdsateStatus}");
            result += WriteMessage($"messageTime:{message.messageTime}");
            result += WriteMessage($"messageLevel:{message.messageLevel}");
            result += WriteMessage($"messageDescription:{message.messageDescription}");

            ////反序列化
            var messageAppendix = 
                message.messageAppendix!=null?
                Newtonsoft.Json.JsonConvert.DeserializeObject<MessageSTDF>(message.messageAppendix.ToString()):
                null;

            if (message.messageType== "acknowledge")
            {

                result += WriteMessage($"STDFFileNames:{messageAppendix.STDFFileNames}{Environment.NewLine}");
            }
            else if (message.messageType == "error")
            {
                result += WriteMessage($"STDFFileNames:{messageAppendix.STDFFileNames}{Environment.NewLine}");
                result += WriteMessage($"errorMessage:{messageAppendix.errorMessage}");

            }
            else if (message.messageType == "warning")
            {
                result += WriteMessage($"STDFFileNames:{messageAppendix.STDFFileNames}");

            }
            else
            {

            }

            return result;
        }

        private static string WriteMessage(string value)
        {
            if (value == string.Empty)
                return value;
            else
                return value += $"{Environment.NewLine}{value}";

        }
    }
}