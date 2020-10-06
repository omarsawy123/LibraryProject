using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RazorLibraryClass
{
    public class ConfirmBase:ComponentBase
    {

        public string objectName  { get; set; }
        protected bool ShowConfirmation { get; set; } 

        [Parameter]

        public EventCallback<bool> ConfirmationChanged { get; set; }

        public void Show(string objectName)
        {
            this.objectName = objectName;
            ShowConfirmation = true;
            StateHasChanged();
        }

        protected async Task OnConfirmationChanged(bool value)
        {
            ShowConfirmation = false;
            await ConfirmationChanged.InvokeAsync(value);
        }


    }
}
