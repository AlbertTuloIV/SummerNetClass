using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookStoreWebApp.Data;
using BookStoreWebApp.Models;

namespace BookStoreWebApp.Pages
{
    public class BooksModel : PageModel
    {
        private readonly AppDbContext _context;

        public BooksModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Book> Books { get; set; } = new List<Book>();

        public async Task OnGetAsync()
        {
            Books = await _context.Books.ToListAsync();
        }
    }
}
