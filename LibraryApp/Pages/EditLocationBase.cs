using AutoMapper;
using LibraryApp.Models;
using LibraryApp.services;
using LibraryDataBase;
using Microsoft.AspNetCore.Components;
using RazorLibraryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Pages
{
    public class EditLocationBase:ComponentBase
    {

        [Inject]
        public ILocationServices LocationServices { get; set; }
        
        public Location Location { get; set; } = new Location();

        public EditLocationModel EditLocationModel { get; set; }

        public string HeaderText { get; set; }

        protected ConfirmBase DeleteConfirmation { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        protected async override Task OnInitializedAsync()
        {
            int.TryParse(Id, out int LocationId);

            if (LocationId != 0)
            {
                Location = await LocationServices.GetLocation(int.Parse(Id));
                HeaderText = "Edit Library";
            }
            else
            {
                Location =new Location
                {
                    CityName = "",
                    LibraryName = ""
                };
                HeaderText = "Add Library";

            }
            Mapper.Map(Location, EditLocationModel);
        }

        protected async Task HandleValidSubmit()
        {
            Mapper.Map(EditLocationModel, Location);

            Location result = null;

            if (Location.id != 0)
            {
                result = await LocationServices.UpdateLocation(Location);

            }
            else
            {
                result = await LocationServices.AddLocation(Location);
            }
            if (result != null)
            {
                Navigation.NavigateTo("/Libraries");
            }
        }

        
        // When the delete button is clicked call this 
        protected void Delete_Click()
        {
            DeleteConfirmation.Show("Library");
        }

        // When the user confirms the delete operation call this 
        protected async Task Confirm_DeleteClick(bool deleteconfirm)
        {
            if (deleteconfirm)
            {
                await LocationServices.DeleteLocation(Location.id);
                Navigation.NavigateTo("/Libraries");
            }
        }
    
    }
}
