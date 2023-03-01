using LibraryManagement.Data;
using LibraryManagement.Interfaces;
using LibraryManagement.Models;
using System.Net;

namespace LibraryManagement.Repositories
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly DataContext _context;
        public ReviewerRepository(DataContext context)
        {
            _context = context;
        }

        public Reviewer GetReviewer(int id)
        {
            return _context.Reviewers.Where(
                r => r.Id == id).FirstOrDefault();
        }

        public ICollection<Reviewer> GetReviewers()
        {
            return _context.Reviewers.ToList();
        }

        public ICollection<Review> GetReviewsByReviewerId(int reviewerId)
        {
            return _context.Reviewers.Where(
                r => r.Id == reviewerId)
                .Select(b => b.Reviews)
                .First();
        }

        public bool ReviewerExists(int id)
        {
            return _context.Reviewers.Any(r => r.Id == id);
        }
    }
}
