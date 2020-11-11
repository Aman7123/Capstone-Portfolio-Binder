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
        Task<List<StateData>> GetCurrentStates();
        Task<List<StateData>> GetHistoricState(string state);
        Task<List<USData>> GetHistoricUnitedStates();
        Task<List<USData>> GetCurrentUnitedStates();
    }
}
