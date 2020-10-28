using System;

namespace BlazorApp1.Models
{
    public class USData : COVIDData
    {
        public int? states { get; set; } //number of states/territories included
        public string lastModified { get; set; }
    }
}
