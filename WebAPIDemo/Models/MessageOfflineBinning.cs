using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDemo.Models
{
    public class MessageOfflineBinning
    {
        public string lotType { get; set; }
        public string stageId { get; set; }
        public string lotEndStatus { get; set; }
        public string lotId { get; set; }
        public string STDFFileInMessage { get; set; }
        public string STDFFileReceived { get; set; }
    }
}