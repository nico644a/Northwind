using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Firstname => "Mads"; 
        public ContactInformation ContactInformation { get; set; }
        
        
    }
}
