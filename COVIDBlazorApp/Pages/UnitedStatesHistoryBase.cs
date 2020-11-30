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
        protected USData[] usData;
        protected List<USData> displayData;
        protected USForm usForm = new USForm();
        protected override async Task OnInitializedAsync()
        {
            usData = await restClient.GetUnitedStatesHistory();
            usForm.StartDate = DateTime.Now - new TimeSpan(30, 0, 0, 0);
            usForm.StopDate = DateTime.Now - new TimeSpan(1, 0, 0, 0);
            PopulateDisplay();
        }
        protected void PopulateDisplay()
        {
            displayData = new List<USData>();
            for (int i = 0; i < usData.Length; i++)
            {
                USData us = usData[i];
                if (us.dateTime >= usForm.StartDate && us.dateTime <= usForm.StopDate)
                {
                    displayData.Add(us);
                }
            }
        }
        protected void UpdateParameters()
        {
            PopulateDisplay();
        }
    }
}
