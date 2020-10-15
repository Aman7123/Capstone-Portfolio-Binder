using System;

namespace BlazorApp1.Models
{
    public class USData
    {
        public int date { get; set; }                 
        public int? positive { get; set; }
        public int? negative { get; set; }                
        public int? pending { get; set; }
        public int? hospitalizedCurrently { get; set; }
        public int? hospitalizedCumulative { get; set; }
        public int? inIcuCurrently { get; set; }
        public int? inIcuCumulative { get; set; }
        public int? onVentilatorCurrently { get; set; }
        public int? onVentilatorCumulative { get; set; }
        public int? recovered { get; set; }        
        public int? death { get; set; }
        public int? hospitalized { get; set; }
        public int? totalTestResults { get; set; }
        public int? deathIncrease { get; set; }
        public int? hospitalizedIncrease { get; set; }
        public int? negativeIncrease { get; set; }
        public int? positiveIncrease { get; set; }
        public int? totalTestResultsIncrease { get; set; }
        //custom fields
        public DateTime dateTime { get; set; }
        public string displayDate { get; set; }

    }
}
