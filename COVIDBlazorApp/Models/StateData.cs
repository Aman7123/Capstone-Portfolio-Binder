using System;

namespace BlazorApp1.Models
{
    public class StateData : COVIDData
    {
        public string dataQualityGrade { get; set; }       
        public int? deathConfirmed { get; set; } //Deaths (confirmed)    
        public int? deathProbable { get; set; } //Deaths (probable)
        public string fips { get; set; }
        public string lastUpdateEt { get; set; } //Last updated, Eastern Time     
        public string state { get; set; } //Two letter abbreviation for state or territory
    }
}
