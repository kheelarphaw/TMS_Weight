using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TMS_Weight.Models;

namespace TMS_Weight.Services
{
    public class WeightApiService
    {
        public static readonly string _baseAddress = BaseUrl.ApiUrl;


        #region In Weight 11_Dec_2024
        public async Task<List<WeightBridgeQueue>> GetWeightBridgeQueueList()
        {
            List<WeightBridgeQueue> wbqList = new List<WeightBridgeQueue>();
            HttpClient client = new HttpClient();
            //var response = await client.GetAsync($"{_baseAddress}/api/WeightSupport/GetWeightBridgeQueueList/?yard={yard}&gate={gate}");
            var response = await client.GetAsync($"{_baseAddress}/api/WeightSupport/GetWeightBridgeQueueList");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                wbqList = JsonConvert.DeserializeObject<List<WeightBridgeQueue>>(content);
            }
            return wbqList;
        }


        public async Task<List<WeightBridgeQueue>> GetWeighingInQueueList(string yard, string wbId)
        {
            List<WeightBridgeQueue> wbqList = new List<WeightBridgeQueue>();
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"{_baseAddress}/api/WeightSupport/GetWeighingInQueueList/?yard={yard}&wbId={wbId}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                wbqList = JsonConvert.DeserializeObject<List<WeightBridgeQueue>>(content);
            }
            return wbqList;
        }


        public async Task<List<WeightBridgeQueue>> GetWeighingOutQueueList(string yard, string wbId)
        {
            List<WeightBridgeQueue> wbqList = new List<WeightBridgeQueue>();
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"{_baseAddress}/api/WeightSupport/GetWeighingOutQueueList/?yard={yard}&wbId={wbId}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                wbqList = JsonConvert.DeserializeObject<List<WeightBridgeQueue>>(content);
            }
            return wbqList;
        }


        public async Task<List<Transporter>> GetTransporterList()
        {
            List<Transporter> transporterList = new List<Transporter>();
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"{_baseAddress}/api/Master/GetTransporterList/?active={true}&isBlack={false}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                transporterList = JsonConvert.DeserializeObject<List<Transporter>>(content);
            }
            return transporterList;
        }

        public async Task<List<Vehicle>> GetTruckList()
        {
            List<Vehicle> trailerList = new List<Vehicle>();
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"{_baseAddress}/api/WeightSupport/GetTruckList/?active={true}&isBlack={false}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                trailerList = JsonConvert.DeserializeObject<List<Vehicle>>(content);
            }
            return trailerList;
        }

        public async Task<List<Vehicle>> GetTrailerList()
        {
            List<Vehicle> truckList = new List<Vehicle>();
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"{_baseAddress}/api/WeightSupport/GetTrailerList/?active={true}&isBlack={false}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                truckList = JsonConvert.DeserializeObject<List<Vehicle>>(content);
            }
            return truckList;
        }

        public async Task<List<Gate>> GetGateList()
        {
            List<Gate> gateList = new List<Gate>();
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"{_baseAddress}/api/Master/GetGateList/?active={true}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                gateList = JsonConvert.DeserializeObject<List<Gate>>(content);
            }
            return gateList;
        }

        public async Task<List<Gate>> GetAllGateList()
        {
            List<Gate> gateList = new List<Gate>();
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"{_baseAddress}/api/Master/GetGateList/?active=All");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                gateList = JsonConvert.DeserializeObject<List<Gate>>(content);
            }
            return gateList;
        }

        public async Task<ResponseMessage> SaveServiceBillForAdHoc(WeightServiceBill weightInfo)
        {
            ResponseMessage msg = new ResponseMessage();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(weightInfo));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    // Make the POST request
                    var response = await client.PostAsync($"{_baseAddress}/api/WeightSupport/SaveServiceBillForAdHoc", content);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        msg = JsonConvert.DeserializeObject<ResponseMessage>(result);
                    }
                    else
                    {
                        // If the request fails, log the response content for debugging
                        string errorContent = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Error {response.StatusCode}: {errorContent}");
                    }
                }

            }
            catch (Exception ex)
            {
                msg.MessageContent = $"An error occurred while saving weight service bill: {ex.Message}";
            }
            return msg;
        }


        public async Task<ResponseMessage> SaveServiceBillForQueue(WeightServiceBill weightInfo)
        {
            ResponseMessage msg = new ResponseMessage();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(weightInfo));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    // Make the POST request
                    var response = await client.PostAsync($"{_baseAddress}/api/WeightSupport/SaveServiceBillForQueue", content);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        msg = JsonConvert.DeserializeObject<ResponseMessage>(result);
                    }
                    else
                    {
                        // If the request fails, log the response content for debugging
                        string errorContent = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Error {response.StatusCode}: {errorContent}");
                    }
                }

            }
            catch (Exception ex)
            {
                msg.MessageContent = $"An error occurred while saving weight service bill: {ex.Message}";
            }
            return msg;
        }

        public async Task<ResponseMessage> UpdateServiceBillForQueue(WeightServiceBill weightInfo)
        {
            ResponseMessage msg = new ResponseMessage();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(weightInfo));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    // Make the POST request
                    var response = await client.PutAsync($"{_baseAddress}/api/WeightSupport/UpdateServiceBillForQueue", content);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        msg = JsonConvert.DeserializeObject<ResponseMessage>(result);
                    }
                    else
                    {
                        // If the request fails, log the response content for debugging
                        string errorContent = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Error {response.StatusCode}: {errorContent}");
                    }
                }

            }
            catch (Exception ex)
            {
                msg.MessageContent = $"An error occurred while saving weight service bill: {ex.Message}";
            }
            return msg;
        }
        public async Task<List<WeightServiceBill>> GetServiceBillList(string fromDate)
        {
            List<WeightServiceBill> billList = new List<WeightServiceBill>();
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"{_baseAddress}/api/WeightSupport/GetServiceBillList/?fromDate={fromDate}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                billList = JsonConvert.DeserializeObject<List<WeightServiceBill>>(content);
            }
            return billList;
        }


        public async Task<WeightServiceBill> GetServiceBillPrintData(string serviceBillNo)
        {
            WeightServiceBill printData = new WeightServiceBill();
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"{_baseAddress}/api/WeightSupport/GetServiceBillPrintData/?id={serviceBillNo}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                printData = JsonConvert.DeserializeObject<WeightServiceBill>(content);
            }
            return printData;
        }

        #endregion

    }
}
