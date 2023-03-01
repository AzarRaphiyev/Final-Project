using Microsoft.AspNetCore.Mvc;

namespace JobBoard.Controllers
{
    public class ApplicantsController : Controller
    {
        private readonly JobBoardContext jobBoardContext;

        public ApplicantsController(JobBoardContext jobBoardContext)
        {
            this.jobBoardContext = jobBoardContext;
        }


        #region Index
        [Authorize(Roles = "Company,Superadmin,Admin")]
        public async Task<IActionResult> Index(string username)
        {
            Company company = jobBoardContext.companies.FirstOrDefault(x=>x.UserName==username);
            if (company==null )
            {
                return View("error");
            }

            List<JobSeeker> jobSeeker = jobBoardContext.jobSeekers.Include(x=>x.Job).Where(x=>x.CompanyId==company.Id).Where(x=>x.IsCompleted==false).OrderByDescending(x=>x.Id).ToList();
            return View(jobSeeker);
        }

        #endregion

        #region Accept
        [Authorize(Roles = "Company,Superadmin,Admin")]


        public IActionResult Accept(int id)
        {
            JobSeeker jobSeeker=jobBoardContext.jobSeekers.FirstOrDefault(x=>x.Id==id);
            if (jobSeeker==null) { return View("error"); }

            Job job = jobBoardContext.Jobs.FirstOrDefault(x => x.Id == jobSeeker.JobId);
            if (job==null)
            {
                return View("error");
            }
            if (job.Vacancy>0)
            {
            job.Vacancy -= 1;
            }

            if (job.Vacancy==0)
            {
                job.IsFull = true;
            }

            jobSeeker.IsCompleted = true;


            jobBoardContext.SaveChanges();

            return RedirectToAction("Index","home");
        }
        #endregion

        #region Delete
        [Authorize(Roles = "Company,Superadmin,Admin")]
        public IActionResult Delete(int id) 
        {
        
             JobSeeker jobSeeker=jobBoardContext.jobSeekers.FirstOrDefault(x=>x.Id== id);    
            if (jobSeeker==null)  return View("error");
            jobBoardContext.jobSeekers.Remove(jobSeeker);
            jobBoardContext.SaveChanges();
            return RedirectToAction("index");
        }


        #endregion




    }
}
