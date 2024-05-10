using assessment_platform_developer.Models;

namespace assessment_platform_developer.Utils
{
    public static class AddressFactory
    {
        public static IAddressInformation CreateAddressInformation(string address, string city, int stateId, string zip, Countries country)
        {
            if (country == Countries.UnitedStates)
            {
                return new USAddress
                {
                    Address = address,
                    City = city,
                    USState = (USStates)stateId,
                    State = ((USStates)stateId).ToString(),
                    Zip = zip,
                    CountryEnum = country,
                    Country = country.ToString()
                };
            }
            else if (country == Countries.Canada)
            {
                return new CanadianAddress
                {
                    Address = address,
                    City = city,
                    CanadianProvince = (CanadianProvinces)stateId,
                    State = ((CanadianProvinces)stateId).ToString(),
                    Zip = zip,
                    CountryEnum = country,
                    Country = country.ToString()
                };
            }
            return null;
        }
    }
}