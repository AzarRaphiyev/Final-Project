namespace JobBoard.Models
{
	public class PortfolioItem
	{
		public int Id { get; set; }
		public int poerfolioCatagoriesId { get; set; }
		public int TeamId { get; set; }
		public int Order { get; set; }
		[Required]
		[StringLength(maximumLength: 80, ErrorMessage = "Can be a maximum of 80 simvols")]
		public string Title { get; set; }
		[Required]
		[StringLength(maximumLength: 2500, ErrorMessage = "Can be a maximum of 2500 simvols")]
		public string Description { get; set; }
		[Required]
		
		[DataType(DataType.DateTime)]
		public DateTime YearStarted { get; set; }

		[Required]
		[StringLength(maximumLength: 30, ErrorMessage = "Can be a maximum of 30 simvols")]
		public string Client { get; set; }
		[StringLength(maximumLength: 250, ErrorMessage = "Can be a maximum of 250 simvols")]
		public string? WebUrl { get; set; }
		public List<PortfolioItemImages>? portfolioItemImages { get; set; }

		[NotMapped]
		public List<IFormFile>? ImageFiles { get; set; }

		[NotMapped]
		public IFormFile? PosterImageFile { get; set; }
		public Team? Team { get; set; }
		public PoerfolioCatagory? poerfolioCatagories { get; set; }
		[NotMapped]
		public List<int>? PortfolioImageIds { get; set; }


	}
}
