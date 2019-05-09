using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Utils;

namespace Northwind.Entities
{
    public class Address
    {
        #region fields
        private string streetNumber;
        private string city;
        private string postalCode;
        private string country;
        #endregion

        #region constructors
        public Address(string streetNumber, string city, string postalCode, string country)
        {
            StreetNumber = streetNumber;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }
        #endregion

        #region properties
        public string StreetNumber
        {
            get
            {
                return streetNumber;
            }
            set
            {
                var validationResult = ValidateStreetNumber(value);
                if(!validationResult.isValid)
                {
                    if(validationResult.errorMessage == "null")
                    {
                        throw new ArgumentNullException(validationResult.errorMessage);
                    }
                    else
                    {
                        throw new ArgumentException(validationResult.errorMessage);
                    }
                }
                else if(value != streetNumber)
                {
                    streetNumber = value;
                }
            }
        }

        public string City
        {
            get
            {
                return city;
            }
            set
            {
                var validationResult = ValidateCity(value);
                if(!validationResult.isValid)
                {
                    if(validationResult.errorMessage == "null")
                    {
                        throw new ArgumentNullException(validationResult.errorMessage);
                    }
                    else
                    {
                        throw new ArgumentException(validationResult.errorMessage);
                    }
                }
                else if(value != city)
                {
                    city = value;
                }
            }
        }

        public string PostalCode
        {
            get
            {
                return postalCode;
            }
            set
            {
                
            }
        }

        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                var validationResult = ValidateCountry(value);
                if(!validationResult.isValid)
                {
                    if(validationResult.errorMessage == "null")
                    {
                        throw new ArgumentNullException(validationResult.errorMessage);
                    }
                    else
                    {
                        throw new ArgumentException(validationResult.errorMessage);
                    }
                }
                else if(country != value)
                {
                    country = value;
                }
            }
        }
        #endregion

        #region methonds
        public static (bool isValid, string errorMessage) ValidateStreetNumber(string streetNumber)
        {
            if(streetNumber is null)
            {
                return (false, "null");
            }
            else if(streetNumber == String.Empty)
            {
                return (true, String.Empty);
            }
            else
            {
                if(!(Validations.TextAndNumbersOnly(streetNumber)))
                {
                    return (false, "An address/street number cannot contain symbols like # and @");
                }
                return (true, String.Empty);
            }
        }

        public static (bool isValid, string errorMessage) ValidateCity(string city)
        {
            if(city is null)
            {
                return(false, "null");
            }
            else if(city == String.Empty)
            {
                return (true, String.Empty);
            }
            else
            {
                if(!(Validations.TextOnly(city)))
                {
                    return(false, "A city can  only contains letters");
                }
                return(true, String.Empty);
            }
        }

        public static (bool isValid, string errorMessage) ValidatePostalCode(string postalCode)
        {
            if(postalCode is null)
            {
                return (false, "null");
            }
            else if(postalCode.Length > 10)
            {
                return (false, "A postalcode cannot contain more then 10 symbols");
            }
            else if(postalCode == String.Empty)
            {
                return (true, String.Empty);
            }
            else
            {
                if(!Validations.TextAndNumbersOnly(postalCode))
                {
                    return(false, "A postalcode cannot contain  symbols like # and @");
                }
            }
            return (true, String.Empty);
        }

        public static (bool isValid, string errorMessage) ValidateCountry(string country)
        {
            if(country is null)
            {
                return (false, "null");
            }
            else if(country == String.Empty)
            {
                return (true, String.Empty);
            }
            else
            {
                if(Validations.TextOnly(country))
                {
                    return(false, "Et land kan kun indeholder bogstaver");
                }
                return (true, String.Empty);
            }
        }
        #endregion
    }
}
