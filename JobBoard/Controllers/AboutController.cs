using Microsoft.AspNetCore.Mvc;

namespace JobBoard.Controllers
{
    public class AboutController : Controller
    {
        private readonly JobBoardContext jobBoardContext;

        public AboutController(JobBoardContext jobBoardContext)
        {
            this.jobBoardContext = jobBoardContext;
        }
        #region Index
        public IActionResult Index()
        {
            AboutViewModel aboutVM = new AboutViewModel
            {
                members = jobBoardContext.Users.Where(x=>x.Role=="Member").ToList(),
                companies = jobBoardContext.Users.Where(x=>x.Role=="Company"&& x.Enabled==true).ToList(),
                TeamMembers=jobBoardContext.JonTeamMembers.Include(x=>x.position).Take(2).OrderBy(x=>x.Order).ToList(),
                miniInfoBars = jobBoardContext.miniInfoBars.OrderBy(x=>x.order).Take(2).ToList(),
                jobs=jobBoardContext.Jobs.ToList(),
            };
            return View(aboutVM);
        }

        #endregion
    }
}
