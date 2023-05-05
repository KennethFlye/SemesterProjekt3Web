using Newtonsoft.Json;
using SemesterProjekt3Web.Models;
using System.Text;

namespace SemesterProjekt3Web.ApiAccess
{
    public class SeatsAccess
    {
        readonly string baseUrl = "https://localhost:7155/api/seats";
        readonly HttpClient client;

        public SeatsAccess()
        {
            client = new HttpClient();
        }

        public async Task<Seat> GetSeatById(string id)
        {
            Seat seat;


            string url = baseUrl + $"/{id}";
            var uri = new Uri(string.Format(url));


            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    seat = JsonConvert.DeserializeObject<Seat>(content);
                }
                else
                {
                    seat = null;
                }
            }
            catch
            {
                throw;
            }

            return seat;
        }
    }
}