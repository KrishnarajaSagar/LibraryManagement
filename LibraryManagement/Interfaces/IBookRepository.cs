using LibraryManagement.Models;

namespace LibraryManagement.Interfaces
{
    public interface IBookRepository
    {
        ICollection<Book> GetBooks();
        Book GetBook(int id);
        Reader GetReaderByBookId(int bookId);
        ICollection<Review> GetReviewsByBookId(int bookId);
        bool BookExists(int id);
        bool CreateBook(int categoryId, Book book);
        bool Save();
        bool UpdateBook(int categoryId, Book book);
        bool DeleteBook(Book book);
    }
}
