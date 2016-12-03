using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RobotERP.IdentityModel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            taskIdentity().GetAwaiter().GetResult();
            Console.ReadKey();
        }
        public static async Task taskIdentity()
        {
            var disco = await DiscoveryClient.GetAsync("http://localhost:5000");

            var tokeClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
            var tokenResponse = await tokeClient.RequestClientCredentialsAsync("api1");
            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }
            Console.WriteLine(tokenResponse.Json);
            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);
            var response = await client.GetAsync("http://localhost:5001/identity");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(JArray.Parse(content));
            }
        }
    }
}
