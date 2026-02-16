using System;

namespace BookStoreApplication
{
    public class BookUtility
    {
        private Book _book;

        public BookUtility(Book book)
        {
            // TODO: Assign book object
            _book=book;
        }

        public void GetBookDetails()
        {
            // TODO:
            // Print format:
            // Details: <BookId> <Title> <Price> <Stock>
            System.Console.WriteLine($"Details: {_book.Id} {_book.Title} {_book.Price} {_book.Stock}");
        }

        public void UpdateBookPrice(int newPrice)
        {
            // TODO:
            // Validate new price
            // Update price
            // Print: Updated Price: <newPrice>
            if (newPrice < 0)
            {
                throw new InvalidBookDataException("cannot update price as given price is negative");
            }
            _book.Price=newPrice;
            System.Console.WriteLine($"Updated Price: {_book.Price}");
        }

        public void UpdateBookStock(int newStock)
        {
            // TODO:
            // Validate new stock
            // Update stock
            // Print: Updated Stock: <newStock>
             if (newStock< 0)
            {
                throw new InvalidBookDataException("cannot update Stock as given Stock is negative");
            }
            _book.Stock=newStock;
            System.Console.WriteLine($"Updated Stock: {_book.Stock}");
        }

    }
}
