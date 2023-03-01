

namespace JobBoard.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Maksimum 100 simvol ola biler")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(maximumLength: 30, ErrorMessage = "Maksimum 30 simvol olmalidir")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
