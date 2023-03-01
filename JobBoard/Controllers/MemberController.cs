using JobBoard.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace JobBoard.Controllers
{
	public class MemberController : Controller
	{
		private readonly JobBoardContext jobBoardContext;
		private readonly IWebHostEnvironment webHostEnvironment;

		public MemberController(JobBoardContext jobBoardContext,IWebHostEnvironment webHostEnvironment)
		{
			this.jobBoardContext = jobBoardContext;
			this.webHostEnvironment = webHostEnvironment;
		}
		#region Index
		public IActionResult Index()
		{
			List<AppUser> users = jobBoardContext.Users.Where(x=>x.Role=="Member").ToList();
			return View(users);
		}

        #endregion

        #region Edit

        [Authorize(Roles = "Member,Superadmin,Admin")]
        public ActionResult Edit(string username) 
		{
		Member member=jobBoardContext.members.FirstOrDefault(x=>x.UserName==username);
			if (member==null) { return View("error"); }
			return View(member);
		}
		[HttpPost]
        [Authorize(Roles = "Member,Superadmin,Admin")]
        public ActionResult Edit(Member member)
		{
			Member member1=jobBoardContext.members.FirstOrDefault(x=>x.Id== member.Id);

			if (member1==null)
			{
				return View("error");
			}
			AppUser appUser= jobBoardContext.Users.FirstOrDefault(x=>x.UserName == member1.UserName);
			if (appUser == null)
			{
				return View("error");
			}
			if (member.ImageFile != null)
			{
				if (member.ImageFile.ContentType != "image/png" && member.ImageFile.ContentType != "image/jpeg")
				{
					ModelState.AddModelError("ImageFile", "But Png, Jpeg and Jpg can be downloaded");
					return View();
				}
				if (member.ImageFile.Length >  3145728)
				{
					ModelState.AddModelError("ImageFile", "It cannot be more than 3 MB");
					return View();
				}

				if (member.CvFile != null)
				{
					if (member.CvFile.ContentType != "application/pdf")
					{
						ModelState.AddModelError("CvFile", "But Pdf can be downloaded");
						return View();
					}
					if (member.CvFile.Length > 10485760)
					{
						ModelState.AddModelError("CvFile", "It cannot be more than 10 MB");
						return View();
					}
					

					FileManager.DeleteFile(webHostEnvironment.WebRootPath, "uploads/member/cv", member1.Cv);

					member1.Cv = FileManager.SaveFile(webHostEnvironment.WebRootPath, "uploads/Member/cv", member.CvFile);
				}
				FileManager.DeleteFile(webHostEnvironment.WebRootPath, "uploads/users", member1.Image);
				FileManager.DeleteFile(webHostEnvironment.WebRootPath, "uploads/member/img", member1.Image);
				member1.Image = FileManager.SaveFile(webHostEnvironment.WebRootPath, "uploads/users", member.ImageFile);
				FileManager.SaveFile(webHostEnvironment.WebRootPath, "uploads/Member/img", member.ImageFile);

			}
		
			member1.Fullname = member.Fullname;
			appUser.FullName= member.Fullname;
			appUser.Cv = member.Cv;
			appUser.Image = member.Image;
			jobBoardContext.SaveChanges();
			return RedirectToAction("Index","Home");
		}
        #endregion
	}
}
