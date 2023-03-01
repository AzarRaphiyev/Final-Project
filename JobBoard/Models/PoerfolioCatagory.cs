namespace JobBoard.Models
{
	public class PoerfolioCatagory
	{
		public int Id { get; set; }
		[Required]
		[StringLength(maximumLength:25,ErrorMessage = "Can be a maximum of 25 simvols")]
		public string Name { get; set; }
	}
}
