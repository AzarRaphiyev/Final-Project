using Microsoft.AspNetCore.Mvc;

namespace JobBoard.Controllers
{
    public class CatagoryController : Controller
    {
        private readonly JobBoardContext jobBoardContext;

        public CatagoryController(JobBoardContext jobBoardContext)
        {
            this.jobBoardContext = jobBoardContext;
        }
        #region Index
        public IActionResult Index(int id)
        { 
            List<Blog> blogs = jobBoardContext.blogs.Include(x=>x.Authour).Include(x=>x.Catagory).OrderBy(x=>x.order).Where(x=>x.CatagoryId== id).ToList();
            return View(blogs);
        }

        #endregion
    }
}
