namespace JobBoard.ViewModels
{
	public class MemberRegisterViewModel
	{
		[Required]
		[StringLength(maximumLength: 30, ErrorMessage = "Maksimum 30 simvol ola biler")]
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
		[StringLength(maximumLength: 30, MinimumLength = 8, ErrorMessage = "Maksimum 30,minimum 8 simvol ola biler")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		[StringLength(maximumLength: 30, ErrorMessage = "Maksimum 30 simvol ola biler")]
		[DataType(DataType.Password)]
		[Compare("Password")]
		public string ConfirePassword { get; set; }

		[StringLength(maximumLength: 100, ErrorMessage = "Maksimum 100 simvol ola biler")]
		public string? Image { get; set; }

		[NotMapped]
		public IFormFile Imagefile { get; set; }

		[StringLength(maximumLength: 100, ErrorMessage = "Maksimum 100 simvol ola biler")]
		public string? Cv { get; set; }

		[NotMapped]
		public IFormFile CvFile { get; set; }

	}
}
