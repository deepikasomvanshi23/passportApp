using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Hosting;
using System.Xml.Linq;
using passportApp.Models;

namespace passportApp.Common
{
    public static class Helper
    {
        /// <summary>
        /// Getting country codes from xml file
        /// </summary>
        /// <returns>List of countries and their country codes</returns>
        public static List<CountryCodes> GetCountryList()
        {
            var filePath = HostingEnvironment.MapPath(ConfigurationManager.AppSettings["CountryCodesFilePath"]);
            if (filePath != null)
            {
                XDocument xdoc = XDocument.Load(filePath);
                List<CountryCodes> countryCodes = (from lv1 in xdoc.Descendants("record")
                    let xElement = lv1.Element("Country")
                    where xElement != null
                    let element = lv1.Element("Code")
                    where element != null
                    select new CountryCodes
                    {
                        Country = xElement.Value,
                        Nationality = element.Value
                    }).ToList();
                return countryCodes;
            }
            return null;
        }

        public static string ToFriendlyString(this Boolean b)
        {
            return b ? "PASS" : "FAIL";
        }
    }
}