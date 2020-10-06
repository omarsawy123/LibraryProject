using AutoMapper;
using LibraryDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    public class LocationProfile:Profile
    {
        public LocationProfile()
        {
            CreateMap<EditLocationModel, Location>();
            CreateMap<Location, EditLocationModel>();

        }
    }
}
