using LibraryDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.services
{
    public interface ILocationServices
    {
        Task<IEnumerable<Location>> GetLocations();
        Task<Location> GetLocation(int id);
        Task<Location> UpdateLocation(Location updatedLocation);
        Task<Location> AddLocation(Location newLocation);
        Task DeleteLocation(int id);
        

    }
}
