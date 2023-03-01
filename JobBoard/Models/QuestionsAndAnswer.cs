namespace JobBoard.Models
{
	public class QuestionsAndAnswer
	{
		public int Id { get; set; }
		public int order { get; set; }
		[Required]

		[StringLength(maximumLength: 100, ErrorMessage = "Can be a maximum of 100 characters")]
		public string Question { get; set; }

		[Required]
		[StringLength(maximumLength: 500, ErrorMessage = "Can be a maximum of 500 characters")]
		public string Answer { get; set; }
	}
}
