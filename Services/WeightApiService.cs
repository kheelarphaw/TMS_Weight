using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TMS_Weight.Forms;
using TMS_Weight.Models;

namespace TMS_Weight.Services
{
    public class WeightApiService
    {
        public static readonly string _baseAddress = Properties.Settings.Default.BaseuRL;


        #region Login Jan_10_2025
        public async Task<AuthResponse> LoginAsync(LoginUser login)
        {
            AuthResponse info = new AuthResponse();
            string jsonData = JsonConvert.SerializeObject(login);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            };
            HttpClient httpClient = new HttpClient(handler);

            var response = await httpClient.PostAsync($"{_baseAddress}/api/Account/GateLogin", content);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                info = JsonConvert.DeserializeObject<AuthResponse>(result);
            }
            else
            {
                info.IsAuthSuccessful = false;
                info.ErrorMessage = response.ReasonPhrase;
            }
            return info;
        }

        public async Task<AuthResponse> ResetPassword(LoginUser login)
        {
            AuthResponse info = new AuthResponse();
            string jsonData = JsonConvert.SerializeObject(login);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            };
            var httpClient = new HttpClient(handler);
            var response = await httpClient.PostAsync($"{_baseAddress}/api/Account/ResetPassword", content);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                //info = JsonConvert.DeserializeObject<AuthResponse>(result);
                info.IsAuthSuccessful = true;
            }
            else
            {
                info.IsAuthSuccessful = false;
                info.ErrorMessage = response.ReasonPhrase;
            }
            return info;
        }

        public async Task<ResponseMessage> LogOutAsync(string logId)
        {
            ResponseMessage msg = new ResponseMessage();
            string jsonData = JsonConvert.SerializeObject(logId);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            };
            var httpClient = new HttpClient(handler);
            var response = await httpClient.PutAsync($"{_baseAddress}/api/Account/LogOut/?logId={logId}", content);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                msg = JsonConvert.DeserializeObject<ResponseMessage>(result);
            }
            return msg;
        }

        #endregion

        #region In Weight 11_Dec_2024
        public async Task<List<WeightBridgeQueue>> GetWeightBridgeQueueList()
        {
            List<WeightBridgeQueue> wbqList = new List<WeightBridgeQueue>();
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            };
            var httpClient = new HttpClient(handler);
            var response = await httpClient.GetAsync($"{_baseAddress}/api/WeightSupport/GetWeightBridgeQueueList");

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
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            };
            var httpClient = new HttpClient(handler);
            var response = await httpClient.GetAsync($"{_baseAddress}/api/WeightSupport/GetWeighingInQueueList/?yard={yard}&wbId={wbId}");

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
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            };
            var httpClient = new HttpClient(handler);
            var response = await httpClient.GetAsync($"{_baseAddress}/api/WeightSupport/GetWeighingOutQueueList/?yard={yard}&wbId={wbId}");

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
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            };
            var httpClient = new HttpClient(handler);
            var response = await httpClient.GetAsync($"{_baseAddress}/api/Master/GetTransporterList/?active={true}&isBlack={false}");
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
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            };
            var httpClient = new HttpClient(handler);
            var response = await httpClient.GetAsync($"{_baseAddress}/api/WeightSupport/GetTruckList/?active={true}&isBlack={false}");
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
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            };
            var httpClient = new HttpClient(handler);
            var response = await httpClient.GetAsync($"{_baseAddress}/api/WeightSupport/GetTrailerList/?active={true}&isBlack={false}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                truckList = JsonConvert.DeserializeObject<List<Vehicle>>(content);
            }
            return truckList;
        }


        public async Task<List<Customer>> GetCustomerList()
        {
            List<Customer> cusList = new List<Customer>();
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            };
            var httpClient = new HttpClient(handler);
            var response = await httpClient.GetAsync($"{_baseAddress}/api/WeightSupport/GetCustomerList");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                cusList = JsonConvert.DeserializeObject<List<Customer>>(content);
            }
            return cusList;
        }

        public async Task<List<Gate>> GetGateList()
        {
            List<Gate> gateList = new List<Gate>();
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            };
            var httpClient = new HttpClient(handler);
            var response = await httpClient.GetAsync($"{_baseAddress}/api/Master/GetGateList/?active={true}");
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
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            };
            var httpClient = new HttpClient(handler);
            var response = await httpClient.GetAsync($"{_baseAddress}/api/Master/GetGateList/?active=All");
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
                var handler = new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                };
                using (var httpClient = new HttpClient(handler))
                {
                    var content = new StringContent(JsonConvert.SerializeObject(weightInfo));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    // Make the POST request
                    var response = await httpClient.PostAsync($"{_baseAddress}/api/WeightSupport/SaveServiceBillForAdHoc", content);
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


        public async Task<ResponseMessage> SaveServiceBillForInQueue(WeightServiceBill weightInfo)
        {
            ResponseMessage msg = new ResponseMessage();
            try
            {
                var handler = new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                };
                using (var httpClient = new HttpClient(handler))
                {
                    var content = new StringContent(JsonConvert.SerializeObject(weightInfo));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    // Make the POST request
                    var response = await httpClient.PostAsync($"{_baseAddress}/api/WeightSupport/SaveServiceBillForQueue", content);
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

        public async Task<ResponseMessage> UpdateServiceBillForOutQueue(WeightServiceBill weightInfo)
        {
            ResponseMessage msg = new ResponseMessage();
            try
            {

                var handler = new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                };
                using (var httpClient = new HttpClient(handler))
                {
                    var content = new StringContent(JsonConvert.SerializeObject(weightInfo));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    // Make the POST request
                    var response = await httpClient.PutAsync($"{_baseAddress}/api/WeightSupport/UpdateServiceBillForQueue", content);
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
        public async Task<List<ServiceBill>> GetServiceBillList(string fromDate)
        {
            List<ServiceBill> billList = new List<ServiceBill>();
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            };
            var httpClient = new HttpClient(handler);

            var response = await httpClient.GetAsync($"{_baseAddress}/api/WeightSupport/GetServiceBillList/?fromDate={fromDate}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                billList = JsonConvert.DeserializeObject<List<ServiceBill>>(content);
            }
            return billList;
        }


        public async Task<WeightServiceBill> GetServiceBillPrintData(string serviceBillNo)
        {
            WeightServiceBill printData = new WeightServiceBill();
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            };
            var httpClient = new HttpClient(handler);

            var response = await httpClient.GetAsync($"{_baseAddress}/api/WeightSupport/GetServiceBillPrintData/?id={serviceBillNo}");

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
