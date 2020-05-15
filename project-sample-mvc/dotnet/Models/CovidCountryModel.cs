using System;
namespace Covid
{
    public class CovidCountryModel
    {
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public int Confirmed { get; set; }
        public int Deaths { get; set; }
        public int Recovered { get; set; }
        public int Active { get; set; }
        public DateTime Date { get; set; }
        public Guid LocationId { get; set; }
    }
}