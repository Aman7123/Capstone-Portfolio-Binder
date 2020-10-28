using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Pages
{
    public class StatesCurrentBase : ComponentBase
    {
        private COVIDRestClient restClient = new COVIDRestClient();
        private StateData[] currentStates;
        protected StateForm stateForm = new StateForm();        
        protected List<StateData> displayStates;
        protected string todaysDate, exception;
        protected override async Task OnInitializedAsync()
        {
            try
            {
                currentStates = await restClient.GetCurrentStates();
                if(currentStates.Length > 0)
                {
                    todaysDate = currentStates[0].dateTime.ToString("dddd, dd MMMM yyyy");
                    PopulateDisplay(currentStates);
                }                
                exception = "";
            }
            catch (Exception ex)
            {
                exception = ex.Message;
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
