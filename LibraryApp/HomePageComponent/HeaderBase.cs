using LibraryApp.services;
using LibraryDataBase;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.HomePageComponent
{
    public class HeaderBase:ComponentBase
    {
        [Inject]
        public IBookServices BookServices { get; set; }

        public List<Book> BookList { get; set; } = new List<Book>();

        public string SearchTerm { get; set; } = "";

        public string ShowMenu { get; set; } = "";

        public List<Book> Found { get; set; } = new List<Book>();

        protected override async Task OnInitializedAsync()
        {
            BookList = (await BookServices.GetBooks()).ToList();

        }

        
     
        


    }
}
