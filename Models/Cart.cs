using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        //CH9: I added the word virtual so that I can override the members
        //public void AddItem(Book book, int qty)
        public virtual void AddItem(Book book, int quantity)
        {
            //This is a query that returns one cart object (CartLine) to this variable named line
            //When they add an item, go out to the lines (the cart) and see if you can find that item already
            CartLine line = Lines
                //Add the one where the id of what they selected matches 
                .Where(p => p.Book.BookId == book.BookId)
                //grab the first one from that group
                .FirstOrDefault();

            if (line == null)
            {
                //If the query above returned nothing, make a new item
                Lines.Add(new CartLine
                {
                    Book = book,
                    Quantity = quantity
                });
            }
            //otherwise, update the qty
            else
            {
                line.Quantity += quantity;
            }

        }

        //Remove a specific book from cart (whole qty)
        //CH9: I added the word virtual so that I can override the members
        //public void RemoveLine(Book book) => Lines.RemoveAll(x => x.Book.BookId == book.BookId);

        public virtual void RemoveLine(Book book) => Lines.RemoveAll(x => x.Book.BookId == book.BookId);

        //Clear the whole cart
        //CH9: I added the word virtual so that I can override the members
        //public void Clear() => Lines.Clear();
        public virtual void Clear() => Lines.Clear();

        //Return total for each book
        public decimal ComputeTotalSum() => Lines.Sum(e => e.Book.Price * e.Quantity);


        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }
    }
}
