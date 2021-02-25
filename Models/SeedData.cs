using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Models
{
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            AmazonDbContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<AmazonDbContext>();
            
            //Check if there are changes to be made and if so, migrate them
            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            //If the database is empty, we put in some data to start with 
            if(!context.Books.Any())
            {
                context.Books.AddRange(
                    
                    new Book
                    {
                        Title = "Les Miserables",
                        AuthorFirstName = "Victor",
                        AuthorMiddleName = "", // or should this be null?
                        AuthorLastName = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 9.95m,
                        NumPages = 1488
                    },

                    new Book
                    {
                        Title = "Team of Rivals",
                        AuthorFirstName = "Doris",
                        AuthorMiddleName = "Kearns", // or should this be null?
                        AuthorLastName = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 14.58m,
                        NumPages = 944
                    },

                    new Book
                    {
                        Title = "The Snowbal",
                        AuthorFirstName = "Alic",
                        AuthorMiddleName = "", // or should this be null?
                        AuthorLastName = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 21.54m,
                        NumPages = 832
                    },

                     new Book
                     {
                         Title = "American Ulysses",
                         AuthorFirstName = "Ronald",
                         AuthorMiddleName = "C.", // or should this be null?
                         AuthorLastName = "White",
                         Publisher = "Random House",
                         ISBN = "978-0812981254",
                         Classification = "Non-Fiction",
                         Category = "Biography",
                         Price = 11.61m,
                         NumPages = 864
                     },

                    new Book
                    {
                        Title = "Unbroken",
                        AuthorFirstName = "Laura",
                        AuthorMiddleName = "", // or should this be null?
                        AuthorLastName = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = 13.33m,
                        NumPages = 528
                    },

                     new Book
                     {
                         Title = "The Great Train Robbery",
                         AuthorFirstName = "Michael",
                         AuthorMiddleName = "", // or should this be null?
                         AuthorLastName = "Crichton",
                         Publisher = "Vintage",
                         ISBN = "978-0804171281",
                         Classification = "Fiction",
                         Category = "Historical Fiction",
                         Price = 15.95m,
                         NumPages = 288
                     },
                    
                     new Book
                     {
                         Title = "Deep Work",
                         AuthorFirstName = "Cal",
                         AuthorMiddleName = "", // or should this be null?
                         AuthorLastName = "Newport",
                         Publisher = "Grand Central Publishing",
                         ISBN = "978-1455586691",
                         Classification = "Non-Fiction",
                         Category = "Self-Help",
                         Price = 14.99m,
                         NumPages = 304
                     },

                     new Book
                     {
                         Title = "It's Your Ship",
                         AuthorFirstName = "Michael",
                         AuthorMiddleName = "", // or should this be null?
                         AuthorLastName = "Abrashoff",
                         Publisher = "Grand Central Publishing",
                         ISBN = "978-1455523023",
                         Classification = "Non-Fiction",
                         Category = "Self-Help",
                         Price = 21.66m,
                         NumPages = 240
                     },

                     new Book
                     {
                         Title = "The Virgin Way",
                         AuthorFirstName = "Richard",
                         AuthorMiddleName = "", // or should this be null
                         AuthorLastName = "Branson",
                         Publisher = "Portfolio",
                         ISBN = "978-1591847984",
                         Classification = "Non-Fiction",
                         Category = "Business",
                         Price = 29.16m,
                         NumPages = 400
                     },

                     new Book
                     {
                         Title = "Sycamore Row",
                         AuthorFirstName = "John",
                         AuthorMiddleName = "", // or should this be null?
                         AuthorLastName = "Grisham",
                         Publisher = "Bantam",
                         ISBN = "978-0553393613",
                         Classification = "Fiction",
                         Category = "Thrillers",
                         Price = 15.03m,
                         NumPages = 642
                     }, 
                     
                     new Book
                     {
                         Title = "Where the Wild Things Are",
                         AuthorFirstName = "Maurice",
                         AuthorMiddleName = "",
                         AuthorLastName = "Sendak",
                         Publisher = "HarperCollins",
                         ISBN = "978-0061656842",
                         Classification = "Fiction",
                         Category = "Action and Adventure",
                         Price = 4.89m,
                         NumPages = 38
                     },

                     new Book
                     {
                         Title = "Hop on Pop",
                         AuthorFirstName = "Dr.",
                         AuthorMiddleName = "",
                         AuthorLastName = "Seuss",
                         Publisher = "Random House",
                         ISBN = "978-0001713093",
                         Classification = "Fiction",
                         Category = "Children's Literature",
                         Price = 3.50m,
                         NumPages = 24
                     },

                      new Book
                      {
                          Title = "Where the Sidewalk Ends",
                          AuthorFirstName = "Shell",
                          AuthorMiddleName = "",
                          AuthorLastName = "Silverstein",
                          Publisher = "HarperCollins",
                          ISBN = "978-0060256678",
                          Classification = "Fiction",
                          Category = "Poetry",
                          Price = 5.06m,
                          NumPages = 166
                      }

                );

                context.SaveChanges();
            }
        }
    }
}
