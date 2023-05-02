using SemesterProjekt3Web.Access;
using SemesterProjekt3Web.Models;

namespace SemesterProjekt3Web.BusinessLogic
{
    public class MovieAccessLogic
    {

        private readonly MovieAccess api;

        public MovieAccessLogic()
        {
            api = new MovieAccess();
        }

        public async Task<IEnumerable<MovieInfo>> GetMovies()
        {
            IEnumerable<MovieInfo> movies;

            try
            {
                movies = await api.GetMoviesInfo();
            }
            catch (Exception)
            {
                movies = null;
            }
            return movies;
        }

        public async Task<IEnumerable<MovieCopy>> GetMoviesCopy()
        {
            IEnumerable<MovieCopy> movies;

            try
            {
                movies = await api.GetMoviesCopies();
            }
            catch (Exception)
            {
                movies = null;
            }
            return movies;
        }
        public async Task<IEnumerable<Showing>> GetShowingsByMovieID(int id)
        {
            IEnumerable<Showing> showings;

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
