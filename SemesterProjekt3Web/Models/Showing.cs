namespace SemesterProjekt3Web.Models
{
    public class Showing
    {

        public int ShowingId { get; set; }
        public DateTime startTime { get; set; }
        public bool IsKidFriendly { get; set; }
        public ShowRoom ShowRoom { get; set; }
        public MovieCopy MovieCopy { get; set; }

    }
}
