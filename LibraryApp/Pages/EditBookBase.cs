using LibraryApp.services;
using LibraryDataBase;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorLibraryClass;
using BlazorInputFile;
using AutoMapper;
using LibraryApp.Models;
using Microsoft.AspNetCore.Http;

namespace LibraryApp.Pages
{
    public class EditBookBase:ComponentBase
    {
        [Inject]
        IBookServices BookServices { get; set; }

        [Inject]
        IFileUpload FileUpload { get; set; }

        [Inject]
        ILocationServices LocationServices { get; set; }

        [Parameter]
        public string Id { get; set; }

        public IFileListEntry file { get; set; }

        public string HeaderText { get; set; } = "Add new book";

        public string LocationId { get; set; }
        public List<Location> Locations { get; set; } = new List<Location>();
        public Book Book { get; set; } = new Book();

        protected ConfirmBase DeleteConfirmation { get; set; }

        public EditBookModel EditBookModel { get; set; } = new EditBookModel();

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        protected async override Task OnInitializedAsync()
        {
            int.TryParse(Id, out int bookId);
            if (bookId != 0)
            {
                Book = await BookServices.GetBook(int.Parse(Id));
                HeaderText = "Edit Book";
            }
            else
            {
                Book = new Book
                {
                    locationId = 1,
                    Category = 0,
                    PhotoPath = "images/5.png"
                };
            }
            Locations = (await LocationServices.GetLocations()).ToList();

            Mapper.Map(Book, EditBookModel);
        }
        protected async Task HandleValidSubmit()
        {
            if (file != null)
            {
                EditBookModel.PhotoPath = await FileUpload.Upload(file, EditBookModel);

            }

            Mapper.Map(EditBookModel, Book);
            
            Book result = null;
            if (Book.id != 0)
            {
                result = await BookServices.UpdateBook(Book);
                
            }
            else
            {
                result = await BookServices.AddBook(Book);
            }

            if (result != null)
            {
                Navigation.NavigateTo("/Books");
            }
        }
    
    
        protected void Delete_Click()
        {
            DeleteConfirmation.Show("Book");
        }

        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await BookServices.DeleteBook(Book.id);
                Navigation.NavigateTo("Books");
            }
        }

        protected void HandleSelectedFile(IFileListEntry[] files)
        {
            file = files.FirstOrDefault();

            
        }
    
    }
}










