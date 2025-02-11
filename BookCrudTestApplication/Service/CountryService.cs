﻿using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Service
{
    public class CountryService : ICountryServices
    {
        //private field
        private readonly List<Country> _countries;

        //constructor
        public CountryService()
        {
            _countries = new List<Country>();
        }

        public countryResponse AddCountry(CountryAddRequest? countryAddRequest)
        {
            //Validation: countryAddRequest parameter can't be null
            if (countryAddRequest == null)
            {
                throw new ArgumentNullException(nameof(countryAddRequest));
            }

            //Validation: CountryName can't be null
            if (countryAddRequest.CountryName == null)
            {
                throw new ArgumentException(nameof(countryAddRequest.CountryName));
            }

            //Validation: CountryName can't be duplicate
            if (_countries.Where(temp => temp.CountryName == countryAddRequest.CountryName).Count() > 0)
            {
                throw new ArgumentException("Given country name already exists");
            }



            // ---- alternate Implementation  -----
            //var countr = new country();
            //countr.CountryName = countryAddRequest.CountryName;


            //Convert object from CountryAddRequest to Country type
            Country country = countryAddRequest.ToCountry();

            //generate CountryID
            country.CountryID = Guid.NewGuid();

            //Add country object into _countries
            _countries.Add(country);

            return country.ToCountryResponse();
        }
    }
}