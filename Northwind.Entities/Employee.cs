using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Utils;

namespace Northwind.Entities
{
    public class Employee
    {
        #region Fields
        private int id;
        private string lastname;
        private string firstname;
        private string title;
        private string titleofcourtesy;
        private DateTime birthDate;
        private DateTime hireDate;
        private Address address;
        private ContactInformation contactInformation;
        #endregion

        #region Constructors
        public Employee(int id, string lastname, string firstname, string title, string titleofcourtesy, DateTime birthDate, DateTime hireDate, Address address, ContactInformation contactInformation)
        {
            Id = id;
            LastName = lastname;
            FirstName = firstname;
            Title = title;
            TitleOfCourtesy = titleofcourtesy;
            BirthDate = birthDate;
            HireDate = hireDate;
            Address = address;
            ContactInformation = contactInformation;
        }
        #endregion

        #region properties;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if(value > 0)
                {
                    Id = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"Id skal være over 0");
                }
            }
        }

        public string LastName
        {
            get
            {
                return lastname;
            }
            set
            {
                var validationResult = ValidateName(value);
                if(!validationResult.isValid)
                {
                    if(validationResult.errorMessage == "null")
                    {
                        throw new ArgumentNullException();
                    }
                    else
                    {
                        throw new ArgumentException(validationResult.errorMessage);
                    }
                }
                else if(value != lastname)
                {
                    lastname = value;
                }
            }
        }

        public string FirstName
        {
            get
            {
                return firstname;
            }
            set
            {
                var validationResult = ValidateName(value);
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
                else if(value != firstname)
                {
                    firstname = value;
                }
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                var validationResult = ValidateTitle(value);
                if(!validationResult.isValid)
                {
                    if(validationResult.errorMessage == "null")
                    {
                        throw new ArgumentNullException();
                    }
                    else
                    {
                        throw new ArgumentException(validationResult.errorMessage);
                    }
                }
                else if(value != title)
                {
                    title = value;
                }
            }
        }

        public string TitleOfCourtesy
        {
            get
            {
                return titleofcourtesy;
            }
            set
            {
                var validationResult = VaidateTitleOfCourtesy(value);
                if(!validationResult.isValid)
                {
                    if(validationResult.errorMessage == "null")
                    {
                        throw new ArgumentException(validationResult.errorMessage);
                    }
                    else
                    {
                        throw new ArgumentException(validationResult.errorMessage);
                    }
                }
                else if(value != titleofcourtesy)
                {
                    titleofcourtesy = value;
                }
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }
            set
            {
                birthDate = value;
            }
        }

        public DateTime HireDate
        {
            get
            {
                return hireDate;
            }
            set
            {
                hireDate = value;
            }
        }

        public Address Address
        {
            get
            {
                return address;
            }
            set
            {
                if(value != null)
                {
                    address = value;
                }
                else
                {
                    throw new ArgumentNullException("null");
                }
            }
        }

        public ContactInformation ContactInformation
        {
            get
            {
                return contactInformation;
            }
            set
            {
                if(value != null)
                {
                    contactInformation = value;
                }
                else
                {
                    throw new ArgumentNullException("null");
                }
            }
        }
        #endregion

        #region methonds
        public static (bool isValid, string errorMessage) ValidateName(string name)
        {
            if(name is null)
            {
                return (false, "null");
            }
            else if(name.Length > 25)
            {
                return (false, "A name cannot contain more then 25 characters");
            }
            else if(name == string.Empty)
            {
                return (true, String.Empty);
            }
            else
            {
                name = name.Trim();
                if(!(Validations.TextOnly(name)))
                {
                    return (false, "A name can only contain letters");
                }
                return (true, String.Empty);
            }
        }

        public static (bool isValid, string errorMessage) ValidateTitle(string title)
        {
            if(title is null)
            {
                return (false, "null");
            }
            else if(title.Length > 30)
            {
                return (false, "A title cannot contain more then 30 characters");
            }
            else if(title == String.Empty)
            {
                return (true, String.Empty);
            }
            else
            {
                if(!(Validations.TextOnly(title)))
                {
                    return(false, "A title can only consist of letters");
                }
                return(true, String.Empty);
            }
        }

        public static (bool isValid, string errorMessage) VaidateTitleOfCourtesy(string titleofcourtesy)
        {
            if(titleofcourtesy is null)
            {
                return (false, "null");
            }
            else if(titleofcourtesy.Length > 15)
            {
                return (false, "A title of courtesy cannot contain more then 15 chararacters");
            }
            else if(titleofcourtesy == String.Empty)
            {
                return (true, String.Empty);
            }
            else
            {
                if(!(Validations.TextOnly(titleofcourtesy)))
                {
                    return(false, "A title of courtesy can only contain letters");
                }
                return(true, String.Empty);
            }
        }

        public static (bool isValid, string errorMessage) ValidateBirthDate(DateTime birthdate)
        {
            if(birthdate < new DateTime(1920, 1, 1))
            {
                return (false, "A birthdate must be after January the 1st 1920");
            }
            else if(birthdate > DateTime.Today)
            {
                return (false, "A birthdate cannot be after the date of today");
            }
            else
            {
                return(true, String.Empty);
            }
        }

        public static (bool isValid, string errorMessage) ValidateHireDate(DateTime hiredate)
        {
            if(hiredate < new DateTime(1920, 1, 1))
            {
                return (false, "A hiredate must be after January the 1st 1920");
            }
            else if(hiredate > DateTime.Today)
            {
                return (false, "A hiredate cannot be after the date of today");
            }
            else
            {
                return(true, String.Empty);
            }
        }
        
        #endregion
    }
}
