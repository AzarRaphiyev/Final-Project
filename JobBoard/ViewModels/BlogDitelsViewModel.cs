namespace JobBoard.ViewModels
{
	public class BlogDitelsViewModel
	{
		public Blog? Blog { get; set; }
		public List<Catagory>? catagories { get; set; }
		public AppUser? User { get; set; }
		public CommentBlog? CommentBlogView { get; set; }

		[Required]
		[StringLength(maximumLength: 1000, ErrorMessage = "Maksimum 1000 simvol olmalidir")]
		public string CommentDescription { get; set; }
	}
}
