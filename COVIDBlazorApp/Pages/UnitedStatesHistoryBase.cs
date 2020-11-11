using BlazorApp1.Models;
using BlazorApp1.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Pages
{
    public class UnitedStatesHistoryBase : ComponentBase
    {
        [Inject]
        private ICOVIDDataService restClient { get; set; } //COVIDDataService              
        protected List<USData> usData;                
        protected override async Task OnInitializedAsync()
        {
            usData = await restClient.GetHistoricUnitedStates();
        }
    }
}
