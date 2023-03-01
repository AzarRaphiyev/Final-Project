namespace JobBoard.ViewModels
{
	public class AboutViewModel
	{
		public List<AppUser> companies { get; set; }
		public List<AppUser> members  { get; set; }
		public List<Team> TeamMembers  { get; set; }
		public List<MiniInfoBar> miniInfoBars { get; set; }
		public List<Job> jobs { get; set; }
	}
}
