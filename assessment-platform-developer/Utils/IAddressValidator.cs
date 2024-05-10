using assessment_platform_developer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace assessment_platform_developer.Utils
{
    internal interface IAddressValidator
    {
        Tuple<bool, string> ValidateAddress(IAddressInformation addressInformation);
    }

    public class AddressValidator : IAddressValidator
    {
        public Tuple<bool, string> ValidateAddress(IAddressInformation addressInformation)
        {
            if (addressInformation is USAddress)
            {
                Regex regex = new Regex(@"^\d{5}(?:[-\s]\d{4})?$");
                if (regex.IsMatch(addressInformation.Zip))
                {
                    return Tuple.Create(true, string.Empty);
                }
                else
                {
                    return Tuple.Create(false, "Invalid zip code.");
                }
            }
            else if (addressInformation is CanadianAddress) 
            {
                Regex regex = new Regex(@"^[A-Za-z]\d[A-Za-z] ?\d[A-Za-z]\d$");
                if (regex.IsMatch(addressInformation.Zip))
                {
                    return Tuple.Create(true, string.Empty);
                }
                else
                {
                    return Tuple.Create(false, "Invalid zip code.");
                }
            }
            else 
            {
                return Tuple.Create(true, string.Empty);
            }
        }
    }
}
