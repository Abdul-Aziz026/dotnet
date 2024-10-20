using Entities;
using System;

namespace ServiceContracts.DTO
{
    public class countryResponse
    {
        public Guid CountryID { get; set; }
        public string? CountryName { get; set; }
    }

    public static class CountryExtensions
    {
        public static countryResponse ToCountryResponse(this Country country)
        {
            return new countryResponse() { CountryID = country.CountryID, CountryName = country.CountryName };
        }
    }
}