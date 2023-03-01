

namespace JobBoard.Areas.manage.Controllers
{
	[Area("manage")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class CompanyTablesController : Controller
	{
		private readonly JobBoardContext jobBoardContext;

		public CompanyTablesController(JobBoardContext jobBoardContext)
		{
			this.jobBoardContext = jobBoardContext;
		}
		#region Index

		[Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Index(int page=1)
		{
			var query = jobBoardContext.Users.Where(x => x.Role == "Company" && x.Enabled == true).AsQueryable();

			var paginatedlist = PaginationList<AppUser>.Create(query, 3, page);
			return View(paginatedlist);
			
		}
		#endregion


		#region Delete

        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Delete(string id)
		{
			AppUser user = jobBoardContext.Users.FirstOrDefault(x => x.Id == id);
			if (user == null)
			{
				return View("Error");
			}
		

			jobBoardContext.Remove(user);
			jobBoardContext.SaveChanges();
			return Ok();
		}
		#endregion
	}
}
