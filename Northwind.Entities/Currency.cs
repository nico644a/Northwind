using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities
{
    public class Currency
    {
        private decimal dkk;

        public Currency(decimal dkk)
        {
            this.DKK = dkk;
        }

        public decimal DKK
        {
            get
            {
                return dkk;
            }
            set
            {
                if(value > 0)
                {
                    dkk = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Currency values must be over 0");
                }
            }
        }
    }
}
