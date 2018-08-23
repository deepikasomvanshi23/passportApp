using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace passportApp.Models
{
    public class Passport
    {
        [Key]
        [Required(ErrorMessage = "Empty Passport Number")]
        [MaxLength(10, ErrorMessage = "Up to 10 chars")]
        [Display(Name = "Passport Number")]
        public string PassportNumber { get; set; }

        [Required(ErrorMessage = "Empty Nationality")]
        [Display(Name = "Nationality")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Empty DateOfBirth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Empty Gender")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Empty DateOfExpiry")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Expiry")]
        public DateTime? DateOfExpiry { get; set; }

        [Required(ErrorMessage = "Empty MrzRow2Passport")]
        [MaxLength(44, ErrorMessage = "Up to 44 chars")]
        [RegularExpression(@"(^([A-Z0-9<]{9})([0-9])([A-Z]{3})([0-9]{6})([0-9])([MF<])([0-9]{6})([0-9])([A-Z0-9<]{14})([0-9])([0-9])*$)", ErrorMessage = "Please enter valid Mrz row2")]
        [Display(Name = "Mrz Row2")]
        public string MrzRow2 { get; set; }

        public IEnumerable<SelectListItem> GenderList { get; set; }
        public IEnumerable<SelectListItem> CountryCodesList { get; set; }
    }

    public class CountryCodes
    {
        public string Country { get; set; }
        public string Nationality { get; set; }
    }
}