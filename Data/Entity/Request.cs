using System;
using System.ComponentModel.DataAnnotations;

namespace DBook.Data.Entity
{
    public class Request
    {
        public int Id { get; set; }
        [Required]
        public string RequireUserId { set; get; }
        public User RequireUser { get; set; }
        [Required]
        public string OwnerUserId { get; set; }
        public User OwnerUser { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
        public DateTime RequestDateTime { get; set; }
    }
}
