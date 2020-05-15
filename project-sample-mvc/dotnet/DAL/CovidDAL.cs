using RestSharp;
using System;
using System.Collections.Generic;

namespace Covid
{
    public class CovidDAL
    {
        public List<CovidCountryModel> GetCasesForCountryByStatus(string country, string status)
        {
            var client = new RestSharp.RestClient("https://api.covid19api.com");
            var request = new RestRequest($"live/country/{country}/status/{status}", DataFormat.Json);

            var response = client.Get<List<CovidCountryModel>>(request);

            if (response.IsSuccessful)
            {
                return response.Data;
            }

            string errorMessage = $"" +
                "Status Code: {response.StatusCode}, " +
                "Status Description: {response.StatusDescription}, " +
                "Content: {response.Content}, " +
                "ErrorMessage: {response.ErrorMessage}";

            throw new Exception(errorMessage);
        }
    }
}