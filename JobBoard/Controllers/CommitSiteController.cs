using JobBoard.Helpers;
using JobBoard.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobBoard.Controllers
{
    public class CommitSiteController : Controller
    {
        private readonly JobBoardContext jobBoardcontext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CommitSiteController(JobBoardContext jobBoardcontext, IWebHostEnvironment webHostEnvironment)
        {
            this.jobBoardcontext = jobBoardcontext;
            this.webHostEnvironment = webHostEnvironment;
        }
        #region index
        public IActionResult Index()
        {
            List<CommentSite>   comments = jobBoardcontext.commentSites.ToList();
            return View(comments);
        }

        #endregion

        #region Create

        public IActionResult Create()
        {
            ViewBag.comment=jobBoardcontext.commentSites.Where(x=>x.IsFavorıte).Take(2).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(CommentSite commentSite)
        {
			ViewBag.comment = jobBoardcontext.commentSites.Where(x => x.IsFavorıte).Take(2).ToList();
			if (!ModelState.IsValid)
            {
                return View();
            }
            if (commentSite == null)
            {
                return View("error");
            }
            if (commentSite.ImageFile != null)
            {

                if (commentSite.ImageFile.ContentType != "image/png" && commentSite.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "But Png, Jpeg and Jpg can be downloaded");
                    return View();
                }
                if (commentSite.ImageFile.Length > 3145728)
                {
                    ModelState.AddModelError("ImageFile", "The size cannot exceed 3 MB");
                    return View();
                }
                commentSite.Commentatorİmage = FileManager.SaveFile(webHostEnvironment.WebRootPath, "uploads/commentsite", commentSite.ImageFile);
                commentSite.Data = DateTime.Now;
                jobBoardcontext.commentSites.Add(commentSite);
            }
            jobBoardcontext.SaveChanges();
            return RedirectToAction("Create","CommitSite");
        }
        #endregion


		
    }
}