using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookStoreWebApp.Data;
using BookStoreWebApp.Models;

namespace BookStoreWebApp.Pages
{
    public class DeleteBookModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteBookModel(AppDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int Id)
        {
            Book? book = await _context.Books.FindAsync(Id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("Books");
        }
    }
}
