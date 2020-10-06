using LibraryApp.services;
using LibraryDataBase;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Pages
{
    public class BookDetailsBase:ComponentBase
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        IBookServices BookServices { get; set; }

        public Book book { get; set; } = new Book();

        protected async override Task OnInitializedAsync()
        {
            book = await BookServices.GetBook(int.Parse(Id));
            
        }
    }
}
