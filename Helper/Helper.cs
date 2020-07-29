using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Helper
{
    public static class Helper
    {
        public static async Task<TOuput> SendAsync<TRequest, TOuput>(string url, TRequest request)
        {
            try
            {
                HttpClient _client = new HttpClient();                
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                };
                string apiKey = "0uyhscb3s0rkkqgydzro098vvhioffri#of1773jrbz9u1wvb4umh79sz8l4omydo8bgdbywbi70h1jvrxct2h5esk4087byg";
                string jsonString = JsonConvert.SerializeObject(request, Formatting.Indented, settings);
                var httpRequestMessage = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Headers = {
                        { HttpRequestHeader.Authorization.ToString(), "API-Key " + apiKey },
                        { HttpRequestHeader.Accept.ToString(), "application/json" },
                        { HttpRequestHeader.ContentType.ToString(), "application/json" }
                    },
                    Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
                };
                var response = await _client.SendAsync(httpRequestMessage);                

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<TOuput>(responseString);
                    return responseObject;
                }
                return default(TOuput);
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }

        public static async void Test<TRequest>(TRequest request)
        {
            try
            {
                string apiKey = "0uyhscb3s0rkkqgydzro098vvhioffri#of1773jrbz9u1wvb4umh79sz8l4omydo8bgdbywbi70h1jvrxct2h5esk4087byg";
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "API-Key " + apiKey);

                string message = "@{\"payment_credit_date\":\"2020-03-06\",\"payment_type\":\"payment-type-EU-SEPA-Step2\",\"who_pays_charges\":\"shared\",\"reference\":\"this is a test payment\",\"amount\":1.0,\"ledger_from_id\":\"5f20010f-b464-4ded-976d-7b8c0af0ba5d\",\"beneficiary_id\":\"5f2004eb-de7d-41db-95a9-8319e1dcddcc\"}";
                byte[] messageBytes = System.Text.Encoding.ASCII.GetBytes(message);
                var content = new ByteArrayContent(messageBytes);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = client.PostAsync("https://playlive.railsbank.com/v1/customer/transactions", content);
                if (response.Result.IsSuccessStatusCode)
                {
                    Console.WriteLine("test");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
