namespace LibraryManagementSystem
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int PublicationYear { get; set; }
        public Book(string title, string author, string genre, int year)
        {
            Title = title;
            Author = author;
            Genre = genre;
            PublicationYear = year;
        }
    }

    public class LibraryUtility
    {
        public static SortedDictionary<int, Book> Books = new();
        public void AddBook(string title, string author, string genre, int year)
        {
            Book book = new(title, author, genre, year);
            Books.Add(Books.Count + 1, book);// Id and Book
        }
        public SortedDictionary<string, List<Book>> GroupBooksByGenre()
        {
            SortedDictionary<string, List<Book>> result = new();
            foreach (var book in Books)
            {
                if (result.ContainsKey(book.Value.Genre))
                {
                    result[book.Value.Genre].Add(book.Value);
                }
                else
                {
                    result[book.Value.Genre] = new List<Book>();
                    result[book.Value.Genre].Add(book.Value);
                }
            }
            return result;
        }
        public List<Book> GetBooksByAuthor(string author)
        {
            List<Book> authorbooks = new();
            foreach (var book in Books)
            {
                if (book.Value.Author == author)
                {
                    authorbooks.Add(book.Value);
                }
            }
            return authorbooks;
        }
        public int GetTotalBooksCount()
        {
            return Books.Count();
        }
    }

    class Program
    {
        static void Main()
        {
            LibraryUtility library = new LibraryUtility();

            library.AddBook("The Hobbit", "J.R.R. Tolkien", "Fiction", 1937);
            library.AddBook("Sapiens", "Yuval Noah Harari", "Non-Fiction", 2011);
            library.AddBook("The Da Vinci Code", "Dan Brown", "Mystery", 2003);
            library.AddBook("Inferno", "Dan Brown", "Mystery", 2013);
            library.AddBook("1984", "George Orwell", "Fiction", 1949);

            Console.WriteLine("Books Grouped By Genre:");
            var groupedBooks = library.GroupBooksByGenre();
            foreach (var genre in groupedBooks)
            {
                Console.WriteLine($"\nGenre: {genre.Key}");
                foreach (var book in genre.Value)
                {
                    Console.WriteLine($"{book.Title} - {book.Author} ({book.PublicationYear})");
                }
            }

            Console.WriteLine("\nBooks by Dan Brown:");
            var authorBooks = library.GetBooksByAuthor("Dan Brown");
            foreach (var book in authorBooks)
            {
                Console.WriteLine($"{book.Title} - {book.Genre}");
            }

            Console.WriteLine("\nStatistics:");
            Console.WriteLine($"Total Books: {library.GetTotalBooksCount()}");

        }
    }
}