using LibraryApp.Api.Models;
using LibraryDataBase;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace LibraryApp.Api.Controllers
{
    [Route("/books")]
    [ApiController]
    public class BooksController:ControllerBase
    {
        private readonly IBookRepository bookRepository;
        private readonly IWebHostEnvironment hostingEnvironment;


        public BooksController(IBookRepository bookRepository,IWebHostEnvironment hostingEnvironment)
        {
            this.bookRepository = bookRepository;
            this.hostingEnvironment = hostingEnvironment;
        }
        
        

        [HttpGet]
        public async Task<ActionResult> GetBooks()
        {
            try
            {
                var result = await bookRepository.GetBooks();
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            try
            {
                var result = await bookRepository.GetBook(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }

        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(Book newBook)
        {
            
            try
            {
                if (newBook == null)
                {
                    return BadRequest();
                }
                var checkBook = await bookRepository.CheckIfBookExists(newBook);
                if (checkBook != null)
                {
                    ModelState.AddModelError("name",
                   "Error!,Book name already exists.. if you still want to add it please Update the existing Book First ");
                    return BadRequest(ModelState);
                }
                
                var result = await bookRepository.AddBook(newBook);
                return CreatedAtAction(nameof(GetBook), new { id = newBook.id }, newBook);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

       
        

        [HttpPut]
        public async Task<ActionResult<Book>> EditBook(Book editBook)
        {
            try
            {
                
                var updatedBook = await bookRepository.GetBook(editBook.id);
                if (updatedBook == null)
                {
                    return NotFound($"Book with ID {editBook.id} is not found");
                }
                return await bookRepository.EditBook(editBook);
            }
            catch (Exception)
            {

               return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            try
            {
                var result = await bookRepository.GetBook(id);
                if (result == null)
                {
                    return NotFound($"Book with ID {id} not found");
                }
                return await bookRepository.DeleteBook(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
           
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Book>>> SearchBooks(string name)
        {
            try
            {
                var result = await bookRepository.SearchBook(name);

                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound($"Book with name {name} not found");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}
