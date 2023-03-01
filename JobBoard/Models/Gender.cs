namespace JobBoard.Models
{
	public class Gender
	{
		public int Id { get; set; }
		[Required]
		[StringLength(maximumLength: 40, ErrorMessage = "Can be a maximum of 40 characters")]
		public string GenderType { get; set; }
	}
}
