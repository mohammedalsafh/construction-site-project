using System.ComponentModel.DataAnnotations;

namespace CPIS_358_project.Models
{
    public class User
    {
        //a primary key that will automattically increment when a user enters the database
        public int Id { get; set; } 

        // applying the same rules of full name that were in js
        [Required(ErrorMessage = "Full Name is required")]//a message that will appear if the user didnt enter whats required
        [RegularExpression(@"^[A-Za-z]+ [A-Za-z]+$", ErrorMessage = "Must be First and Last name (letters only).")]
        public string FullName { get; set; } = string.Empty; // will get and set the fullname the user enters
        //if the user didnt enter anything instead of the value being null it will be empty text


        // applying the same rules of phone number that were in js
        [Required(ErrorMessage = "Phone Number is required")]//a message that will appear if the user didnt enter whats required
        [RegularExpression(@"^966-5[0-9]-[0-9]{3}-[0-9]{4}$", ErrorMessage = "Phone must match format: 966-5x-xxx-xxxx")]
        public string PhoneNumber { get; set; } = string.Empty; // will get and set the phonenumber the user enters
        //if the user didnt enter anything instead of the value being null it will be empty text


        // applying the same rules of email that were in js
        [Required(ErrorMessage = "Email is required")]//a message that will appear if the user didnt enter whats required
        [RegularExpression(@"^[^@]+@[^.][^@]*\.[^@]+$", ErrorMessage = "Invalid Email Format.")]
        public string UserE { get; set; } = string.Empty; // will get and set the email the user enters
        //if the user didnt enter anything instead of the value being null it will be empty text


        // applying the rule at least 1 number and at least 8 length
        [Required(ErrorMessage = "Password is required")]//a message that will appear if the user didnt enter whats required
        [RegularExpression(@"^(?=.*[0-9]).{8,}$", ErrorMessage = "Password must be at least 8 chars and contain a number.")]
        public string UserP { get; set; } = string.Empty; // will get and set the password the user enters
        //if the user didnt enter anything instead of the value being null it will be empty text
    }
}