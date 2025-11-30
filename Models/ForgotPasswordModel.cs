using System.ComponentModel.DataAnnotations;

namespace CPIS_358_project.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        // applying the same rules of email that were in js if the user didnt follow the message will appear
        [RegularExpression(@"^[^@]+@[^.][^@]*\.[^@]+$", ErrorMessage = "Invalid Email Format")]
        public string UserE { get; set; } = string.Empty;// will get and set the email the user enters
        //if the user didnt enter anything instead of the value being null it will be empty text


        [Required]
        // applying the rule at least 1 number and at least 8 length if the user didnt follow the message will appear
        [RegularExpression(@"^(?=.*[0-9]).{8,}$", ErrorMessage = "Password must be at least 8 chars and contain a number.")]
        public string NewP { get; set; } = string.Empty;// will get and set the password the user enters
        //if the user didnt enter anything instead of the value being null it will be empty text


        //will compare the confirmp that the user enters with the newp
        //if they dont match it will result false and the message will appear
        [Required]
        [Compare("NewP", ErrorMessage = "The passwords do not match.")]
        public string ConfirmP { get; set; } = string.Empty;// will get and set the conformation password the user enters
        //if the user didnt enter anything instead of the value being null it will be empty text

    }
}