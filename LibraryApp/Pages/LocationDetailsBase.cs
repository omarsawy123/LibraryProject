using LibraryApp.services;
using LibraryDataBase;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace LibraryApp.Pages
{
    public class LocationDetailsBase:ComponentBase
    {
        [Inject]
        public ILocationServices LocationServices { get; set; }

        [Inject]

        public IBookServices BookServices { get; set; }

        [Parameter]
        public string Id { get; set; }

        public Location Location { get; set; } = new Location();
        public IEnumerable<Book> Books { get; set; } 

        public int count { get; set; } = 0;

        protected async override Task OnInitializedAsync()
        {
            Location = await LocationServices.GetLocation(int.Parse(Id));
            Books = (await BookServices.GetBooks()).ToList().Where(e => e.locationId == Location.id);

            await CountBooksNumber();
        }

        public async Task CountBooksNumber()
        {
            var books = await BookServices.GetBooks();
            count = books.Where(e => e.locationId == Location.id).Count();
 
            //var books = (await BookServices.GetBooks()).ToList();
            //foreach (var book in books)
            //{
            //    if (book.locationId==Location.id)
            //    {
            //        count++;
            //    }
            //}
            
        }

    }
}
