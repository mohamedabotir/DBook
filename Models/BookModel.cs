using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DBook.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required]
        public string Author { get; set; }

        public string PublisherName { get; set; }
        public string PublisherId { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
