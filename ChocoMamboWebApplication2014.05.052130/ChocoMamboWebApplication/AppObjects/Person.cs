using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChocoMamboWebApplication.AppObjects
{
    public class Person:Address
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}