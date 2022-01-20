using Microsoft.AspNetCore.Identity;

namespace DBook.Data.Entity
{
    public class Book
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string PublisherId { get; set; }
        public IdentityUser Publisher { get; set; }
    }
}
