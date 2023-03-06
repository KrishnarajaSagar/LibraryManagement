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

        public Reader GetReader(int id)
        {
            return _context.Readers.Where(r => r.Id == id).FirstOrDefault();
        }

        public bool ReaderExists(int readerId)
        {
            return _context.Readers.Any(r => r.Id == readerId);
        }

        public bool CreateReader(Reader reader)
        {
            _context.Add(reader);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateReader(Reader reader)
        {
            _context.Update(reader);
            return Save();
        }

        public bool DeleteReader(Reader reader)
        {
            _context.Remove(reader);
            return Save();
        }
    }
}
