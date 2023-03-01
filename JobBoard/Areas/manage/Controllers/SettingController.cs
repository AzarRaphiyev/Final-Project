using Microsoft.AspNetCore.Mvc;

namespace JobBoard.Areas.manage.Controllers
{
	[Area("manage")]
	public class SettingController : Controller
	{
		private readonly JobBoardContext jobBoardContext;

		public SettingController(JobBoardContext jobBoardContext)
		{
			this.jobBoardContext = jobBoardContext;
		}
		#region Index
		[Authorize(Roles ="SuperAdmin,Admin")]
	public IActionResult Index()
		{
			List<Setting> settingList = jobBoardContext.settings.ToList();
			return View(settingList);
		}
		#endregion

		#region Update
		[Authorize(Roles = "SuperAdmin,Admin")]
		public IActionResult Update(int id)
		{
			Setting setting = jobBoardContext.settings.FirstOrDefault(x => x.Id == id);
			if (setting == null) { return View("error"); }
			return View(setting);
		}
		[HttpPost]
		[Authorize(Roles = "SuperAdmin,Admin")]
		public IActionResult Update(Setting setting)
		{
			Setting ExtSetting = jobBoardContext.settings.FirstOrDefault(x => x.Id == setting.Id);
			if (ExtSetting == null) { return View("error"); }
			ExtSetting.Key = setting.Key;
			ExtSetting.Value = setting.Value;
			jobBoardContext.SaveChanges();
			return RedirectToAction("Index");

		}
		#endregion

	}
}
