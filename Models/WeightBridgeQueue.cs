using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Weight.Models
{
    public class WeightBridgeQueue
    {
        public int? RegNo { get; set; } //mandatory
        public int? QueueNo { get; set; } //increase no depend on InRegNo And WeighID
        public int? InRegNo { get; set; }//mandatory
        public string YardID { get; set; }
        public string GateID { get; set; }//mandatory

        public string Type { get; set; }//In,Out
        public string CargoType { get; set; }
        public string CargoInfo { get; set; }
        public string TruckVehicleRegNo { get; set; }
        public string TrailerVehicleRegNo { get; set; }
        public string DriverLicenseNo { get; set; }
        public string DriverName { get; set; }
        public string DriverContactNo { get; set; }
        public string CardNo { get; set; }
        public string WeightBridgeID { get; set; }

        public string WBOption { get; set; }// Both, Single
        public string BillOption { get; set; }//Credit,Foc,Cash,None
        //public int? WBillNo { get; set; }
        public string Customer { get; set; }
        //public string JobCode { get; set; }
        //public string JobDescription { get; set; }
        //public DateTime? WeightDateTime { get; set; }
        public string Status { get; set; }//Queue,Done

        public string BLNo { get; set; }
        public string ContainerNo { get; set; }
    }
}
