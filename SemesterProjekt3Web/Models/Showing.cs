namespace SemesterProjekt3Api.Model
{
    public class Showing
    {

        public int Id { get; set; }
        public DateTime startTime { get; set; }
        public bool IsKidFriendly { get; set; }
        public ShowRoom ShowRoom { get; set; }
        public MovieCopy MovieCopy { get; set; }

    }
}
