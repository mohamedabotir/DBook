using Microsoft.AspNetCore.Identity;

namespace DBook.Data.Entity
{
    public class Book
    {
        public int Id { get; set; }
        
        public string Author { get; set; }
        public string PublisherName { get; set; }
        public string PublisherId { get; set; }
        public IdentityUser Publisher { get; set; }
        public string BookName { get; set; }
        public string ImageUrl { get; set; }
    }
}
