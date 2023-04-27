namespace SemesterProjekt3Api.Model
{
    public class MovieCopy
    {

        public int Id { get; set; }
        public string Language { get; set; }
        public bool Is3D { get; set; }
        public double Price { get; set; }
        public MovieInfo MovieType { get; set; }

    }
}
