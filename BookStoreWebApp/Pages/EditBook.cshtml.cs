using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookStoreWebApp.Data;
using BookStoreWebApp.Models;

namespace BookStoreWebApp.Pages
{
    public class EditBookModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditBookModel(AppDbContext context)
        {
            _context = context;
        }

        public Book Book { get; set; } = new Book();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Book? book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return RedirectToPage("Books");
            }
            Book = book;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int Id, string Title, string Author, int Pages, decimal Price)
        {
            Book? book = await _context.Books.FindAsync(Id);
            if (book == null)
            {
                return RedirectToPage("Books");
            }

            book.Title = Title;
            book.Author = Author;
            book.Pages = Pages;
            book.Price = Price;

            await _context.SaveChangesAsync();

            return RedirectToPage("Books");
        }
    }
}
