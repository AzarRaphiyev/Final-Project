using Microsoft.AspNetCore.Mvc;

namespace JobBoard.Controllers
{
    public class JobSeekerController : Controller
    {
        private readonly JobBoardContext jobBoardContext;

        public JobSeekerController(JobBoardContext jobBoardContext)
        {
            this.jobBoardContext = jobBoardContext;
        }
        #region Index
        public IActionResult Index()
        {
            
            return View();
        }

        #endregion

        #region Apply
        public IActionResult Apply(int jobId)
        {
            AppUser appUser=jobBoardContext.Users.FirstOrDefault(x=>x.UserName==User.Identity.Name);
            if (appUser==null) { return View ("error"); }
            Job job=jobBoardContext.Jobs.FirstOrDefault(x=>x.Id==jobId);
            if (job==null)
            {
                return View("error");
            }
            JobSeeker jobSeeker = new JobSeeker
            {
                FullName= appUser.FullName,
                Email= appUser.Email,
                Image=appUser.Image,
                Cv=appUser.Cv,
                JobId=job.Id,
                CompanyId=job.CompanyId,
            };

            jobBoardContext.jobSeekers.Add(jobSeeker);
            jobBoardContext.SaveChanges();
            return RedirectToAction("index","job");
        }

        #endregion
    }
}
