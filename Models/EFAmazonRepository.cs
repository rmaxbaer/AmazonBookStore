using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Models
{
    public class EFAmazonRepository : IAmazonRepository
    {
        private AmazonDbContext _context;
        //Constructor
        public EFAmazonRepository (AmazonDbContext context)
        {
            _context = context;
        }
        public IQueryable<Book> Books => _context.Books;
    }
}
