namespace JobBoard.Models
{
	public class JobType
	{
		public int Id { get; set; }

		[Required]
		[StringLength(maximumLength:30,ErrorMessage = "can be a maximum of 30 characters")]
		public string Type { get; set; }
	}
}
