using JobBoard.Helpers;
using JobBoard.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobBoard.Areas.manage.Controllers
{
	[Area("manage")]
	public class SupportsCompanyController : Controller
	{
		private readonly JobBoardContext jobBoardContext;
		private readonly IWebHostEnvironment webHostEnvironment;

		public SupportsCompanyController(JobBoardContext jobBoardContext,IWebHostEnvironment webHostEnvironment)
		{
			this.jobBoardContext = jobBoardContext;
			this.webHostEnvironment = webHostEnvironment;
		}
        #region Index
        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Index(int page=1)
		{
		
			var query = jobBoardContext.supportsCompany.AsQueryable();

			var paginatedlist = PaginationList<Supports>.Create(query, 3, page);
			return View(paginatedlist);
		}

        #endregion
        #region Create

        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Create(Supports supports)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			if (supports.ImageFile != null)
			{
				if (supports.ImageFile.ContentType != "image/png" && supports.ImageFile.ContentType != "image/jpeg")
				{
					ModelState.AddModelError("ImageFile", "But Png, Jpeg and Jpg can be downloaded");
					return View();
				}
				if (supports.ImageFile.Length > 3145728)
				{
					ModelState.AddModelError("ImageFile", "It cannot be more than 3 MB");
					return View();
				}
				supports.Image = FileManager.SaveFile(webHostEnvironment.WebRootPath, "uploads/supports", supports.ImageFile);
				jobBoardContext.supportsCompany.Add(supports);
			}
			jobBoardContext.SaveChanges();
			return RedirectToAction("Index");
		}
        #endregion

        #region Update
        [Authorize(Roles = "SuperAdmin,Admin")]

        public IActionResult Update(int id)
		{
			Supports EditSup = jobBoardContext.supportsCompany.FirstOrDefault(x => x.Id == id);

			if (EditSup == null) { return View("error"); }
			return View(EditSup);
		}

		[HttpPost]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Update(Supports supportsUpdate)
		{
			Supports ExtSupport = jobBoardContext.supportsCompany.FirstOrDefault(x => x.Id == supportsUpdate.Id);


			if (ExtSupport == null) { return View("error"); }
			if (!ModelState.IsValid)
			{
				return View();
			}
			if (supportsUpdate.ImageFile != null)
			{
				if (supportsUpdate.ImageFile.ContentType != "image/png" && supportsUpdate.ImageFile.ContentType != "image/jpeg")
				{
					ModelState.AddModelError("ImageFile", "But Png, Jpeg and Jpg can be downloaded");
					return View();
				}
				if (supportsUpdate.ImageFile.Length > 3145728)
				{
					ModelState.AddModelError("ImageFile", "It cannot be more than 3 MB");
					return View();
				}
				FileManager.DeleteFile(webHostEnvironment.WebRootPath, "uploads/supports", ExtSupport.Image);
				ExtSupport.Image = FileManager.SaveFile(webHostEnvironment.WebRootPath, "uploads/supports", supportsUpdate.ImageFile);
			}

			jobBoardContext.SaveChanges();
			return RedirectToAction("Index");
		}
        #endregion

        #region Delete

        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Delete(int id)
		{
			Supports supports = jobBoardContext.supportsCompany.FirstOrDefault(x => x.Id == id);
			if (supports == null) { return View("error"); }
			jobBoardContext.supportsCompany.Remove(supports);
			jobBoardContext.SaveChanges();
			return Ok();
		}
        #endregion
	}
}
