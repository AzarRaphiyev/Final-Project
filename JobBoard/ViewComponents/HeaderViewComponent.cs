namespace JobBoard.ViewComponents
{
	public class HeaderViewComponent:ViewComponent
	{


		private readonly JobBoardContext jobBoardContext;

		public HeaderViewComponent(JobBoardContext jobBoardContext)
		{
			this.jobBoardContext = jobBoardContext;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			AppUser users = jobBoardContext.Users.FirstOrDefault();

			return View(await Task.FromResult(users));
		}





	}
}
