namespace LibraryManagement.Models
{
    public class Category
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }
    }
}
