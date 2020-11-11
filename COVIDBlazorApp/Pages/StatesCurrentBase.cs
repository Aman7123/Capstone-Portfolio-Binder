using BlazorApp1.Models;
using BlazorApp1.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Pages
{
    public class StatesCurrentBase : ComponentBase
    {
        [Inject]
        private ICOVIDDataService restClient { get; set; } //COVIDDataService        
        protected List<StateData> states;                  
        protected string todaysDate;
        protected override async Task OnInitializedAsync()
        {
            states = await restClient.GetCurrentStates();            
        }
    }
}
