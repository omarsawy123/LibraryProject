using AutoMapper;
using LibraryDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    public class BookProfile:Profile
    {
        public BookProfile()
        {
            CreateMap<Book,EditBookModel>();
            CreateMap<EditBookModel, Book>();

        }
    }
}
