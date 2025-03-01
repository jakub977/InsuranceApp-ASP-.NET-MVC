using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace InsuranceApp_Accounts.Models
{
    public class Client
    {
        [Key]
        [Required]
        public int Id { get; set; }


        [DisplayName("'first name'")]
        [Required(ErrorMessage = "* Jméno nesmí být prázdné")]
        public string FirstName { get; set; } = "";


        [DisplayName("'last name'")]
        [Required(ErrorMessage = "* Příjmení nesmí být prázdné")]
        public string LastName { get; set; } = "";


        [DisplayName("'address'")]
        [Required(ErrorMessage = "* Adresa nesmí být prázdná")]
        public string Address { get; set; } = "";


        [DisplayName("'phone'")]
        [Required(ErrorMessage = "* Telefon nesmí být prázdný")]
        public string Phone { get; set; } = "";


        [DisplayName("'email'")]
        [Required(ErrorMessage = "* Email nesmí být prázdný")]
        public string Email { get; set; } = "";

        public string? Insurance { get; set; }

        public string? Limit { get; set; }

        public string? Subject { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string? EndDate { get; set; }

        public string? Event { get; set; }

        public string? EventSubject { get; set; }

        public string? Place { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? EventDate { get; set; }



        // Empty constructor
        public Client()
        {

        }
    }
}
