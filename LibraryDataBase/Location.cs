using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Authentication;
using System.Text;

namespace LibraryDataBase
{
    public class Location
    {
        public int id { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required]
        public string LibraryName { get; set; }

        public string PhotoPath { get; set; }
    }
}
