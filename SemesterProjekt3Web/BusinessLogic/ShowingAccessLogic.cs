using SemesterProjekt3Web.ApiAccess;
using SemesterProjekt3Web.Models;

namespace SemesterProjekt3Web.BusinessLogic
{
    public class ShowingAccessLogic
    {
        public ShowingAccessLogic()
        {
            var api = new ShowingAccess();
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
