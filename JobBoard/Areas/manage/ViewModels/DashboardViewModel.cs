namespace JobBoard.Areas.manage.ViewModels
{
	public class DashboardViewModel
	{
		public List<CommentSite> commentSites { get; set; }  
		public List<Company> companies { get; set; }
		public List<Team> teams { get; set; }
		public List<AppUser> members { get; set; }
		public List<AppUser> admins { get; set; }
		public List<Contact> contacts { get; set; }
		public List<Job> jobs { get; set; }
		public List<JobSeeker> seekers { get; set; }
		
		
	}
}
