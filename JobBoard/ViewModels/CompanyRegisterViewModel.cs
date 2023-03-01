namespace JobBoard.ViewModels
{
	public class CompanyRegisterViewModel
	{
		[Required]
		[StringLength(maximumLength: 30, ErrorMessage = "Maksimum 30 simvol ola biler")]
		public string CompanyName { get; set; }

		[Required]
		[StringLength(maximumLength: 100, ErrorMessage = "Maksimum 100 simvol ola biler")]
		[DataType(DataType.EmailAddress)]
		public string CompanyEmail { get; set; }
		[Required]
		[StringLength(maximumLength: 300, ErrorMessage = "Maksimum 300 simvol ola biler")]
		public string CompanyLocation { get; set; }
		[StringLength(maximumLength: 100, ErrorMessage = "Maksimum 100 simvol ola biler")]
		public string? CompanyUserName { get; set; }

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
        public IFormFile ImageFile { get; set; }

		[Required]
		[StringLength(maximumLength: 100, ErrorMessage = "Maksimum 100 simvol ola biler")]
		public string Slogan { get; set; }
		[Required]
		[StringLength(maximumLength: 3000, ErrorMessage = "Maksimum 3000 simvol ola biler")]
		public string Description { get; set; }

		[StringLength(maximumLength: 100, ErrorMessage = "Maksimum 100 simvol ola biler")]
		public string? InstagramUrl { get; set; }
		[StringLength(maximumLength: 100, ErrorMessage = "Maksimum 100 simvol ola biler")]
		public string? FecebookUrl { get; set; }
		[StringLength(maximumLength: 100, ErrorMessage = "Maksimum 100 simvol ola biler")]
		public string? TwitterUrl { get; set; }
		[StringLength(maximumLength: 100, ErrorMessage = "Maksimum 100 simvol ola biler")]
		public string? LinkedinUrl { get; set; }


	}
}
