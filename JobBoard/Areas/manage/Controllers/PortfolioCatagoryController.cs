using JobBoard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobBoard.Areas.manage.Controllers
{
	[Area("manage")]
	public class PortfolioCatagoryController : Controller
	{
		private readonly JobBoardContext jobBoardContext;

		public PortfolioCatagoryController(JobBoardContext jobBoardContext)
		{
			this.jobBoardContext = jobBoardContext;
		}
        #region Index
        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Index(int page=1)
		{
			
			var query = jobBoardContext.poerfolioCatagories.AsQueryable();

			var paginatedlist = PaginationList<PoerfolioCatagory>.Create(query, 3, page);
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
        public IActionResult Create(PoerfolioCatagory catagory)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			jobBoardContext.poerfolioCatagories.Add(catagory);
			jobBoardContext.SaveChanges();

			return RedirectToAction("Index");
		}
		#endregion

		#region Update

		[Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Update(int id)
		{
			PoerfolioCatagory catagory = jobBoardContext.poerfolioCatagories.FirstOrDefault(x => x.Id == id);
            if (catagory is null)
            {
                return View("error");
            }
            return View(catagory);
		}
		[HttpPost]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Update(PoerfolioCatagory catagory)
		{
			PoerfolioCatagory Exscatagory = jobBoardContext.poerfolioCatagories.FirstOrDefault(x => x.Id == catagory.Id);
			if (Exscatagory == null) return View("Error");
            if (!ModelState.IsValid)
            {
                return View();
            }
            Exscatagory.Name = catagory.Name;
			jobBoardContext.SaveChanges();
			return RedirectToAction("Index");
		}
        #endregion

        #region Delete
        [Authorize(Roles = "SuperAdmin,Admin")]


        public IActionResult Delete(int id)
		{
			PoerfolioCatagory catagory = jobBoardContext.poerfolioCatagories.FirstOrDefault(x => x.Id == id);
			if (catagory == null)
			{
				return View("Error");
			}
			jobBoardContext.poerfolioCatagories.Remove(catagory);
			jobBoardContext.SaveChanges();
			return Ok();
		}
        #endregion
	}
}
