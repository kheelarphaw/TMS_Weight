using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Weight.Models
{
    public class ResponseMessage
    {
        public bool Status { get; set; }
        public string MessageContent { get; set; }
        public string ServiceBillNo { get; set; }
        public string Yard { get; set; }
    }
}
