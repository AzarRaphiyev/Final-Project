using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobBoard.Areas.manage.Controllers
{
	[Area("manage")]
	public class GenderController : Controller
	{
		private readonly JobBoardContext jobBoardContext;

		public GenderController(JobBoardContext jobBoardContext)
		{
			this.jobBoardContext = jobBoardContext;
		}

		#region Index

		[Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Index(int page =1)
		{
		
			var query = jobBoardContext.genders.OrderByDescending(x => x.Id).AsQueryable();

			var paginatedlist = PaginationList<Gender>.Create(query, 3, page);
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
        public IActionResult Create(Gender gender)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			jobBoardContext.genders.Add(gender);
			jobBoardContext.SaveChanges();
			return RedirectToAction("Index");
		}

		#endregion

		#region Update

		[Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Update(int id)
		{
			Gender gender = jobBoardContext.genders.FirstOrDefault(x => x.Id == id);
			if (gender == null) { return View("error"); }
			return View(gender);
		}
		[HttpPost]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Update(Gender gender)
		{
			Gender Extgender = jobBoardContext.genders.FirstOrDefault(x => x.Id == gender.Id);
			if (Extgender == null) { return View("error"); }
            if (!ModelState.IsValid)
            {
                return View();
            }
            Extgender.GenderType =gender.GenderType;
			jobBoardContext.SaveChanges();
			return RedirectToAction("Index");
		}
		#endregion

		#region Delete

		[Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Delete(int id)
		{
			Gender gender = jobBoardContext.genders.FirstOrDefault(x => x.Id == id);
			if (gender == null) { return View("error"); }
			jobBoardContext.genders.Remove(gender);
			jobBoardContext.SaveChanges();
			return Ok();
		}
		#endregion
	}
}
