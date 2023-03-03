using LibraryManagement.Models;

namespace LibraryManagement.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int id);
        Reviewer GetReviewerByReviewId(int reviewId);
        Book GetBookByReviewId(int reviewId);
        bool ReviewExists(int id);
        bool CreateReview(Review review);
        bool Save();
        bool UpdateReview(Review review);
    }
}
