namespace JobBoard.Models
{
	public class Member
	{
		public int Id { get; set; }
		[Required]
		[StringLength(maximumLength: 30, ErrorMessage = "Maksimum 30 simvol ola biler")]
		public string Fullname { get; set; }

		

		[Required]
		[StringLength(maximumLength: 100, ErrorMessage = "Maksimum 100 simvol ola biler")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required]
		[StringLength(maximumLength: 30, ErrorMessage = "Maksimum 30 simvol ola biler")]
		public string UserName { get; set; }




	
		[StringLength(maximumLength: 100, MinimumLength = 8, ErrorMessage = "Maksimum 100 simvol ola biler")]
		public string? Image { get; set; }

		
		[StringLength(maximumLength: 100, MinimumLength = 8, ErrorMessage = "Maksimum 100 simvol ola biler")]
		public string? Cv { get; set; }

		[NotMapped]
		public IFormFile ImageFile { get; set; }
		[NotMapped]
		public IFormFile CvFile { get; set; }


	}
}
