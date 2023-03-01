using JobBoard.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobBoard.Areas.manage.Controllers
{
    [Area("manage")]
    public class AppUsersController : Controller
    {
        private readonly JobBoardContext jobBoardContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AppUsersController( JobBoardContext jobBoardContext,IWebHostEnvironment webHostEnvironment)
        {
            this.jobBoardContext = jobBoardContext;
            this.webHostEnvironment = webHostEnvironment;
        }
        #region Index
 [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Index(int page=1)
        {
			var query = jobBoardContext.Users.AsQueryable();

			var paginatedlist = PaginationList<AppUser>.Create(query, 3, page);
			return View(paginatedlist);
		
        }
        #endregion

        #region Actvated_user
  [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Activateuser(string id)
        {
            AppUser appUser=jobBoardContext.Users.FirstOrDefault(x=>x.Id== id);
            if (appUser==null) { return View("error"); }
            appUser.Enabled= true;
            jobBoardContext.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
 [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Delete(string id) 
        {
        AppUser appUser=jobBoardContext.Users.FirstOrDefault(x=>x.Id == id);    
            if (appUser==null)  return View("error");
            Company company = jobBoardContext.companies.FirstOrDefault(x => x.UserName == appUser.UserName);
            if (company==null)
            {
                Member member= jobBoardContext.members.FirstOrDefault(x=>x.UserName== appUser.UserName);
                if (member==null)
                {
                    return View("error");
                }
                else
                {
                    jobBoardContext.members.Remove(member);
                }
            }
            else
            {
             jobBoardContext.companies.Remove(company);
            }
            FileManager.DeleteFile(webHostEnvironment.WebRootPath, "uploads/users", appUser.Image);
            jobBoardContext.Users.Remove(appUser);
           
            jobBoardContext.SaveChanges();
			return Ok();
		}
        #endregion



       
    }
}
