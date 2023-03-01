namespace JobBoard.Models
{
	public class CommentBlog
	{
		public int Id { get; set; }
		public int BlogId { get; set; }

		[Required]
		[StringLength(maximumLength:1000,ErrorMessage ="Maksimum 1000 simvol olmalidir")]
		public string Description { get; set; }

		[Required]
		[StringLength(maximumLength: 100, ErrorMessage = "Maksimum 100 simvol olmalidir")]
		[DataType(DataType.DateTime)]
		public DateTime Data { get; set; } 

		[StringLength(maximumLength: 1000, ErrorMessage = "Maksimum 100 simvol olmalidir")]
		public string? Image { get; set; }

		[StringLength(maximumLength: 1000, ErrorMessage = "Maksimum 100 simvol olmalidir")]
		public string Username { get; set; }
		

		public Blog? Blog { get; set; }
	}
}
