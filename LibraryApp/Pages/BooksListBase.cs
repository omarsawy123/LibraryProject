using LibraryApp.services;
using LibraryDataBase;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryApp.Pages
{
    public class BooksListBase : ComponentBase
    {
        [Inject]
        public IBookServices BookServices { get; set; }

        [Inject]
        public ILocationServices LocationServices { get; set; }

        public IEnumerable<Location> Locations { get; set; }

        public IEnumerable<Book> Books { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Books = (await BookServices.GetBooks()).ToList();
            Locations = (await LocationServices.GetLocations()).ToList();


        }




    }
}
