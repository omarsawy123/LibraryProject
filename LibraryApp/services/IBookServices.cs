using LibraryDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.services
{
    public interface IBookServices
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBook(int id);
        Task<Book> UpdateBook(Book updatedBook);
        Task<Book> AddBook(Book newBook);
        Task DeleteBook(int id);

    }
}
