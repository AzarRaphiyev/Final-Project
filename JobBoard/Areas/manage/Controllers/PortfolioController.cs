using JobBoard.Helpers;
using JobBoard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JobBoard.Areas.manage.Controllers
{
	[Area("manage")]
	public class PortfolioController : Controller
	{
		private readonly JobBoardContext jobBoardContext;
		private readonly IWebHostEnvironment webHostEnvironment;

		public PortfolioController(JobBoardContext jobBoardContext, IWebHostEnvironment webHostEnvironment)
		{
			this.jobBoardContext = jobBoardContext;
			this.webHostEnvironment = webHostEnvironment;
		}
        #region Index
        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Index(int page=1)
		{
			
			var query = jobBoardContext.portfolioItems.Include(x => x.Team).Include(x => x.poerfolioCatagories).Include(x => x.portfolioItemImages).AsQueryable();

			var paginatedlist = PaginationList<PortfolioItem>.Create(query, 3, page);
			return View(paginatedlist);
		}

        #endregion


        #region Create
        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Create()
		{
			ViewBag.PortfolioCatagory = jobBoardContext.poerfolioCatagories.ToList();
			ViewBag.Team = jobBoardContext.JonTeamMembers.ToList();
			return View();
		}
		[HttpPost]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Create(PortfolioItem portfolioItem)
		{
			ViewBag.PortfolioCatagory = jobBoardContext.poerfolioCatagories.ToList();
			ViewBag.Team = jobBoardContext.JonTeamMembers.ToList();
			if (!ModelState.IsValid)
			{
				return View();
			}
			if (portfolioItem.PosterImageFile != null)
			{
				if (portfolioItem.PosterImageFile.ContentType != "image/png" && portfolioItem.PosterImageFile.ContentType != "image/jpeg")
				{
					ModelState.AddModelError("PosterImageFile", "But Png, Jpeg and Jpg can be downloaded");
					return View();

				}
				if (portfolioItem.PosterImageFile.Length > 3145728)
				{
					ModelState.AddModelError("PosterImageFile", "It cannot be more than 3 MB");
					return View();
				}
				PortfolioItemImages portfolioItemImages = new PortfolioItemImages
				{
					portfolioItem = portfolioItem,
					Images = FileManager.SaveFile(webHostEnvironment.WebRootPath, "uploads/portfolio", portfolioItem.PosterImageFile),
					IsPoster = true
				};

				jobBoardContext.portfolioItemImages.Add(portfolioItemImages);
			}



			if (portfolioItem.ImageFiles != null)
			{

				foreach (var item in portfolioItem.ImageFiles)
				{
					if (item.ContentType != "image/png" && item.ContentType != "image/jpeg")
					{
						ModelState.AddModelError("PosterImageFile", "But Png, Jpeg and Jpg can be downloaded");
						return View();

					}
					if (item.Length > 3145728)
					{
						ModelState.AddModelError("PosterImageFile", "It cannot be more than 3 MB");
						return View();
					}
					PortfolioItemImages Images = new PortfolioItemImages
					{
						portfolioItem = portfolioItem,
						Images = FileManager.SaveFile(webHostEnvironment.WebRootPath, "uploads/portfolio", item),
						IsPoster = null
					};
					jobBoardContext.portfolioItemImages.Add(Images);
				}

			}
			portfolioItem.YearStarted = DateTime.Now;
			jobBoardContext.portfolioItems.Add(portfolioItem);
			jobBoardContext.SaveChanges();
			return RedirectToAction("Index");
		}
        #endregion



        #region Update
        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Update(int id)
		{
			ViewBag.PortfolioCatagory = jobBoardContext.poerfolioCatagories.ToList();
			ViewBag.Team = jobBoardContext.JonTeamMembers.ToList();
			PortfolioItem portfolioItem = jobBoardContext.portfolioItems.
																		Include(x => x.portfolioItemImages)
																		.Include(x => x.Team)
																		.Include(x => x.poerfolioCatagories)
																		.FirstOrDefault(x => x.Id == id);
			if (portfolioItem == null) { return View("error"); }
			return View(portfolioItem);
		}


		[HttpPost]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Update(PortfolioItem portfolioItem)
		{
			ViewBag.PortfolioCatagory = jobBoardContext.poerfolioCatagories.ToList();
			ViewBag.Team = jobBoardContext.JonTeamMembers.ToList();
			if (portfolioItem == null) { return View("error"); }
			PortfolioItem ExtItem = jobBoardContext.portfolioItems.
																   Include(x => x.Team).
																   Include(x => x.poerfolioCatagories).
																   Include(x => x.portfolioItemImages).
																   FirstOrDefault(x => x.Id == portfolioItem.Id);
			if (ExtItem == null) { return View("error"); }
			if (!ModelState.IsValid)
			{
				return View();
			}

			if (portfolioItem.PosterImageFile != null)
			{

				if (portfolioItem.PosterImageFile.ContentType != "image/png" && portfolioItem.PosterImageFile.ContentType != "image/jpeg")
				{
					ModelState.AddModelError("PosterImageFile", "But Png, Jpeg and Jpg can be downloaded");
					return View();

				}
				if (portfolioItem.PosterImageFile.Length > 3145728)
				{
					ModelState.AddModelError("PosterImageFile", "It cannot be more than 3 MB");
					return View();
				}
				PortfolioItemImages ImagePoster = jobBoardContext.portfolioItemImages.Where(x => x.IsPoster == true).FirstOrDefault(x => x.PortfolioItemId == ExtItem.Id);
				FileManager.DeleteFile(webHostEnvironment.WebRootPath, "uploads/portfolio", ImagePoster.Images);
				jobBoardContext.portfolioItemImages.Remove(ImagePoster);

				PortfolioItemImages PosteImage = new PortfolioItemImages
				{
					PortfolioItemId = portfolioItem.Id,
					Images = FileManager.SaveFile(webHostEnvironment.WebRootPath, "uploads/portfolio", portfolioItem.PosterImageFile),
					IsPoster = true,
				};
				jobBoardContext.portfolioItemImages.Add(PosteImage);
			}


			if (portfolioItem.ImageFiles != null)
			{
				foreach (var item in portfolioItem.ImageFiles)
				{
					if (item.ContentType != "image/png" && item.ContentType != "image/jpeg")
					{
						ModelState.AddModelError("PosterImageFile", "But Png, Jpeg and Jpg can be downloaded");
						return View();

					}
					if (item.Length > 3145728)
					{
						ModelState.AddModelError("PosterImageFile", "It cannot be more than 3 MB");
						return View();
					}
					PortfolioItemImages Images = new PortfolioItemImages
					{
						PortfolioItemId = portfolioItem.Id,
						Images = FileManager.SaveFile(webHostEnvironment.WebRootPath, "uploads/portfolio", item),
						IsPoster = null,
					};
					jobBoardContext.portfolioItemImages.Add(Images);
				}
			}

			if (portfolioItem.PortfolioImageIds == null)
			{
				List<PortfolioItemImages> images = jobBoardContext.portfolioItemImages.Where(x => x.IsPoster == null).Where(x => x.PortfolioItemId == ExtItem.Id).ToList();
				foreach (var image in images)
				{
					FileManager.DeleteFile(webHostEnvironment.WebRootPath, "uploads/portfolio", image.Images);
					jobBoardContext.portfolioItemImages.Remove(image);
				}
			}

			else
			{
				List<PortfolioItemImages> DeletedImage = ExtItem.portfolioItemImages.Where(x => !portfolioItem.PortfolioImageIds.Contains(x.Id)).ToList();
				if (DeletedImage != null)
				{
					foreach (var item in DeletedImage.Where(x => x.IsPoster == null))
					{
						if (item.Id!=0)
						{
                            PortfolioItemImages Image = jobBoardContext.portfolioItemImages.FirstOrDefault(x => x.Id == item.Id);
                            FileManager.DeleteFile(webHostEnvironment.WebRootPath, "uploads/portfolio", item.Images);
                            jobBoardContext.portfolioItemImages.Remove(Image);
                        }
					}
				}
			}






			ExtItem.Title = portfolioItem.Title;
			ExtItem.Description = portfolioItem.Description;
			ExtItem.TeamId = portfolioItem.TeamId;
			ExtItem.Order = portfolioItem.Order;
			ExtItem.Client = portfolioItem.Client;
			ExtItem.poerfolioCatagoriesId = portfolioItem.poerfolioCatagoriesId;
			ExtItem.WebUrl = portfolioItem.WebUrl;
			jobBoardContext.SaveChanges();
			return RedirectToAction("Index");
		}
        #endregion


        #region Delete
        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Delete(int id)
		{
			PortfolioItem portfolioItem = jobBoardContext.portfolioItems.Include(x => x.portfolioItemImages).FirstOrDefault(x => x.Id == id);
			if (portfolioItem == null)
			{
		return View("error");
			}
			if (portfolioItem.portfolioItemImages != null)
			{
				foreach (var item in portfolioItem.portfolioItemImages)
				{
					FileManager.DeleteFile(webHostEnvironment.WebRootPath, "uploads/portfolio", item.Images);
				}
			}
			jobBoardContext.portfolioItems.Remove(portfolioItem);
			jobBoardContext.SaveChanges();
			return Ok();
		}


		#endregion
	}
}
