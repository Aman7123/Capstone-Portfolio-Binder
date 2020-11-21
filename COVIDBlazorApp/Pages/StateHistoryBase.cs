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
        protected StateData[] states;
        protected List<StateData> displayData;
        protected List<StateMetaData> stateMetaData { get; set; }
        protected StateForm stateForm = new StateForm();        
        protected override async Task OnInitializedAsync()
        {
            stateMetaData = await restClient.GetStateMetaData();
            stateForm.StateCode = stateCode;
            stateForm.StartDate = DateTime.Now - new TimeSpan(30,0,0,0);
            stateForm.StopDate = DateTime.Now - new TimeSpan(1, 0, 0, 0);
            await LoadData(stateCode);                                      
        }
        private async Task LoadData(string stateCode)
        {            
            states = await restClient.GetStateHistory(stateCode);
            PopulateDisplay();
        }
        protected async Task UpdateParameters()
        {
            if (!stateCode.Equals(stateForm.StateCode))
            {
                stateCode = stateForm.StateCode;
                await LoadData(stateCode);
            } else
            {                
                PopulateDisplay();
            }            
        }
        protected void PopulateDisplay()
        {
            displayData = new List<StateData>();            
            for(int i = 0; i < states.Length; i++)
            {
                StateData state = states[i];
                if(state.dateTime >= stateForm.StartDate && state.dateTime <= stateForm.StopDate)
                {
                    displayData.Add(state);
                } 
            }                           
        }
    }
}
