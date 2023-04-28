using Newtonsoft.Json;
using SemesterProjekt3Web.Models;
using System.Text;

namespace SemesterProjekt3Web.Access
{
    public class MovieAccess
    {
        readonly string baseUrl = "https://localhost:7155/api/movies";
        readonly HttpClient client;

        public MovieAccess()
        {
            client = new HttpClient();
        }

        public async Task<List<MovieInfo>> GetMovies()
        {
            List<MovieInfo> movies;

            // Create URI
            var uri = new Uri(string.Format(baseUrl));

            //
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    movies = JsonConvert.DeserializeObject<List<MovieInfo>>(content);
                }
                else
                {
                    movies = null;
                }
            }
            catch
            {
                throw;
            }
            return movies;
        }
        public async Task<List<Showing>> GetShowingsByMovieID(int Id)
        {
            List<Showing> showings;

            // Create URI
            string url = baseUrl + $"/{Id}/showings";
            var uri = new Uri(string.Format(url));

            //
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    showings = JsonConvert.DeserializeObject<List<Showing>>(content);
                }
                else
                {
                    showings = null;
                }
            }
            catch
            {
                throw;
            }
            return showings;
        }



    }

}
