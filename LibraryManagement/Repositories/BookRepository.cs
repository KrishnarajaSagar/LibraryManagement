using LibraryManagement.Data;
using LibraryManagement.Interfaces;
using LibraryManagement.Models;

namespace LibraryManagement.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;
        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public bool BookExists(int id)
        {
            return _context.Books.Any(b => b.Id == id);
        }

        public bool CreateBook(Book book)
        {
            _context.Add(book);

            return Save();
        }

        public Book GetBook(int id)
        {
            return _context.Books.Where(
                b => b.Id == id).FirstOrDefault();
        }

        public ICollection<Book> GetBooks()
        {
            return _context.Books.ToList();
        }

        public Reader GetReaderByBookId(int bookId)
        {
            return _context.Books.Where(
                b => b.Id == bookId)
                .Select(b => b.Reader)
                .First();
        }

        public ICollection<Review> GetReviewsByBookId(int bookId)
        {
            return _context.Books.Where(
                b => b.Id == bookId)
                .Select(b => b.Reviews).ToList()
                .First();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
