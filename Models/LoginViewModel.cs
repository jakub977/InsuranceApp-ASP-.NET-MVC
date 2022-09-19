using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace InsuranceApp_Accounts.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "* Zadejte svůj email")]
        [EmailAddress(ErrorMessage = "* Neplatná emailová adresa")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "* Zadejte své heslo")]
        [DataType(DataType.Password)]
        [Display(Name = "Heslo")]
        public string Password { get; set; } = "";

        [Display(Name = "Pamatuj si mě")]
        public bool RememberMe { get; set; }
    }
}
