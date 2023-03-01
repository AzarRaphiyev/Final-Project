namespace JobBoard.Models
{
	public class QuestionsSectionImage
	{
		public int Id { get; set; }
		
		[StringLength(maximumLength: 100, ErrorMessage = "Can be a maximum of 100 characters")]
		public string? Image { get; set; }

		[NotMapped]
		public IFormFile? ImageFile { get; set; }
	}
}
