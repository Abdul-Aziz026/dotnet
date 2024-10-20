using ServiceContracts.DTO;

namespace ServiceContracts
{
    public interface ICountryServices
    {
        countryResponse AddCountry(CountryAddRequest? countryAddRequest);
    }
}
