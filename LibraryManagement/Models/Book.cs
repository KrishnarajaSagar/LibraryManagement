namespace LibraryManagement.Models
{
    public class Book
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Reader? Reader { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<BookCategory>? BookCategories { get; set; }
    }
}
