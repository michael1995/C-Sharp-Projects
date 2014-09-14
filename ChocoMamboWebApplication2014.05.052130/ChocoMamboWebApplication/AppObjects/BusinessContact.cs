using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChocoMamboWebApplication.AppObjects
{
    public class BusinessContact:Person
    {
        /// <summary>
        /// A general class that inherits the Address Class 
        /// </summary>
        #region Properties
        public string ContactPerson { get; set; }
        #endregion      
    }
}