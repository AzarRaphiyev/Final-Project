namespace JobBoard.Areas.manage.services
{
    public class AdminLayoutService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly JobBoardContext jobBoardContext;

        public AdminLayoutService(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor,JobBoardContext jobBoardContext)
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

        public List<Company> GetCompanies()
        {
            List<Company> companies = jobBoardContext.companies.OrderByDescending(x=>x.Id).Take(3).ToList();
            return companies;
        }
        public List<Contact> GetContacts()
        {
            List<Contact> contacts=jobBoardContext.Contacts.Where(x=>x.IsViewed==false).OrderByDescending(x => x.Id).Take(7).ToList();
            return contacts;
        }
        public List<CommentSite> GetComment()
        {
            List<CommentSite> commentSites=jobBoardContext.commentSites.Where(x => x.IsViewed == false).OrderByDescending(x=>x.Id).Take(7).ToList();
            return commentSites;    
        }

    }
}
