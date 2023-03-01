namespace JobBoard.ViewModels
{
	public class IndexViewModel
	{
		public List<Job> jobs { get; set; }
		public PaginationList<Job> paginatedlist { get; set; }
		public Job job { get; set; }
		public List<Supports> Supports { get; set; }
		public List<Reklam> reklams { get; set; }
		public List<AppUser> Members { get; set; }
		public List<AppUser> Companies { get; set; }
		public List<Team> teams { get; set; }
		public List<Job> fullcobs { get; set; }

		public int regionId { get; set; }
		public int typeid { get; set; }



	}

}
