using JobBoard.Helpers;
using JobBoard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobBoard.Controllers
{
	public class CompanyController : Controller
	{
		private readonly JobBoardContext jobBoardContext;
		private readonly IWebHostEnvironment webHostEnvironment;
		private readonly UserManager<AppUser> userManager;

		public CompanyController(JobBoardContext jobBoardContext, IWebHostEnvironment webHostEnvironment,UserManager<AppUser> userManager )
		{
			this.jobBoardContext = jobBoardContext;
			this.webHostEnvironment = webHostEnvironment;
			this.userManager = userManager;
		}
		#region Index
		public IActionResult Index(int page=1)
		{
			
            var query = jobBoardContext.companies.AsQueryable();

            var paginatedlist = PaginationList<Company>.Create(query, 9, page);
            return View(paginatedlist);

        }

        #endregion

        #region Update

        [Authorize(Roles = "Company,Superadmin,Admin")]
        public IActionResult Edit(string username)
		{
			Company company= jobBoardContext.companies.FirstOrDefault(c => c.UserName == username);
			return View(company);
		}
		[HttpPost]
        [Authorize(Roles = "Company,Superadmin,Admin")]
        public IActionResult Edit(Company company) 
		{

			Company ExstCompany= jobBoardContext.companies.FirstOrDefault(x=>x.Id == company.Id);
			if (ExstCompany==null)
			{
				return View("error");
			}
			

			AppUser appUser= jobBoardContext.Users.FirstOrDefault(x=>x.UserName==ExstCompany.UserName);
			if (appUser==null) { return View("error"); }


			if (company.ImageFile!=null)
			{
				if (company.ImageFile.ContentType != "image/png" && company.ImageFile.ContentType != "image/jpeg")
				{
					ModelState.AddModelError("ImageFile", "But Png, Jpeg and Jpg can be downloaded");
					return View();
				}
				if (company.ImageFile.Length > 3145728)
				{
					ModelState.AddModelError("ImageFile", "The size cannot exceed 3 MB");
					return View();
				}
				FileManager.DeleteFile(webHostEnvironment.WebRootPath,"uploads/users",ExstCompany.Image);
				ExstCompany.Image = FileManager.SaveFile(webHostEnvironment.WebRootPath, "uploads/users", company.ImageFile);
				appUser.Image=ExstCompany.Image;
			}

			ExstCompany.Fullname = company.Fullname;
			ExstCompany.Location= company.Location;
			ExstCompany.Description= company.Description;
			ExstCompany.Slogan= company.Slogan;
			ExstCompany.InstagramUrl= company.InstagramUrl;
			ExstCompany.FecebookUrl= company.FecebookUrl;
			ExstCompany.LinkedinUrl= company.LinkedinUrl;
			ExstCompany.TwitterUrl= company.TwitterUrl;
			appUser.FullName = company.Fullname;
			appUser.Email = company.Email;
			appUser.UserName= company.UserName;


			jobBoardContext.SaveChanges();
			return RedirectToAction("Index","Home");
		}
		#endregion

		#region Details
		public IActionResult Details(int id)
		{
			Company company=jobBoardContext.companies.FirstOrDefault(x => x.Id==id);
			if (company==null) { return View("Error"); }
			CompanyViewModel companyViewModel = new CompanyViewModel
			{
				RelationJobs = jobBoardContext.Jobs.Where(x => x.CompanyId == company.Id).Include(x => x.JobType).Include(x => x.Company).ToList(),
				Company = company,
			};

			return View(companyViewModel);
		}

		#endregion


		

	}
}
