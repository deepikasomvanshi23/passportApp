using System.ComponentModel.DataAnnotations;

namespace passportApp.Models
{
    public class ValidationResults
    {
        [Key]
        public string PassportNumber { get; set; }

        [Display(Name = "Passport Number Check Digit")]
        public bool PassportNumberCheckDigit { get; set; }

        [Display(Name = "DOB Check Digit")]
        public bool DateOfBirthCheckDigit { get; set; }

        [Display(Name = "Passport Expiration Date CheckDigit")]
        public bool PassportExpirationDateCheckDigit { get; set; }

        [Display(Name = "Personal Number Check Digit")]
        public bool PersonalNumberCheckDigit { get; set; }

        [Display(Name = "FinalCheckDigit")]
        public bool FinalCheckDigit { get; set; }

        [Display(Name = "Gender Cross Check")]
        public bool GenderCrossCheck { get; set; }

        [Display(Name = "DateOfBirth Cross Check")]
        public bool DateOfBirthCrossCheck { get; set; }

        [Display(Name = "Expiration Data Cross Check")]
        public bool ExpirationDataCrossCheck { get; set; }

        [Display(Name = "Nationality Cross Check")]
        public bool NationalityCrossCheck { get; set; }

        [Display(Name = "Passport Number Cross Check")]
        public bool PassportNumberCrossCheck { get; set; }
    }
}