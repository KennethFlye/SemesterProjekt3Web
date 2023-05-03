namespace SemesterProjekt3Web.Models
{
    public class MovieCopy
    {

        public int CopyId { get; set; }
        public string Language { get; set; }
        public bool Is3D { get; set; }
        public double Price { get; set; }
        public MovieInfo MovieType { get; set; }

    }
}
