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
        public async Task<List<StateMetaData>> GetStateMetaData()
        {            
            string endpoint = Configuration["EndPoints:States:Metadata"];
            return await httpClient.GetFromJsonAsync<List<StateMetaData>>(endpoint);                      
        }
        public async Task<List<StateData>> GetCurrentStates()
        {
            List<StateData> states;
            string endpoint = Configuration["EndPoints:States:Current"];
            states = await httpClient.GetFromJsonAsync<List<StateData>>(endpoint);
            if (states != null) { 
                PopulateCustomFields(states);
                RemoveBadData(states);
            }
            return states;
        }
        public async Task<StateData[]> GetStateHistory(string state)
        {
            StateData[] states;
            string endpoint = Configuration["EndPoints:State:Historic"];
            endpoint = endpoint.Replace("{state}", state);
            states = await httpClient.GetFromJsonAsync<StateData[]>(endpoint);
            if (states != null)
            {
                PopulateCustomFields(states);
            }
            return states;
        }
        public async Task<USData[]> GetUnitedStatesHistory()
        {
            USData[] us;
            string endpoint = Configuration["EndPoints:US:Historic"];
            us = await httpClient.GetFromJsonAsync<USData[]>(endpoint);
            if (us != null)
            {
                PopulateCustomFields(us);
            }
            return us;
        }
        public async Task<List<USData>> GetCurrentUnitedStates()
        {
            List<USData> unitedStates;
            string endpoint = Configuration["EndPoints:US:Current"];
            unitedStates = await httpClient.GetFromJsonAsync<List<USData>>(endpoint);
            if (unitedStates != null) { PopulateCustomFields(unitedStates); }
            return unitedStates;
        }
        public async Task<List<USData>> GetHistoricUnitedStates()
        {
            List<USData> unitedStates;
            string endpoint = Configuration["EndPoints:US:Historic"]; 
            unitedStates = await httpClient.GetFromJsonAsync<List<USData>>(endpoint);
            if (unitedStates != null) { PopulateCustomFields(unitedStates); }
            return unitedStates;
        }
        private void PopulateCustomFields(List<StateData> dataSet)
        {
            foreach (var data in dataSet)
            {
                data.PopulateCustomFields();
            }
        }
        private void PopulateCustomFields(COVIDData[] dataSet)
        {
            foreach (var data in dataSet)
            {
                data.PopulateCustomFields();
            }
        }
        private void PopulateCustomFields(List<USData> dataSet)
        {
            foreach (var data in dataSet)
            {
                data.PopulateCustomFields();
            }
        }
        private void RemoveBadData(List<StateData> sd)
        {
            for(int i=0;i<sd.Count;i++)
            {
                StateData data = sd[i];
                if(data.dataQualityGrade == null)
                {
                    sd.RemoveAt(i);
                } else if(data.dataQualityGrade.Contains("D") || data.dataQualityGrade.Contains("F") || data.dataQualityGrade.Length == 0)
                {
                    sd.RemoveAt(i);
                }
            }
        }        
    }
}
