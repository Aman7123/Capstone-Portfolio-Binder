using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Models
{
    public class COVIDData
    {
        public int date { get; set; } //Date on which data was collected by The COVID Tracking Project. 
        public int? death { get; set; } //Deaths (confirmed & probable)
        public int? deathIncrease { get; set; } //New Deaths
        public int? hospitalizedCumulative { get; set; } //Total hospitilizations (COVID)
        public int? hospitalizedCurrently { get; set; } //Current hospitilizations (COVID) 
        public int? hospitalizedIncrease { get; set; } //New hospitilizations (COVID)
        public int? inIcuCumulative { get; set; } //Total ICU hospitilizations (COVID)
        public int? inIcuCurrently { get; set; } //Current ICU hospitilizations (COVID)        
        public int? negative { get; set; } //Negative PCR tests (people)
        public int? negativeIncrease { get; set; } //Inc. in negative PCR tests
        public int? onVentilatorCumulative { get; set; } //Total Ventilator hospitilizations (COVID)
        public int? onVentilatorCurrently { get; set; } //Current Ventilator hospitilizations (COVID)
        public int? pending { get; set; } //Total # of Tests not completed
        public int? positive { get; set; } //Positive Cases (confirmed plus probable)
        public int? positiveIncrease { get; set; } //Positive Cases (confirmed plus probable)
        public int? recovered { get; set; } //Total # of ppl that recovered from COVID
        public int? totalTestResults { get; set; } //Total # of test results                              
        public int? totalTestResultsIncrease { get; set; } //New tests
        //custom fields
        public DateTime dateTime { get; set; }
        public string displayDate { get; set; }
    }
}
