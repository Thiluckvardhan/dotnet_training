namespace MovieLibraryManagementSystem
{
    public class FilmLibrary : IFilmLibrary
    {
        private List<IFilm> _films = new();
        public void AddFilm(IFilm film)
        {
            _films.Add(film);
        }
        public void RemoveFilm(string title)
        {
            var film = _films.FirstOrDefault(f => f.Title == title);
            if (film != null)
                _films.Remove(film);
        }
        public List<IFilm> GetFilms()
        {
            return _films;
        }
        public List<IFilm> SearchFilms(string query)
        {
            return _films
                .Where(f =>
                    f.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    (f is Film film &&
                     film.Director.Contains(query, StringComparison.OrdinalIgnoreCase))
                )
                .ToList();
        }

        public int GetTotalFilmCount()
        {
            return _films.Count();
        }
    }
}