using BlazorApp1.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp1
{
    public class COVIDRestClient
    {
        private HttpClient httpClient;        
        public COVIDRestClient()
        {
            httpClient = new HttpClient();
        }
        public async Task<StateData[]> GetCurrentStates()
        {
            StateData[] states;
            string endpoint = "https://api.covidtracking.com/v1/states/current.json";
            states =  await httpClient.GetFromJsonAsync<StateData[]>(endpoint);
            return states;                                
        }
        public async Task<StateData[]> GetHistoricState(string state)
        {
            StateData[] states;
            string endpoint = String.Format("https://api.covidtracking.com/v1/states/{0}/daily.json",state);            
            states = await httpClient.GetFromJsonAsync<StateData[]>(endpoint);
            return states;            
        }        
    }
}
