namespace MovieLibraryManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IFilmLibrary library = new FilmLibrary();

            // ---------------- TEST CASE 1: Add Films ----------------
            Console.WriteLine("TEST CASE 1: Adding films");

            Film f1 = new Film("Inception", "Christopher Nolan", 2010);
            Film f2 = new Film("Interstellar", "Christopher Nolan", 2014);
            Film f3 = new Film("Titanic", "James Cameron", 1997);

            library.AddFilm(f1);
            library.AddFilm(f2);
            library.AddFilm(f3);

            Console.WriteLine("Films added successfully\n");

            // ---------------- TEST CASE 2: Display All Films ----------------
            Console.WriteLine("TEST CASE 2: Displaying all films");

            foreach (Film film in library.GetFilms())
            {
                Console.WriteLine($"{film.Title} | {film.Director} | {film.Year}");
            }
            Console.WriteLine();

            // ---------------- TEST CASE 3: Search by Director ----------------
            Console.WriteLine("TEST CASE 3: Search films by director 'Nolan'");

            List<IFilm> searchResult = library.SearchFilms("Nolan");
            foreach (IFilm film in searchResult)
            {
                if (film is Film f)
                    Console.WriteLine($"{f.Title} | {f.Director}");
                else
                    Console.WriteLine(film.Title);
            }
            Console.WriteLine();

            // ---------------- TEST CASE 4: Remove a Film ----------------
            Console.WriteLine("TEST CASE 4: Removing film 'Titanic'");
            library.RemoveFilm("Titanic");

            Console.WriteLine("Remaining films:");
            foreach (Film film in library.GetFilms())
            {
                Console.WriteLine(film.Title);
            }
            Console.WriteLine();

            // ---------------- TEST CASE 5: Get Total Film Count ----------------
            Console.WriteLine("TEST CASE 5: Total film count");
            Console.WriteLine("Total Films: " + library.GetTotalFilmCount());
        }
    }

}