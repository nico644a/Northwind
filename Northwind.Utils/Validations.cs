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
            if(s is null)
                return false;
            return s.All(c => Char.IsLetter(c));
        }

        public static bool TextOnlySentence(string s)
        {
            if(s is null)
                return false;
            foreach(string word in s.Split(' ', '\t'))
                if(!TextOnly(word))
                    return false;
            return true;
        }

        public static bool TextOnlySentence2(string s)
            => s.Split(' ', '\t').All(word => TextOnly(word));
    }
}
