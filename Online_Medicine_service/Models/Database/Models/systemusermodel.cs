using System.ComponentModel.DataAnnotations;

namespace Online_Medicine_service.Models.Database.Models
{
    public class systemusermodel
    {

        [Required(ErrorMessage = "Please enter your Firstname")]
        [StringLength(15, MinimumLength = 5)]
        public string Firstname { get; set; }


        [Required(ErrorMessage = "Please enter your Lastname")]
        [StringLength(15, MinimumLength = 3)]
        public string LastName { get; set; }



        [Required(ErrorMessage = "Please enter your phone numer")]
        [RegularExpression(@"\d{11}", ErrorMessage = "Please enter 11 digit Mobile No.")]
        public string phone { get; set; }


        [Required]
        public string address { get; set; }
        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(20, MinimumLength = 5)]
        public string username { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string email { get; set; }


        [Required(ErrorMessage = "Please enter your Password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters ,upper case, lower case, number and special character")]
        public string password { get; set; }


        [Required]
        [Compare("password")]
        public string cpassword { get; set; }
    }
}