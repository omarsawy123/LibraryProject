using BlazorInputFile;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    public class EditBookModel
    {
        public int id { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [MinLength(2)]
        public string Author { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public int Price { get; set; }
        
        public string PhotoPath { get; set; }
        [Required]
        public int locationId { get; set; }
    }
}
