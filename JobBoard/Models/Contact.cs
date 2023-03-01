namespace JobBoard.Models
{
	public class Contact
	{
		public int Id { get; set; }
		[Required]
		[StringLength(maximumLength:30,ErrorMessage = "Can be a maximum of 30 characters")]
		public string Name { get; set; }
		[Required]
		[StringLength(maximumLength: 30, ErrorMessage = "Can be a maximum of 30 characters")]
		public string Surname { get; set; }

		[Required]
		[StringLength(maximumLength: 100, ErrorMessage = "Can be a maximum of 100 characters")]
		[DataType(DataType.EmailAddress)]
		public string Email	 { get; set; }

		[Required]
		[StringLength(maximumLength: 300, ErrorMessage = "Can be a maximum of 300 characters")]
		public string Subject { get; set; }
		[Required]
		[StringLength(maximumLength: 3000, ErrorMessage = "Can be a maximum of 3000 characters")]
		public string Message { get; set; }

		[StringLength(maximumLength: 50, ErrorMessage = "Can be a maximum of 50 characters")]
		[DataType(DataType.DateTime)]
		public DateTime? Data { get; set; }
		public bool IsViewed { get; set; }=false;
	}
}
