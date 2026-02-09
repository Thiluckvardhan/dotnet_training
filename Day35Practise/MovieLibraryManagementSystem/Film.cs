namespace MovieLibraryManagementSystem
{
    public class Film : IFilm
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
        public Film(string title, string director, int year)
        {
            Title = title;
            Director = director;
            Year = year;
        }

    }
}