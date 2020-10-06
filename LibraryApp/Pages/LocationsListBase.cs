using LibraryApp.services;
using LibraryDataBase;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Pages
{
    public class LocationsListBase:ComponentBase
    {
        [Inject]
        public ILocationServices LocationServices { get; set; }

        public IEnumerable<Location> Locations { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Locations = await LocationServices.GetLocations();
        }

    }
}





