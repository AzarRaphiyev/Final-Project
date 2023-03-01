using JobBoard.Models;

namespace JobBoard.Database
{
	public class JobBoardContext:IdentityDbContext
	{
		public JobBoardContext(DbContextOptions<JobBoardContext> options): base (options)
		{
		}
			public DbSet<AppUser> Users { get; set; }
		public DbSet<Member> members { get; set; }
		public DbSet<Company> companies { get; set; }
		public DbSet<Position> positions { get; set; }
		public DbSet<Team> JonTeamMembers { get; set; }
		public DbSet<MiniInfoBar> miniInfoBars { get; set; }
		public DbSet<Catagory> catagories { get; set; }
		public DbSet<Authour> authours { get; set; }
		public DbSet<Blog> blogs { get; set; }
		public DbSet<ServicesSite> services  { get; set; }
		public DbSet<ContactİnfoBar> ContactİnfoBars  { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<JobType> jobTypes { get; set; }
		public DbSet<CommentBlog> commentBlogs { get; set; }
		public DbSet<QuestionsSectionImage> questionsSectionImages  { get; set; }
		public DbSet<QuestionsAndAnswer> questionsAndAnswers  { get; set; }
		public DbSet<CommentSite> commentSites { get; set; }
		public DbSet<PoerfolioCatagory> poerfolioCatagories { get; set; }
		public DbSet<PortfolioItem> portfolioItems { get; set; }
		public DbSet<PortfolioItemImages> portfolioItemImages { get; set; }
		public DbSet<JobRegion> Regions { get; set; }
		public DbSet<Gender> genders { get; set; }
		public DbSet<Job> Jobs { get; set; }
		public DbSet<Supports> supportsCompany { get; set; }
		public DbSet<Reklam> reklams { get; set; }
		public DbSet<JobSeeker> jobSeekers { get; set; }
		public DbSet<Setting> settings { get; set; }
	}
}
