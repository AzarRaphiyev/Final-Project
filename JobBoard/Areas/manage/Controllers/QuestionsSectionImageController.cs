using JobBoard.Helpers;
using JobBoard.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobBoard.Areas.manage.Controllers
{
	[Area("manage")]
	public class QuestionsSectionImageController : Controller
	{
		private readonly JobBoardContext jobBoardContext;
		private readonly IWebHostEnvironment webHostEnvironment;

		public QuestionsSectionImageController(JobBoardContext jobBoardContext,IWebHostEnvironment webHostEnvironment)
		{
			this.jobBoardContext = jobBoardContext;
			this.webHostEnvironment = webHostEnvironment;
		}
        #region Index
        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Index(int page=1)
		{
			
			var query = jobBoardContext.questionsSectionImages.AsQueryable();

			var paginatedlist = PaginationList<QuestionsSectionImage>.Create(query, 3, page);
			return View(paginatedlist);
		}

        #endregion

        #region Create
        [Authorize(Roles = "SuperAdmin,Admin")]

        public IActionResult Create() { return View(); }
		[HttpPost]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Create(QuestionsSectionImage questionsSectionImage)
		{
			
			if (!ModelState.IsValid)
			{
				return View();
			}
			if (questionsSectionImage.ImageFile!=null)
			{
				if (questionsSectionImage.ImageFile.ContentType != "image/png" && questionsSectionImage.ImageFile.ContentType != "image/jpeg")
				{
					ModelState.AddModelError("ImageFile", "But Png, Jpeg and Jpg can be downloaded");
					return View();
				}
				if (questionsSectionImage.ImageFile.Length > 3145728)
				{
					ModelState.AddModelError("ImageFile", "It cannot be more than 3 MB");
					return View();
				}
				questionsSectionImage.Image = FileManager.SaveFile(webHostEnvironment.WebRootPath, "uploads/QuestionsSectionImage", questionsSectionImage.ImageFile);
				
				jobBoardContext.questionsSectionImages.Add(questionsSectionImage);
			}
			jobBoardContext.SaveChanges();
			return RedirectToAction("Index");
		}
        #endregion

        #region Update

        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Update(int id)
		{
			QuestionsSectionImage questionsSectionImage=jobBoardContext.questionsSectionImages.FirstOrDefault(x => x.Id == id);
            if (questionsSectionImage is null)
            {
                return View("error");
            }
            return View(questionsSectionImage);
		}
		[HttpPost]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Update(QuestionsSectionImage questionsSectionImage)
		{
			if (questionsSectionImage==null) { return View("error"); }
			QuestionsSectionImage extQuestionsSectionImage=jobBoardContext.questionsSectionImages.FirstOrDefault(x=>x.Id== questionsSectionImage.Id);
			if (extQuestionsSectionImage==null) { return View("error"); }
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (questionsSectionImage.ImageFile != null)
			{
				if (questionsSectionImage.ImageFile.ContentType != "image/png" && questionsSectionImage.ImageFile.ContentType != "image/jpeg")
				{
					ModelState.AddModelError("ImageFile", "But Png, Jpeg and Jpg can be downloaded");
					return View();
				}
				if (questionsSectionImage.ImageFile.Length > 3145728)
				{
					ModelState.AddModelError("ImageFile", "It cannot be more than 3 MB");
					return View();
				}
				FileManager.DeleteFile(webHostEnvironment.WebRootPath, "uploads/QuestionsSectionImage", extQuestionsSectionImage.Image);
				extQuestionsSectionImage.Image = FileManager.SaveFile(webHostEnvironment.WebRootPath, "uploads/QuestionsSectionImage", questionsSectionImage.ImageFile);
			}
			jobBoardContext.SaveChanges();
			return RedirectToAction("index");

		}
        #endregion

        #region Delete
        [Authorize(Roles = "SuperAdmin,Admin")]

        public IActionResult Delete(int Id)
		{
			QuestionsSectionImage questionsSectionImage = jobBoardContext.questionsSectionImages.FirstOrDefault(x=>x.Id==Id); 
			if (questionsSectionImage==null) return View("error");
			FileManager.DeleteFile(webHostEnvironment.WebRootPath, "uploads/QuestionsSectionImage", questionsSectionImage.Image);
			jobBoardContext.questionsSectionImages.Remove(questionsSectionImage);
			jobBoardContext.SaveChanges();
			return Ok();

		}

        #endregion
	}
}
