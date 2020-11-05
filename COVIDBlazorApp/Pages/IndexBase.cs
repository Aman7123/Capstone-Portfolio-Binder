using BlazorApp1.Models;
using BlazorApp1.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        private ICOVIDDataService restClient { get; set; } //COVIDDataService      
        protected USData[] currentUS;
        protected override async Task OnInitializedAsync()
        {
            currentUS = await restClient.GetCurrentUnitedStates();                        
        }
    }
}
