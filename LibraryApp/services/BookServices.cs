using LibraryDataBase;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LibraryApp.services
{
    public class BookServices : IBookServices
    {
        private readonly HttpClient httpClient;

        public BookServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Book> AddBook(Book newBook)
        {
            return await httpClient.PostJsonAsync<Book>("books",newBook);
        }

        public async Task DeleteBook(int id)
        {
            await httpClient.DeleteAsync($"books/{id}");
        }

        public async Task<Book> GetBook(int id)
        {
            return await httpClient.GetJsonAsync<Book>($"books/{id}");
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await httpClient.GetJsonAsync<Book[]>("books");
        }

        public async Task<Book> UpdateBook(Book updatedBook)
        {
            return await httpClient.PutJsonAsync<Book>("books",updatedBook);
        }
    }
}
