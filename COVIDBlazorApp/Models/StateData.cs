namespace BlazorApp1.Models
{
    public class StateData
    {        
        public int date { get; set; }
        public string state { get; set; }
        public int? positive { get; set; } //confirmed + probable COVID cases
        public int? negative { get; set; } //negative COVID tests
        public int? positiveIncrease { get; set; } //new cases (confirmed + probable)      
        public int? hospitalizedCurrently { get; set; } //currently hospitalized
        public int? inIcuCurrently { get; set; } //currently in icu with COVID
        public int? death { get; set; } //confirmed + probable
        public int? deathConfirmed { get; set; } //new deaths    
        public int? deathProbable { get; set; } //death probable
        public int? deathIncrease { get; set; } //new deaths            
        public string dataQualityGrade { get; set; }
        public string fips { get; set; } //state fips code
        public string lastUpdateEt { get; set; }
    }
}
