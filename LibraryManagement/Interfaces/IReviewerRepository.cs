﻿using LibraryManagement.Models;

namespace LibraryManagement.Interfaces
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewer(int id);
        ICollection<Review> GetReviewsByReviewerId(int reviewerId);
        bool ReviewerExists(int id);
    }
}
