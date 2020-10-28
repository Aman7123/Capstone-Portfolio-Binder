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
        private StateData[] currentStates;
        protected List<StateMetaData> stateMetaData { get; set; }          
        protected List<StateData> displayStates { get; set; }
        protected StateForm stateForm = new StateForm();
        protected string todaysDate;
        protected override async Task OnInitializedAsync()
        {
            stateForm.StateCode = "All";
            stateMetaData = await restClient.GetStateMetaData();
            currentStates = await restClient.GetCurrentStates();
            if(currentStates.Length > 0)
            {
                todaysDate = currentStates[0].dateTime.ToString("dddd, dd MMMM yyyy");
                PopulateDisplay(currentStates);
            }                
        }
        protected void PopulateDisplay(StateData[] states)
        {
            displayStates = new List<StateData>();
            foreach (var state in states)
            {
                if (!state.dataQualityGrade.Equals("D") && !state.dataQualityGrade.Equals("F")) //exclude low quality data
                {
                    displayStates.Add(state);
                }
            }
        }
        protected void PopulateDisplay(StateData state)
        {
            displayStates = new List<StateData> { state };
        }
        protected StateData GetSingleState(string stateCode)
        {
            foreach (var state in currentStates)
            {
                if (state.state.Equals(stateCode))
                {
                    return state;
                }
            }
            return null;
        }
        protected void ChooseState()
        {
            string stateCode = stateForm.StateCode;
            stateCode = stateCode.ToUpper();
            StateData sd = GetSingleState(stateCode);
            if (sd != null)
            {
                PopulateDisplay(sd);
            }
            else if (stateCode.Equals("ALL"))
            {
                PopulateDisplay(currentStates);
            }            
        }
    }
}
