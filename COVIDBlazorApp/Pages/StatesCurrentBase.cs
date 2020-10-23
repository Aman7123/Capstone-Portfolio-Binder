using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
//using Microsoft.Extensions.Configuration;

namespace BlazorApp1.Pages
{
    public class StatesCurrentBase : ComponentBase
    {
        protected StateForm stateForm = new StateForm();
        protected string stateCode;
        protected StateData[] currentStates;
        protected List<StateData> displayStates;
        protected string startDate, exception, endPoint;
        protected override async Task OnInitializedAsync()
        {
            try
            {
                string CurrentStatesEndpoint = "https://api.covidtracking.com/v1/states/current.json";
                endPoint = CurrentStatesEndpoint;
                HttpClient httpClient = new HttpClient();
                currentStates = await httpClient.GetFromJsonAsync<StateData[]>(endPoint);
                exception = "";
                PopulateCustomFields(currentStates);
                PopulateDates(currentStates);
                PopulateDisplay(currentStates);
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
                if (!state.state.Equals("VI") && !state.state.Equals("AS")) //exclude virgin islands & American Samoa
                {
                    displayStates.Add(state);
                }
            }
        }
        protected void PopulateDisplay(StateData state)
        {
            displayStates = new List<StateData>();
            displayStates.Add(state);
        }
        protected void PopulateCustomFields(StateData[] us)
        {
            for (int i = 0; i < us.Length; i++)
            {
                int date = us[i].date;
                string lastUpdateET = us[i].lastUpdateEt;
                DateTime dt = DateTime.Parse(lastUpdateET); //GetDTFromInt(date);
                if (dt != null)
                {
                    us[i].dateTime = dt;
                    us[i].displayDate = GetStringFromDT(dt);
                }
                else
                {
                    us[i].dateTime = DateTime.Now;
                    us[i].displayDate = "N/A";
                }
            }
        }
        protected void PopulateDates(StateData[] us)
        {
            int len = us.Length;
            if (len > 0)
            {
                startDate = us[0].dateTime.ToString("dddd, dd MMMM yyyy");
            }
        }
        protected DateTime GetDTFromInt(int date)
        {
            int day = date % 100;
            int mon = (date / 100) % 100;
            int year = date / 10000;
            return new DateTime(year, mon, day); ;
        }
        protected string GetStringFromDT(DateTime dt)
        {
            return dt.ToString("MM/dd/yyyy");
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
            stateCode = stateForm.StateCode;
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
            //stateForm = new StateForm();
        }
    }
}
