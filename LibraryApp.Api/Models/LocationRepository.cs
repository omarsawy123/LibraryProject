using LibraryDataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Api.Models
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext appDb;

        public LocationRepository(AppDbContext appDb)
        {
            this.appDb = appDb;
        }
        public async Task<Location> AddLocation(Location newLocation)
        {
            var result = await appDb.Locations.AddAsync(newLocation);
            await appDb.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Location> CheckIfLocationExists(string libraryname)
        {
            return await appDb.Locations.FirstOrDefaultAsync(e => e.LibraryName == libraryname);
        }

        public async Task<Location> DeleteLocation(int locationId)
        {
            var result = await appDb.Locations.FirstOrDefaultAsync(e => e.id == locationId);
            if (result != null)
            {
                appDb.Remove(result);
                await appDb.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Location> EditLocation(Location editLocation)
        {
            var result = await appDb.Locations.FirstOrDefaultAsync(e => e.id == editLocation.id);
            
            appDb.Entry(result).CurrentValues.SetValues(editLocation);
            
            await appDb.SaveChangesAsync();
            
            return result;

            //result.CityName = editLocation.CityName;
            //result.LibraryName = editLocation.LibraryName;
        }

        public async Task<Location> GetLocation(int locationId)
        {
            return await appDb.Locations.FirstOrDefaultAsync(e => e.id == locationId);
        }

        public async Task<IEnumerable<Location>> GetLocations()
        {
            return await appDb.Locations.ToListAsync();
        }
    }
}
