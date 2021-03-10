using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Infrastructure;
using Amazon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Amazon.Pages
{
    public class BuyModel : PageModel
    {
        private IAmazonRepository repository;

        //CH9: add cartSerive parameter 
        public BuyModel(IAmazonRepository repo, Cart cartService)
        {
            repository = repo;
            //CH9: add cartSerive parameter 
            Cart = cartService;
        }

        public Cart Cart {get; set;}
        public string ReturnUrl { get; set; }
        
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long bookId, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(p => p.BookId == bookId);
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart(); // Should this be here??
            Cart.AddItem(book, 1);
            //HttpContext.Session.SetJson("cart", Cart); // Should this be here??
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        //CH9: This is the function to remove an item

        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(p =>
                p.Book.BookId == bookId).Book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
