using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    public class EditLocationModel
    {
        public int id { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required]
        public string LibraryName { get; set; }

        public string PhotoPath { get; set; }
    }
}
