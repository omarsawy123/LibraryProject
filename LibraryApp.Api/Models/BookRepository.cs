using LibraryDataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Api.Models
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext appDb;

        public BookRepository(AppDbContext appDb)
        {
            this.appDb = appDb;
        }
        public async Task<Book> AddBook(Book newBook)
        {
            var result = await appDb.Books.AddAsync(newBook);
            await appDb.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Book> CheckIfBookExists(Book existingBook)
        {
            return await appDb.Books.FirstOrDefaultAsync(e => e.Name == existingBook.Name);
        }

        public async Task<Book> DeleteBook(int BookId)
        {
            var result = await appDb.Books.FirstOrDefaultAsync(e => e.id == BookId);
            if (result!=null)
            {
                appDb.Remove(result);
                await appDb.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Book> EditBook(Book editBook)
        {
            var result = await appDb.Books.FirstOrDefaultAsync(e => e.id == editBook.id);
            if (result != null)
            {

                appDb.Entry(result).CurrentValues.SetValues(editBook);

                //result.Name = editBook.Name;
                //result.Author = editBook.Author;
                //result.Category = editBook.Category;
                //result.Price = editBook.Price;
                //result.PhotoPath = editBook.PhotoPath;
                //result.locationId = editBook.locationId;

                await appDb.SaveChangesAsync();
                
                return result;
            }
            return null;
        }

        public async Task<Book> GetBook(int BookId)
        {
            return await appDb.Books
                .Include(e=>e.Location)
                .FirstOrDefaultAsync(e => e.id == BookId);
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await appDb.Books.ToListAsync();
        }

        public async Task<IEnumerable<Book>> SearchBook(string name)
        {
            IQueryable<Book> query = appDb.Books;

            if (!string.IsNullOrEmpty(name))
            {
                query =  query.Where(e => e.Name.Contains(name)); 
            }
            return await query.ToListAsync();

        }
    }
}
