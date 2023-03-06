namespace LibraryManagement.Models
{
    public class Review
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Text { get; set; }
        public Reviewer? Reviewer { get; set; }
        public Book Book { get; set; }
    }
}
