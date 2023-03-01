namespace JobBoard.Services
{
	public class LayoutServices
	{
        private readonly UserManager<AppUser> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;
		private readonly JobBoardContext jobBoardContext;

		public LayoutServices(UserManager<AppUser> userManager,IHttpContextAccessor httpContextAccessor,JobBoardContext jobBoardContext)
		{
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
			this.jobBoardContext = jobBoardContext;
		}
        public async Task<AppUser> GetUser()
        {
            AppUser user = await userManager.FindByNameAsync(httpContextAccessor.HttpContext.User.Identity.Name);

            return user;
        }
        public  List<JobSeeker> GetSeeker()
        {
            List<JobSeeker> jobSeekers = jobBoardContext.jobSeekers.OrderByDescending(X => X.Id).ToList();

            return jobSeekers;
        }
	}
}
