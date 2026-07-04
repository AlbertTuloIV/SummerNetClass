using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookStoreWebApp.Data;
using BookStoreWebApp.Models;

namespace BookStoreWebApp.Pages
{
    public class NewBookModel : PageModel
    {
        private readonly AppDbContext _context;

        public NewBookModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string Title, string Author, int Pages, decimal Price)
        {
            Book book = new Book
            {
                Title = Title,
                Author = Author,
                Pages = Pages,
                Price = Price
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return RedirectToPage("Books");
        }
    }
}
