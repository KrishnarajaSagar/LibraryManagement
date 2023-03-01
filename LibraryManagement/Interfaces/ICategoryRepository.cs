using LibraryManagement.Models;

namespace LibraryManagement.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Book> GetBooksByCategory(int categoryId);
        bool CategoryExists(int id);
    }
}
