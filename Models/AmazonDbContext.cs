using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Models
{
    //This is the main file for connecting our app to the database
    public class AmazonDbContext : DbContext
    {
        public AmazonDbContext (DbContextOptions<AmazonDbContext> options) : base (options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
