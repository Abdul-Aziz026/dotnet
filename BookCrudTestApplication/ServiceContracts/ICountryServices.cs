using ServiceContracts.DTO;

namespace ServiceContracts
{
    public class ICountryServices
    {
        countryResponse AddCountry(CountryAddRequest? countryAddRequest);
    }
}
