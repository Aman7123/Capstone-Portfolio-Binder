using BlazorApp1.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp1.Services
{
    public class COVIDDataService : ICOVIDDataService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration Configuration;
        public COVIDDataService(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;            
            Configuration = config;
        }
        public async Task<StateData[]> GetCurrentStates()
        {
            StateData[] states;
            string endpoint = Configuration["EndPoints:States:Current"]; 
            states = await httpClient.GetFromJsonAsync<StateData[]>(endpoint);
            if (states != null) { PopulateCustomFields(states); }
            return states;
        }
        public async Task<StateData[]> GetHistoricState(string state)
        {
            StateData[] states;
            string endpoint = Configuration["EndPoints:State:Historic"]; 
            endpoint = endpoint.Replace("{state}", state);
            states = await httpClient.GetFromJsonAsync<StateData[]>(endpoint);
            if (states != null) { PopulateCustomFields(states); }
            return states;
        }
        public async Task<USData[]> GetHistoricUnitedStates()
        {
            USData[] unitedStates;
            string endpoint = Configuration["EndPoints:US:Historic"]; 
            unitedStates = await httpClient.GetFromJsonAsync<USData[]>(endpoint);
            if (unitedStates != null) { PopulateCustomFields(unitedStates); }
            return unitedStates;
        }
        private void PopulateCustomFields(COVIDData[] dataSet)
        {
            foreach (var data in dataSet)
            {
                data.PopulateCustomFields();
            }
        }
    }
}
