using BlazorApp1.Models;
using BlazorApp1.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Pages
{
    public class StateHistoryBase : ComponentBase
    {
        [Inject]
        private ICOVIDDataService restClient { get; set; } //COVIDDataService        
        private string stateCode = "NY";        
        protected List<StateData> states;
        protected List<StateMetaData> stateMetaData { get; set; }
        protected StateForm stateForm = new StateForm();        
        protected override async Task OnInitializedAsync()
        {
            stateMetaData = await restClient.GetStateMetaData();            
            await LoadData(stateCode);
            stateForm.StateCode = stateCode;
        }
        private async Task LoadData(string stateCode)
        {
            states = await restClient.GetHistoricState(stateCode);
        }
        protected async Task UpdateParameters()
        {
            if (!stateCode.Equals(stateForm.StateCode))
            {
                stateCode = stateForm.StateCode;
                await LoadData(stateCode);
            }            
        }
    }
}
