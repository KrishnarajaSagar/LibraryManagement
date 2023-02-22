namespace LibraryManagement.Models
{
    public class Reviewer
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
