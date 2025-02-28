using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InsuranceApp_Accounts.Models
{
    public class RegisterViewModel : IdentityUser
    {

        [DisplayName("'first name'")]
        [Required(ErrorMessage = "* Zadejte jméno")]
        public string UserFirstName { get; set; } = "";


        [DisplayName("'last name'")]
        [Required(ErrorMessage = "* Zadejte příjmení")]
        public string UserLastName { get; set; } = "";


        [Required(ErrorMessage = "* Zadejte email")]
        [EmailAddress(ErrorMessage = "* Neplatná emailová adresa")]
        [Display(Name = "Email")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "* Zadejte heslo")]
        [StringLength(100, ErrorMessage = "* {0} musí mít délku alespoň {2} a nejvíc {1} znaků", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Heslo")]
        public string Password { get; set; } = "";

        [Required(ErrorMessage = "* Zadejte heslo ještě jednou")]
        [DataType(DataType.Password)]
        [Display(Name = "Potvrzení hesla")]
        [Compare("Password", ErrorMessage = "* Zadaná hesla se neshodují")]
        public string ConfirmPassword { get; set; } = "";
    }
}
