using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Identity;

namespace DBook.Data.Entity
{
    public class User : IdentityUser
    {
        public ICollection<Request> Requests { get; set; }
        public ICollection<Request> Receives { set; get; }

        public User()
        {
            Requests = new List<Request>();
            Receives = new List<Request>();
        }
    }
}
