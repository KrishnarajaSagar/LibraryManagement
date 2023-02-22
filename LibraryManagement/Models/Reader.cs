namespace LibraryManagement.Models
{
    public class Reader
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
