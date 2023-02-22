using LibraryManagement.Data;
using LibraryManagement.Interfaces;
using LibraryManagement.Models;

namespace LibraryManagement.Repositories
{
    public class ReaderRepository : IReaderRepository
    {

        private readonly DataContext _context;

        public ReaderRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Reader> GetReaders()
        {
            return _context.Readers.OrderBy(r => r.Id).ToList();
        }
    }
}
