namespace JobBoard.Models
{
	public class Reklam
	{
		public int Id { get; set; }
		public int Order { get; set; }
		[Required]
		[StringLength(maximumLength:50,ErrorMessage = "Can be a maximum of 50 characters")]
		public string Tittle { get; set; }

		[Required]
		[StringLength(maximumLength: 500, ErrorMessage = "Can be a maximum of 500 characters")]
		public string Description { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Can be a maximum of 100 characters")]
        public string? Image { get; set; }
		[NotMapped]
		public IFormFile ImageFile { get; set; }
		[Required]

        public DateTime DeadlineTime { get; set; }
        public DateTime PublishedOn { get; set; }
	}
}
