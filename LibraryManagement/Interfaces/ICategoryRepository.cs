using LibraryManagement.Models;

namespace LibraryManagement.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Book> GetBooksByCategory(int categoryId);
        bool CategoryExists(int id);
        bool CreateCategory(Category category);
        bool Save();
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);
    }
}
