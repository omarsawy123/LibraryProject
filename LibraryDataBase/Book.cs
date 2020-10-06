using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryDataBase
{
    public class Book
    {
        
        public int id { get; set; }
        
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [MinLength(2)]
        public string Author { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string PhotoPath { get; set; }
        [Required]
        public int locationId { get; set; }

        public Location Location { get; set; }

    }
}
