using LibraryDataBase;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LibraryApp.services
{
    public class LocationServices : ILocationServices
    {
        private readonly HttpClient httpClient;

        public LocationServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Location> AddLocation(Location newLocation)
        {
            return await httpClient.PostJsonAsync<Location>("locations",newLocation);
        }

        public async Task DeleteLocation(int id)
        {
           await httpClient.DeleteAsync($"locations/{id}");
        }

        public async Task<Location> GetLocation(int id)
        {
            return await httpClient.GetJsonAsync<Location>($"locations/{id}");
        }

        public async Task<IEnumerable<Location>> GetLocations()
        {
            return await httpClient.GetJsonAsync<Location[]>("locations");

        }

        public async Task<Location> UpdateLocation(Location updatedLocation)
        {
            return await httpClient.PutJsonAsync<Location>("locations",updatedLocation);
        }
    }
}
