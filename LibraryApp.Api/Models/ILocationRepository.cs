using LibraryDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Api.Models
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetLocations();
        Task<Location> GetLocation(int locationId);
        Task<Location> CheckIfLocationExists(string libraryname);

        Task<Location> AddLocation(Location newLocation);
        Task<Location> EditLocation(Location editLocation);
        Task<Location> DeleteLocation(int locationId);

    }
}
