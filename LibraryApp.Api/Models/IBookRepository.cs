using System;
using System.Collections.Generic;
using System.Linq;
using LibraryDataBase;
using System.Threading.Tasks;

namespace LibraryApp.Api.Models
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBook(int BookId);
        Task<Book> AddBook(Book newBook);
        Task<Book> CheckIfBookExists(Book existingBook);
        Task<Book> EditBook(Book editBook);
        Task<Book> DeleteBook(int BookId);
        Task<IEnumerable<Book>> SearchBook(string name);
    }
}
