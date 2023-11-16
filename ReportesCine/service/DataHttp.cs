using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Reporting.WinForms;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace ReportesCine.service
{
    public class DataHttp
    {
        private string Url { get; set; }
        private string Route { get; set; }

        public DataHttp(string route)
        {
            Url = "https://localhost:7011/api/";
            Route = route;
        }

        public async Task<string> Get()
        {

            using (var client = new HttpClient(new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            }))
            {
                try
                {
                    var result = await client.GetAsync(Url+Route);
                    var content = await result.Content.ReadAsStringAsync();
                    Console.WriteLine($"Status Code: {result.StatusCode}");
                    Console.WriteLine($"Response Content: {content}");
                    return content;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                    return null;
                }
            }
        }


    }

}
