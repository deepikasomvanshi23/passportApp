using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using passportApp.Common;
using passportApp.PassportValidationService;
using Passport = passportApp.Models.Passport;
using ValidationResults = passportApp.Models.ValidationResults;

namespace passportApp.Controllers
{
    public class PassportsController : Controller
    {
       /// <summary>
       /// Use to display the validation results
       /// </summary>
       /// <returns></returns>
        [HandleError]  
        public ActionResult Details()
        {
            
            var results = (ValidationResults)TempData["model"];
            return View(results);
        }

       
       /// <summary>
       /// Show validate passport page
       /// </summary>
       /// <returns></returns>
        [HandleError]  
        public ActionResult Validate()
        {
            Passport model=new Passport();
            IEnumerable<Enums.GenderType> GenderType = Enum.GetValues(typeof(Enums.GenderType))
                                                      .Cast<Enums.GenderType>();
            model.GenderList = from gender in GenderType
                                select new SelectListItem
                                {
                                    Text = gender.ToDescriptionString(),
                                    Value = Util.StringToEnum<Enums.GenderType>(gender.ToString()).ToString()
                                };
            
            model.CountryCodesList = from code in Helper.GetCountryList()
                               select new SelectListItem
                               {
                                   Text = code.Country,
                                   Value = code.Nationality
                               };
            return View(model);
        }

        /// <summary>
        /// Contact Service to validate the passport
        /// </summary>
        /// <param name="passport"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandleError]  
        public ActionResult Validate([Bind(Include = "PassportNumber,Nationality,DateOfBirth,Gender,DateOfExpiry,MrzRow2")] Passport passport)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Passport, PassportValidationService.Passport>();
                cfg.CreateMap<PassportValidationService.Passport, Passport>();
                cfg.CreateMap<ValidationResults, PassportValidationService.ValidationResults>();
                cfg.CreateMap<PassportValidationService.ValidationResults, ValidationResults>();
            });
            var mapper = config.CreateMapper();
            if (ModelState.IsValid)
            {
                Service1Client serviceClient=new Service1Client();
                if (serviceClient.ClientCredentials != null)
                {
                    serviceClient.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["Username"];
                    serviceClient.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["Password"];
                }
                PassportValidationService.ValidationResults results = serviceClient.ValidatePassportData(mapper.Map<PassportValidationService.Passport>(passport));

                TempData["model"] = mapper.Map<ValidationResults>(results);
                return RedirectToAction("Details");
            }
            return null;
        }
    }
}
