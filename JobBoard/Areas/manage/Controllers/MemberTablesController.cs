

namespace JobBoard.Areas.manage.Controllers
{
	[Area("manage")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class MemberTablesController : Controller
	{
		private readonly JobBoardContext jobBoardContext;

		public MemberTablesController(JobBoardContext jobBoardContext)
		{
			this.jobBoardContext = jobBoardContext;
		}
        #region Index
        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Index()
		{

			List<AppUser>	users = jobBoardContext.Users.Where(x=>x.Role=="Member").ToList();
			return View(users);
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
			Member member = jobBoardContext.members.FirstOrDefault(x => x.Fullname == user.FullName);
			if (member == null)
			{
				return View("Error");
			}
			jobBoardContext.members.Remove(member);
			jobBoardContext.Remove(user);
			jobBoardContext.SaveChanges();
			return Ok();
		}
        #endregion


	}
}
