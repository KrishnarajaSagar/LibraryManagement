﻿using LibraryManagement.Data;
using LibraryManagement.Interfaces;
using LibraryManagement.Models;

namespace LibraryManagement.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;

        public ReviewRepository(DataContext context)
        {
            _context = context;
        }

        public Book GetBookByReviewId(int reviewId)
        {
            return _context.Reviews.Where(
                r => r.Id == reviewId)
                .Select(r => r.Book)
                .First();
        }

        public Review GetReview(int id)
        {
            return _context.Reviews.Where(
                r => r.Id == id)
                .FirstOrDefault();
        }

        public Reviewer GetReviewerByReviewId(int reviewId)
        {
            return _context.Reviews.Where(
                r => r.Id == reviewId)
                .Select(r => r.Reviewer)
                .First();
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }

        public bool ReviewExists(int id)
        {
            return _context.Reviews.Any(r => r.Id == id);
        }
    }
}
