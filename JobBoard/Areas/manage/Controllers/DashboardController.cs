

namespace JobBoard.Areas.manage.Controllers
{
	[Area("manage")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class DashboardController : Controller
	{
		private readonly JobBoardContext jobBoardContext;

		public DashboardController(JobBoardContext jobBoardContext)
		{
			this.jobBoardContext = jobBoardContext;
		}
		#region Index

		[Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Index()
		{
			DashboardViewModel dashboardViewModel = new DashboardViewModel
			{
				admins = jobBoardContext.Users.Where(x => x.Role == "Admin").ToList(),
				members = jobBoardContext.Users.Where(x => x.Role == "Company").ToList(),
				companies = jobBoardContext.companies.ToList(),
				commentSites = jobBoardContext.commentSites.ToList(),
				teams = jobBoardContext.JonTeamMembers.ToList(),
				contacts=jobBoardContext.Contacts.ToList(),
				jobs=jobBoardContext.Jobs.ToList(),
				seekers=jobBoardContext.jobSeekers.Where(X=>X.IsCompleted==true).ToList(),


			};
			return View(dashboardViewModel);
		}
		#endregion
	}
}
