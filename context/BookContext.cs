using DBook.context.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBook.context
{
    public class BookContext:IdentityDbContext<User>
    {
        private IConfiguration conf;

        public BookContext(IConfiguration _conf)
        {
            conf = _conf;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            base.OnConfiguring(builder);
            builder.UseSqlServer(conf["ConnectionStrings:DBook"]);
        }

    }
}
