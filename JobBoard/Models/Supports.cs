namespace JobBoard.Models
{
	public class Supports
	{
		public int Id { get; set; }
		public int Order { get; set; }

		[StringLength(maximumLength: 100, ErrorMessage = "Can be a maximum of 100 characters")]
		public string? Image { get; set; }

		[NotMapped]
		public IFormFile? ImageFile { get; set; }

	}
}
