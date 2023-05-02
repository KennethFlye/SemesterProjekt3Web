using SemesterProjekt3Web.Access;
using SemesterProjekt3Web.ApiAccess;
using SemesterProjekt3Web.Models;

namespace SemesterProjekt3Web.BusinessLogic
{
    public class ShowingAccessLogic
    {
        private readonly ShowingAccess api;

        public ShowingAccessLogic()
        {
            api = new ShowingAccess();
        }
        public async Task<Showing> GetShowingById(int id)
        {
             Showing show; 

            try
            {
                show = await api.GetShowingById(id);
            }
            catch (Exception)
            {
                show = null;
            }
            return show;
        }


    }
}
