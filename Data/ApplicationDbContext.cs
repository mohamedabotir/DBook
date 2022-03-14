using System.Collections.Generic;
using DBook.Data.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DBook.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public string Favor { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Request> Requests { set; get; }
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Request>().HasOne<User>(u => u.OwnerUser)
                .WithMany(e => e.Requests).HasForeignKey(e => e.OwnerUserId).OnDelete(DeleteBehavior.Restrict);
             base.OnModelCreating(builder);
        }
    }
}
