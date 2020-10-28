using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Pages
{
    public class UnitedStatesHistoryBase : ComponentBase
    {
        private COVIDRestClient restClient = new COVIDRestClient();
        private const int dayAmt = 10;
        private USData[] historicUS;
        protected USForm usForm = new USForm();
        protected List<USData> displayData;        
        protected override async Task OnInitializedAsync()
        {
            historicUS = await restClient.GetHistoricUnitedStates();
            PopulateDates(historicUS);
            PopulateDisplay(historicUS);
        }
        private void PopulateDisplay(USData[] us)
        {
            displayData = new List<USData>();
            for (int i = 0; i < dayAmt; i++)
            {
                USData data = us[i];
                displayData.Add(data);
            }
        }
        private void PopulateDisplay()
        {
            displayData = new List<USData>();
            DateTime start = usForm.StartDate;
            DateTime stop = usForm.StopDate;
            for (int i = 0; i < historicUS.Length; i++)
            {
                USData data = historicUS[i];
                DateTime date = data.dateTime;
                if (date <= stop && date >= start)
                {
                    displayData.Add(data);
                }
            }
        }
        private void PopulateDates(USData[] us)
        {
            if (us.Length >= dayAmt)
            {
                usForm.StartDate = us[(dayAmt - 1)].dateTime;
                usForm.StopDate = us[0].dateTime;
            }
        }
        protected void UpdateTimeLine()
        {
            PopulateDisplay();
        }
    }
}
