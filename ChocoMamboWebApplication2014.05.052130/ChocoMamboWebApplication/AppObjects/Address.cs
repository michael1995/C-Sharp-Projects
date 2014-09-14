using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChocoMamboWebApplication.AppObjects
{
    public class Address
    {
        /// <summary>
        /// A general class that can be inherited to provide properties RE: An Address.
        /// </summary>
        #region Properties
        public string BuildingNumber { get; set; }
        public string StreetName { get; set; }
        public string StreetType { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        #endregion
    }
}