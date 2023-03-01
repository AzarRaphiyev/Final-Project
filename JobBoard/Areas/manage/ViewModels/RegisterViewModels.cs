

namespace JobBoard.Areas.manage.ViewModels
{
    public class RegisterViewModels
    {
        [Required]
        [StringLength(maximumLength:30,ErrorMessage ="Maksimum 30 simvol ola biler")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Maksimum 50 simvol ola biler")]
        public string Surname { get; set; }

        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Maksimum 100 simvol ola biler")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(maximumLength: 30, ErrorMessage = "Maksimum 30 simvol ola biler")]
        public string UserName { get; set; }

        [Required]
        [StringLength(maximumLength: 30,MinimumLength =8, ErrorMessage = "Maksimum 30,minimum 8 simvol ola biler")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(maximumLength: 30, ErrorMessage = "Maksimum 30 simvol ola biler")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirePassword { get; set; }

    }
}
