using LibraryManagement.Models;

namespace LibraryManagement.Interfaces
{
    public interface IReaderRepository
    {
        public ICollection<Reader> GetReaders();
    }
}
