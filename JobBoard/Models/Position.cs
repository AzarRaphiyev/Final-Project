namespace JobBoard.Models
{
	public class Position
	{
		public int id { get; set; }

		[StringLength(maximumLength: 100, ErrorMessage = "It can be 100 characters")]
		public string Jobname { get; set; }
	}
}
