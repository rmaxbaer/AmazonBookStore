using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string  Title { get; set; }
        [Required]
        public string AuthorFirstName { get; set; }
        public string AuthorMiddleName { get; set; }
        [Required]
        public string AuthorLastName { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        [RegularExpression("^[0-9]{3}-[0-9]{9}", ErrorMessage = "ISBN must be in the format XXX-XXXXXXXXX")]
        public string ISBN { get; set; }
        [Required]
        public string Classification { get; set; }
        [Required]
        public string  Category { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int NumPages { get; set; }

        //retrieves the name of the author with correct spacing whether or not there is a middle name
        public string GetName()
        {
            string name = this.AuthorFirstName;
            if (this.AuthorMiddleName != "")
            {
                name += " " + this.AuthorMiddleName;
            }
            name += " " + this.AuthorLastName;
            return name;
        }
    }
}
