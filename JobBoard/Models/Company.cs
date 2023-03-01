namespace JobBoard.Models
{
    public class Company
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
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Maksimum 100 simvol ola biler")]
        public string Location { get; set; }

		[Required]
        [StringLength(maximumLength: 100, MinimumLength = 8, ErrorMessage = "Maksimum 100 simvol ola biler")]
        public string? Image { get; set; }
		[NotMapped]
		public IFormFile? ImageFile { get; set; }

        


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

        public List<JobSeeker>? JobSeekers { get; set; }
	}
}
