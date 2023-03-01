namespace JobBoard.Models
{
	public class PortfolioItemImages
	{
		public int Id { get; set; }
		public int PortfolioItemId { get; set; }
		[StringLength(maximumLength: 100, ErrorMessage = "Can be a maximum of 100 simvols")]

		public string? Images { get; set; }

		public bool? IsPoster { get; set; }

		public PortfolioItem? portfolioItem { get; set; }
	}
}
