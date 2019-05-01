using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Utils
{
    public static class Validations
    {
        public static bool TextOnly(string s)
        {
            if(string.IsNullOrWhiteSpace(s))
                return false;
            return s.All(c => Char.IsLetter(c));
        }

        public static bool TextOnlySentence(string s)
        {
            if(string.IsNullOrWhiteSpace(s))
                return false;
            foreach(string word in s.Split(' ', '\t'))
                if(!TextOnly(word))
                    return false;
            return true;
        }

        
        // Demonstrates the function like syntax for a method, and the ternary decision operator ? : and the LINQ ext. All() applied to an IEnummerable (in this case a String array).
        // Same result as above, just with a different and more compact syntax.
        public static bool TextOnlySentence2(string s)
            => String.IsNullOrWhiteSpace(s) ? false : s.Split(' ', '\t').All(word => TextOnly(word));
    }
}