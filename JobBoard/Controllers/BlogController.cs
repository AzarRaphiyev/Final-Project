using JobBoard.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Reflection.Metadata.BlobBuilder;

namespace JobBoard.Controllers
{
    public class BlogController : Controller
    {
        private readonly JobBoardContext jobBoardContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public BlogController(JobBoardContext jobBoardContext,IWebHostEnvironment webHostEnvironment)
        {
            this.jobBoardContext = jobBoardContext;
            this.webHostEnvironment = webHostEnvironment;
        }
        #region index
        public IActionResult Index(int page=1)
        {
          
			var query = jobBoardContext.blogs.Include(x => x.Authour).Include(x => x.Catagory).OrderBy(x => x.order).AsQueryable();

			var paginatedlist = PaginationList<Blog>.Create(query, 9, page);
			return View(paginatedlist);
		}

        #endregion

        #region Details

        public IActionResult Details(int id)
        {
          
            Blog blog=jobBoardContext.blogs.
                                            Include(x=>x.Authour).
                                            Include(x=>x.Catagory).
                                            Include(x=>x.commentBlogs.OrderByDescending(x => x.Id)).
                                            FirstOrDefault(x=>x.Id==id);

			if (blog == null)
			{
				return View("Error");
			}

            BlogDitelsViewModel blogDitelsViewModel = new BlogDitelsViewModel
            {
                User = jobBoardContext.Users.FirstOrDefault(x => x.UserName == User.Identity.Name),
                Blog = blog,
                catagories = jobBoardContext.catagories.OrderByDescending(x=>x.Id).ToList(),
            };

           return View(blogDitelsViewModel);
		}
        [HttpPost]
        public IActionResult Details(BlogDitelsViewModel blogDitelsVM,int id) 
        {
			Blog blog = jobBoardContext.blogs.
											Include(x => x.Authour).
											Include(x => x.Catagory).
											Include(x => x.commentBlogs.OrderByDescending(x=>x.Id)).
											FirstOrDefault(x => x.Id == id);
			if (blog == null)
			{
				return View("Error");
			}

			BlogDitelsViewModel blogDitelsViewModel = new BlogDitelsViewModel
			{
				User = jobBoardContext.Users.FirstOrDefault(x => x.UserName == User.Identity.Name),
				Blog = blog,
				catagories = jobBoardContext.catagories.ToList(),
                CommentDescription=blogDitelsVM.CommentDescription
			};

            if (!ModelState.IsValid)
            {
                return View(blogDitelsViewModel);
            }
            CommentBlog commentBlog = new CommentBlog
            {
                Data = DateTime.Now,
                Blog = blogDitelsViewModel.Blog,
                Username= blogDitelsViewModel.User.UserName,
                Image=blogDitelsViewModel.User.Image,
                Description=blogDitelsViewModel.CommentDescription
            };
            

            jobBoardContext.commentBlogs.Add(commentBlog);
            jobBoardContext.SaveChanges();
            
            //return View(blogDitelsViewModel);

            return RedirectToAction("Details","Blog",blogDitelsViewModel);
		}
        #endregion

    }
}
