using BlazorApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Services
{
    public interface ICOVIDDataService
    {
        Task<List<StateMetaData>> GetStateMetaData();        
        Task<StateData[]> GetCurrentStates();
        Task<StateData[]> GetHistoricState(string state);
        Task<USData[]> GetHistoricUnitedStates();        
    }
}
