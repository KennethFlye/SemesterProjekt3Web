using SemesterProjekt3Api.Model;
using SemesterProjekt3Web.Access;


namespace SemesterProjekt3Web.BusinessLogic
{
    public class MovieAccessLogic
    {

        private readonly MovieAccess api;

        public MovieAccessLogic()
        {
            api = new MovieAccess();
        }

        public async Task<List<MovieInfo>> GetMovies()
        {
            List<MovieInfo> movies;

            try
            {
                movies = await api.GetMovies();
            }
            catch (Exception)
            {
                movies = null;
            }
            return movies;
        }
        public async Task<List<Showing>> GetShowingsByMovieID(int id)
        {
            List<Showing> showings;

            try
            {
                showings = await api.GetShowingsByMovieID(id);
            }
            catch (Exception)
            {
                showings = null;
            }
            return showings;
        }
    }
}
