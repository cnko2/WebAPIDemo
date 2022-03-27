using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDemo.Models
{
    public class Message
    {
        public string code { get; set; }
        public string messageSource { get; set; }
        public string messageSubject { get; set; }
        public string messageType { get; set; }
        public string mesdsateStatus { get; set; }
        public string messageTime { get; set; }
        public string messageLevel { get; set; }
        public string messageDescription { get; set; }
        public object messageAppendix { get; set; }
    }
}