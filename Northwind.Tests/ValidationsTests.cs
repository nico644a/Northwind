using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Tests
{
    [TestClass()]
    public class ValidationsTests
    {
        [TestMethod()]
        public void TextOnlyTest()
        {
            // Arrange:
            string text = "Mads";
            string nullText = null;
            string empty = String.Empty;
            string numbers = "1234";
            string otherChars = "!#¤%";
            string textWithNumber = "Mad5";
            string textWithOtherChar = "M@ds";

            // Act:
            bool validationResultText = Validations.TextOnly(text);
            bool validationResultNull = Validations.TextOnly(nullText);
            bool validationResultEmpty = Validations.TextOnly(empty);
            bool validationResultNumbers = Validations.TextOnly(numbers);
            bool validationResultOtherChars = Validations.TextOnly(otherChars);
            bool validationResultTextWithNumber = Validations.TextOnly(textWithNumber);
            bool validationResultTextWithOtherChar = Validations.TextOnly(textWithOtherChar);

            // Assert:
            Assert.IsTrue(validationResultText);
            Assert.IsFalse(validationResultNull);
            Assert.IsFalse(validationResultEmpty);
            Assert.IsFalse(validationResultNumbers);
            Assert.IsFalse(validationResultOtherChars);
            Assert.IsFalse(validationResultTextWithNumber);
            Assert.IsFalse(validationResultTextWithOtherChar);
        }

        [TestMethod()]
        public void TextOnlySentenceTest()
        {
            // Arrange:
            string sentence = "Mads Mikkel Rasmussen";
            string nullSentence = null;
            string empty = String.Empty;
            string untrimmedSentence = " " + sentence + " ";

            // Act:
            bool validationResultSentence = Validations.TextOnlySentence(sentence);
            bool validationResultNull = Validations.TextOnlySentence(nullSentence);
            bool validationResultEmpty = Validations.TextOnlySentence(empty);
            bool validationResultUntrimmed = Validations.TextOnlySentence(untrimmedSentence);


            // Assert:
            Assert.IsTrue(validationResultSentence);
            Assert.IsFalse(validationResultNull);
            Assert.IsFalse(validationResultEmpty);
            Assert.IsFalse(validationResultUntrimmed);

            validationResultSentence = Validations.TextOnlySentence2(sentence);
            validationResultNull = Validations.TextOnlySentence2(nullSentence);
            validationResultEmpty = Validations.TextOnlySentence2(empty);
            validationResultUntrimmed = Validations.TextOnlySentence2(untrimmedSentence);

            Assert.IsTrue(validationResultSentence);
            Assert.IsFalse(validationResultNull);
            Assert.IsFalse(validationResultEmpty);
            Assert.IsFalse(validationResultUntrimmed);
        }

        [TestMethod()]
        public void TextOnlySentence2Test()
        {
            Assert.Fail();
        }
    }
}