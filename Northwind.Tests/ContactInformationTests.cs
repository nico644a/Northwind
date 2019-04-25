using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities.Tests
{
    [TestClass()]
    public class ContactInformationTests
    {
        [TestMethod()]
        public void ContactInformationInitializationSucceedsTest()
        {
            // Arrange:
            string privatePhone = "3334 4900";
            string workPhone = "3334 4901";
            string privateMail = "home@gmail.com";
            string workMail = "mara@aspit.dk";
            ContactInformation contactInformation;

            // Act:
            contactInformation = new ContactInformation(workPhone, workMail, privatePhone, privateMail);

            // No need to assert, because the test method will fail when an unexpected exception is unhandled here.
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ContactInformationInitializationFailsTest1()
        {
            // Arrange:
            string privatePhone = "3334 4900";
            string workPhone = "3334 4901";
            string privateMail = "home@gmail.com";
            string workMail = "maraaspit.dk";   // missing @
            ContactInformation contactInformation;

            // Act:
            contactInformation = new ContactInformation(workPhone, workMail, privatePhone, privateMail);

            // No need to assert inside the test method, because of the ExpectedException attribute will function as the assertion.
        }

        [TestMethod()]
        public void ValidateMailTest()
        {
            // Arrange:
            string correctMail = "mara@aspit.dk";
            string mailMissingSnabelA = "maraaspit.dk";
            string mailMissingTld = "mara@aspitdk";
            string emptyStringMail = String.Empty;
            string nullMail = null;

            // Act:
            var correctMailValidationResult = ContactInformation.ValidateMail(correctMail);
            var mailMissingSnabelAValidationResult = ContactInformation.ValidateMail(mailMissingSnabelA);
            var mailMissingTldValidationResult = ContactInformation.ValidateMail(mailMissingTld);
            var emptyStringMailValidationResult = ContactInformation.ValidateMail(emptyStringMail);
            var nullMailValidationResult = ContactInformation.ValidateMail(nullMail);

            // Assert:
            Assert.IsTrue(correctMailValidationResult.isValid);
            Assert.IsFalse(mailMissingSnabelAValidationResult.isValid);
            Assert.IsFalse(mailMissingTldValidationResult.isValid);
            Assert.IsTrue(emptyStringMailValidationResult.isValid); // Empty strings are OK.
            Assert.IsFalse(nullMailValidationResult.isValid);
        }

        [TestMethod()]
        public void ValidatePhoneTest()
        {
            var correctPhoneWithPlus = "+45 3334 4901";
            var correctPhoneWithoutPlus = "0045 3334 4901";
            var correctPhoneWithOutPlusAndSpaces = "004533344901";


            // Act:
            var correctPhoneWithPlusValidationResult = ContactInformation.ValidatePhone(correctPhoneWithPlus);
            var correctPhoneWithoutPlusValidationResult = ContactInformation.ValidatePhone(correctPhoneWithoutPlus);
            var correctPhoneWithoutPlusAndSpacesValidationResult = ContactInformation.ValidatePhone(correctPhoneWithOutPlusAndSpaces);

            //
            Assert.IsTrue(correctPhoneWithPlusValidationResult.isValid);
            Assert.IsTrue(correctPhoneWithoutPlusValidationResult.isValid);
            Assert.IsTrue(correctPhoneWithoutPlusAndSpacesValidationResult.isValid);

        }
    }
}