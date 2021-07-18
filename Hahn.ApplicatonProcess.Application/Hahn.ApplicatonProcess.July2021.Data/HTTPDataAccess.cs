using Hahn.ApplicatonProcess.July2021.Core.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Hahn.ApplicatonProcess.July2021.Data.Repository
{
    public class HTTPDataAccess
    {
        private static readonly HttpClient client = new ();

        public static AssetsVm Assets()
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));


            HttpResponseMessage response = client.GetAsync($"https://api.coincap.io/v2/assets").Result;
            return JsonConvert.DeserializeObject<AssetsVm>(response.Content.ReadAsStringAsync().Result);
            }
            catch (System.Exception)
            {

                throw;
            }
            
		}
    }
}
