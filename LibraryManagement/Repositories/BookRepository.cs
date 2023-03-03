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

        public bool CreateBook(int categoryId, Book book)
        {
            var category = _context.Categories
                .Where(c => c.Id == categoryId)
                .FirstOrDefault();

            var bookCategory = new BookCategory()
            {
                Category = category,
                Book = book
            };

            _context.Add(bookCategory);
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

        public bool UpdateBook(int categoryId, Book book)
        {
            var bookCategoryEntity = _context.BookCategories
                .Where(bc => bc.BookId == book.Id)
                .FirstOrDefault();

            var categoryEntity = _context.Categories
                .Where(c => c.Id == categoryId)
                .FirstOrDefault();

            if (bookCategoryEntity != null && categoryEntity != null)
            {
                _context.Remove(bookCategoryEntity);
                var bookCategory = new BookCategory()
                {
                    Book = book,
                    Category = categoryEntity
                };
                _context.Add(bookCategory);
            }
            
            _context.Update(book);
            return Save();
        }
    }
}
