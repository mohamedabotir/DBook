using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DBook.Data;
using DBook.Models;
using DBook.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DBook.Pages.Book
{
    public class BooksModel : PageModel
    {
        private ApplicationDbContext _ctx;
        private IMapper _mapper;
       
        
        public ILookup<string, Data.Entity.Book> books { set; get; }

        public BooksModel(ApplicationDbContext context,IMapper mapper)
        {
            _ctx = context;
            _mapper=mapper;
           
        }
        public IEnumerable<BookModel> Books { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
              var result = await _ctx.Books.Select(x=>x).ToListAsync();
               Books = _mapper.Map<IEnumerable<Data.Entity.Book>, IEnumerable<BookModel>>(result);
               books =   _ctx.Books.Select(e => e).ToLookup(e => e.PublisherId);
               var userId = User.GetUserId();
               ViewData["success"] = "no";
            return Page();
        }

         
        public IActionResult OnPost(int id)
        {
           var book = _ctx.Books.FirstOrDefault(x=>x.Id==id);
           var userId = User.GetUserId();
          if (book == null)
               return NotFound();
          if (userId != book.PublisherId)
          {
                ViewData["success"] = false;
                return RedirectToPage("/Book/books");
          }

          _ctx.Books.Remove(book);
            _ctx.SaveChanges();
            ViewData["success"] = true;
            return RedirectToPage("/Book/books");
        }

        public async Task<IActionResult> OnRequestAsync(BookModel model)
        {
            return Page();
        }

    }
}
