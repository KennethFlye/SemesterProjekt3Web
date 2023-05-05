using Newtonsoft.Json;
using SemesterProjekt3Web.Models;

namespace SemesterProjekt3Web.ApiAccess
{
    public class ShowingAccess
    {
        readonly string baseUrl = "https://localhost:7155/api/showings";
        readonly HttpClient client;

        public ShowingAccess()
        {
            client = new HttpClient();
        }

        public async Task<Showing> GetShowingById(int id)
        {
            Showing show;


            string url = baseUrl + $"/{id}";
            var uri = new Uri(string.Format(url));


            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    show = JsonConvert.DeserializeObject<Showing>(content);
                }
                else
                {
                    show = null;
                }
            }
            catch
            {
                throw;
            }
            return show;
        }
    }
}
