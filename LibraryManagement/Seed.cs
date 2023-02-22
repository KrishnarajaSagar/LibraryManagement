using LibraryManagement.Data;
using LibraryManagement.Models;

namespace LibraryManagement
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        
        public void SeedDataContext()
        {
            if(!dataContext.BookCategories.Any())
            {
                var bookCategories = new List<BookCategory>()
                {
                    new BookCategory()
                    {
                        Book = new Book()
                        {
                            Name = "ABCD",
                            Reader = new Reader() 
                            { 
                                Name = "POIU",
                                BirthDate = new DateTime(1990,1,1)
                            },
                            Reviews= new List<Review>()
                            {
                                new Review()
                                {
                                    Title = "ABCD Best",
                                    Text = "The best",
                                    Reviewer = new Reviewer()
                                    {
                                        Name = "KidReader"
                                    }
                                },
                                new Review()
                                {
                                    Title = "ABCD Good one",
                                    Text = "Very good book",
                                    Reviewer = new Reviewer()
                                    {
                                        Name = "Bookworm"
                                    }
                                }
                            },
                        },
                        Category = new Category()
                        {
                            Name = "Sci-fi"
                        }
                    },
                    new BookCategory()
                    {
                        Book = new Book()
                        {
                            Name = "ZXCV",
                            Reader = new Reader()
                            {
                                Name = "MNBV",
                                BirthDate = new DateTime(1993,2,3)
                            },
                            Reviews= new List<Review>()
                            {
                                new Review()
                                {
                                    Title = "ZXCV Best",
                                    Text = "The best",
                                    Reviewer = new Reviewer()
                                    {
                                        Name = "Conqueror"
                                    }
                                },
                                new Review()
                                {
                                    Title = "ZXCV Good one",
                                    Text = "Very very good book",
                                    Reviewer = new Reviewer()
                                    {
                                        Name = "QWERTY"
                                    }
                                }
                            }
                        },
                        Category = new Category()
                        {
                            Name = "Mystery"
                        }
                    },
                };
                dataContext.BookCategories.AddRange(bookCategories);
                dataContext.SaveChanges();
            }
        }
    }
}
