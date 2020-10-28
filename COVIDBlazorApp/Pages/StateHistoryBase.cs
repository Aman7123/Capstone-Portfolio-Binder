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
        private string stateCode = "VA";
        private const int dayAmt = 10;
        private StateData[] historicState;
        protected List<StateMetaData> stateMetaData { get; set; }
        protected StateForm stateForm = new StateForm();
        protected List<StateData> displayData;      
        protected override async Task OnInitializedAsync()
        {
            stateMetaData = await restClient.GetStateMetaData();
            await LoadData(stateCode);
            PopulateDisplay(historicState);
            PopulateForm(historicState);
        }
        private async Task LoadData(string stateCode)
        {
            historicState = await restClient.GetHistoricState(stateCode);
        }
        private void PopulateDisplay(StateData[] state)
        {
            displayData = new List<StateData>();
            for (int i = 0; i < dayAmt; i++)
            {
                StateData data = state[i];
                displayData.Add(data);
            }
        }
        private void PopulateDisplay(StateData[] state, DateTime start, DateTime stop)
        {
            displayData = new List<StateData>();
            for (int i = 0; i < state.Length; i++)
            {
                StateData data = state[i];
                DateTime date = data.dateTime;
                if (date <= stop && date >= start)
                {
                    displayData.Add(data);
                }
            }
        }
        private void PopulateForm(StateData[] state)
        {
            int len = state.Length;
            if (len >= dayAmt)
            {
                stateForm.StartDate = state[(dayAmt - 1)].dateTime;
                stateForm.StopDate = state[0].dateTime;
                stateForm.StateCode = stateCode;
            }
        }
        protected async Task UpdateParameters()
        {
            if (!stateCode.Equals(stateForm.StateCode))
            {
                stateCode = stateForm.StateCode;
                await LoadData(stateCode);
            }
            PopulateDisplay(historicState, stateForm.StartDate, stateForm.StopDate);
        }
    }
}
