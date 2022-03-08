using System.Security.Claims;
using System.Threading.Tasks;
using DBook.Data;
using DBook.Data.Entity;
using DBook.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DBook.Pages
{
    [Authorize]
    public class CreateBookModel : PageModel
    {
        private ApplicationDbContext _ctx;

        public CreateBookModel(ApplicationDbContext context)
        {
            _ctx = context;
        }
       

        public void OnGet()
        {
            ViewData["success"] = false;
        }
        [BindProperty]
        public BookModel Model { set; get; }
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!ModelState.IsValid)
            {
                ViewData["success"] = false;
                return Page();
            }

            var book = new Book
            {
                Author = Model.Author,
                PublisherName = User.Identity?.Name,
                PublisherId = userId,
                BookName = Model.BookName,
                ImageUrl = Model.ImageUrl

            };
            await _ctx.Books.AddAsync(book);
            await _ctx.SaveChangesAsync();
            ViewData["success"] = true;
            ModelState.Clear();
            return Page();

        }

    }
}
