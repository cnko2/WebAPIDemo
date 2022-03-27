using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDemo.Models
{
    public class MessageLotEnd
    {
        public string lotType { get; set; }
        public string lotId { get; set; }
        public string errorMessage { get; set; }
    }
}