

using Microsoft.AspNetCore.Mvc.RazorPages;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JobBoard.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles ="SuperAdmin")]
    public class AdminTablesController : Controller
    {
        private readonly JobBoardContext jobBoardContext;

        public AdminTablesController(JobBoardContext jobBoardContext)
        {
            this.jobBoardContext = jobBoardContext;
        }
        #region Index
   public IActionResult Index(int page=1)
        {
            var query = jobBoardContext.Users.Where(x => x.Role == "Admin").AsQueryable();
			var paginatedlist = PaginationList<AppUser>.Create(query, 3, page);
			return View(paginatedlist);
        }
        #endregion


        #region Delete
 [Authorize(Roles = "SuperAdmin")]
        public IActionResult Delete(string id) 
        {
            AppUser user= jobBoardContext.Users.FirstOrDefault(x=>x.Id==id);
            if (user==null)
            {
                return View("Error");
            }
            jobBoardContext.Remove(user);
            jobBoardContext.SaveChanges();
            return Ok();
        }
        #endregion
       
    }
}
