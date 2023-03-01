using Microsoft.AspNetCore.Mvc;

namespace JobBoard.Controllers
{
	public class TestimonialsController : Controller
	{
		private readonly JobBoardContext jobBoardContext;

		public TestimonialsController(JobBoardContext jobBoardContext)
		{
			this.jobBoardContext = jobBoardContext;
		}

		#region Index
		public IActionResult Index()
		{
			List<CommentSite> comments = jobBoardContext.commentSites.Where(x=>x.IsFavorıte==true).Take(8).ToList();
			return View(comments);
		}

		#endregion
	}
}
