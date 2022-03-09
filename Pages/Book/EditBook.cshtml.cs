using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using DBook.Data;
using DBook.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DBook.Pages.Book
{
    [Authorize]
    public class EditBookModel : PageModel
    {
        readonly ApplicationDbContext _ctx;
        readonly IMapper _mapper;

        public EditBookModel(ApplicationDbContext context,IMapper mapper)
        {
            _ctx = context;
           _mapper = mapper;
        }

        [BindProperty(SupportsGet = true)]
        public BookModel Book { set; get; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var book = await _ctx.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book == null)
                return NotFound();
            if (book.PublisherId != userId)
            {
                return BadRequest("You are not authorize to edit");
            }

            Book = _mapper.Map<Data.Entity.Book, BookModel>(book);
            
            return Page();
        }
       
        public IActionResult OnPostAsync()
        {
            var book = _mapper.Map<BookModel, Data.Entity.Book>(Book);

             _ctx.Books.Update(book);
             _ctx.SaveChanges();

             return RedirectToPage("/");
        }
    }
}
