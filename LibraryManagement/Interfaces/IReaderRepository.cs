using LibraryManagement.Models;

namespace LibraryManagement.Interfaces
{
    public interface IReaderRepository
    {
        public ICollection<Reader> GetReaders();
        Reader GetReader(int id);
        bool ReaderExists(int readerId);
        bool CreateReader(Reader reader);
        bool Save();
    }
}
