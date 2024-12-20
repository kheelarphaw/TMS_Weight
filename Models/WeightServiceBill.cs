﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Weight.Models
{
    public class WeightServiceBill
    {
        public string ServiceBillNo { get; set; } 
        public string WeightBridgeID { get; set; }
        public DateTime? ServiceBillDate { get; set; }
        public DateTime? InWeightTime { get; set; }
        public DateTime? OutWeightTime { get; set; }
        public string TruckNo { get; set; }
        public string TrailerNo { get; set; }
        public int? QRegNo { get; set; }
        public decimal? InWeight { get; set; }
        public decimal? OutWeight { get; set; }
        public decimal? NetWeight { get; set; }
        public string WeightType { get; set; }
        public string CargoInfo { get; set; }
        public string WeightOption { get; set; }
        public string BillOption { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public decimal CashAmt { get; set; }
        public int? CheckInRegNo { get; set; }
        public string WeightCategory { get; set; }
        public string DriverName { get; set; }
        public string DriverLicense { get; set; }
        public string ContainerNo { get; set; }
        public string DONo { get; set; }
        public string BLNo { get; set; }
        public string VesselName { get; set; }
        public string TransporterID { get; set; }
        public string YardID { get; set; }
        public string GateID { get; set; }
        public string Remark { get; set; }
    }
}
