

using JobBoard.Helpers;
using JobBoard.Models;
using JobBoard.Services;
using System.Diagnostics.Metrics;

namespace JobBoard.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<AppUser> userManager;
		private readonly SignInManager<AppUser> signInManager;
		private readonly IWebHostEnvironment webHostEnvironment;
		private readonly JobBoardContext jobBoardContext;
		public readonly IMailService mailService;

		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IWebHostEnvironment webHostEnvironment, JobBoardContext jobBoardContext, IMailService mailService)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.webHostEnvironment = webHostEnvironment;
			this.jobBoardContext = jobBoardContext;
			this.mailService = mailService;
		}
		public IActionResult Index()
		{
			return View();
		}

		#region Login

		public IActionResult Login()
		{


			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModels loginVM)
		{
			if (!ModelState.IsValid) return View();

			AppUser user = await userManager.FindByEmailAsync(loginVM.Email);
			if (user == null)
			{
				ModelState.AddModelError("", "Email or Password invalid");
				return View();
			}
			if (user.Enabled == false)
			{
				ModelState.AddModelError("", "Sizin Hesabini admin terefinden tesdiqlenmeyib");
				return View();
			}
			var result = await signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
			if (!result.Succeeded)
			{
				ModelState.AddModelError("", "Email or Password invalid");
				return View();
			}
			return RedirectToAction("Index", "home");



		}
		#endregion

		 #region RegisterMember

		public IActionResult RegisterMember()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> RegisterMember(MemberRegisterViewModel memberRegisterVM)
		{
			if (!ModelState.IsValid) return View();
			AppUser user = await userManager.FindByNameAsync(memberRegisterVM.UserName);
			if (user != null)
			{
				ModelState.AddModelError("Username", "Username is token");
				return View();
			}
			user = await userManager.FindByEmailAsync(memberRegisterVM.Email);
			if (user != null)
			{
				ModelState.AddModelError("Email", "Email is token");
				return View();
			}
			if (memberRegisterVM.Imagefile != null)
			{
				if (memberRegisterVM.Imagefile.ContentType != "image/png" && memberRegisterVM.Imagefile.ContentType != "image/jpeg")
				{
					ModelState.AddModelError("ImageFile", "But Png, Jpeg and Jpg can be downloaded");
					return View();
				}
				if (memberRegisterVM.Imagefile.Length > 3145728)
				{
					ModelState.AddModelError("ImageFile", "It cannot be more than 3 MB");
					return View();
				}

			if (memberRegisterVM.CvFile != null)
			{
				if (memberRegisterVM.CvFile.ContentType != "application/pdf")
				{	
					ModelState.AddModelError("CvFile", "But Pdf can be downloaded");
					return View();
				}
				if (memberRegisterVM.CvFile.Length > 10485760)
				{
					ModelState.AddModelError( "CvFile", "It cannot be more than 10 MB");
					return View();
				}
				memberRegisterVM.Image = FileManager.SaveFile(webHostEnvironment.WebRootPath, "uploads/users", memberRegisterVM.Imagefile);
			
				memberRegisterVM.Cv = FileManager.SaveFile(webHostEnvironment.WebRootPath, "uploads/Member/cv", memberRegisterVM.CvFile);
			}
			else
			{
				ModelState.AddModelError("CvFile", "Bos olamaz");
				return View();
			}
			}
			else
			{
				ModelState.AddModelError("Imagefile", "Bos olamaz");
				return View();
			}


			Member JobSeeker = new Member
			{
				Fullname = $"{memberRegisterVM.Name} {memberRegisterVM.Surname}",
				Email = memberRegisterVM.Email,
				UserName = memberRegisterVM.UserName,
				Image = memberRegisterVM.Image,
				Cv= memberRegisterVM.Cv,
			};

			jobBoardContext.members.Add(JobSeeker);
			AppUser member = new AppUser
			{
				FullName = $"{memberRegisterVM.Name} {memberRegisterVM.Surname}",
				Email = memberRegisterVM.Email,
				UserName = memberRegisterVM.UserName,
				Role = "Member",
				Image = memberRegisterVM.Image,
				Enabled = true,
				Cv= memberRegisterVM.Cv,
			};

			var result = await userManager.CreateAsync(member, memberRegisterVM.Password);
			if (!result.Succeeded)
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError("", item.Description);
					return View();
				}
			}

			await userManager.AddToRoleAsync(member, "Member");
			jobBoardContext.SaveChanges();

			return RedirectToAction("Login", "account");

		}
		#endregion


		#region RegisterCompany
		public IActionResult RegisterCompany()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> RegisterCompany(CompanyRegisterViewModel companyVM)
		{
			if (!ModelState.IsValid) return View();
			AppUser user = await userManager.FindByNameAsync(companyVM.CompanyUserName);
			if (user != null)
			{
				ModelState.AddModelError("CompanyUserName", "Username is token");
				return View();
			}
			user = await userManager.FindByEmailAsync(companyVM.CompanyEmail);
			if (user != null)
			{
				ModelState.AddModelError("CompanyEmail", "Email is token");
				return View();
			}
			if (companyVM.ImageFile != null)
			{
				if (companyVM.ImageFile.ContentType != "image/png" && companyVM.ImageFile.ContentType != "image/jpeg")
				{
					ModelState.AddModelError("ImageFile", "But Png, Jpeg and Jpg can be downloaded");
					return View();
				}
				if (companyVM.ImageFile.Length > 3145728)
				{
					ModelState.AddModelError("ImageFile", "It cannot be more than 3 MB");
					return View();
				}
				companyVM.Image = FileManager.SaveFile(webHostEnvironment.WebRootPath, "uploads/users", companyVM.ImageFile);
			}
			else
			{
				ModelState.AddModelError("Imagefile", "Bos olamaz");
				return View();
			}
			Company company = new Company
			{
				Email = companyVM.CompanyEmail,
				Fullname = companyVM.CompanyName,
				UserName = companyVM.CompanyUserName,
				Location = companyVM.CompanyLocation,
				Description = companyVM.Description,
				Slogan = companyVM.Slogan,
				InstagramUrl = companyVM.InstagramUrl,
				FecebookUrl = companyVM.FecebookUrl,
				TwitterUrl = companyVM.TwitterUrl,
				LinkedinUrl = companyVM.LinkedinUrl,
				Image = companyVM.Image
			};

			jobBoardContext.Add(company);

			AppUser member = new AppUser
			{
				FullName = companyVM.CompanyName,
				Email = companyVM.CompanyEmail,
				UserName = companyVM.CompanyUserName,
				Image = companyVM.Image,
				Role = "Company"
			};

			FileManager.SaveFile(webHostEnvironment.WebRootPath, "uploads/users", companyVM.ImageFile);
			var result = await userManager.CreateAsync(member, companyVM.Password);
			if (!result.Succeeded)
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError("", item.Description);
					return View();
				}
			}
			await userManager.AddToRoleAsync(member, "Company");
			jobBoardContext.SaveChanges();

			return RedirectToAction("Login", "account");

		}
		#endregion

		#region LogOut

		public async Task<IActionResult> LogOut()
		{

			await signInManager.SignOutAsync();
			return RedirectToAction(nameof(Login));
		}
		#endregion



		#region ForgotPassword
		public IActionResult ForgotPassword()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordVM)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			AppUser appUser = await userManager.FindByEmailAsync(forgotPasswordVM.Email);
			if (appUser == null)
			{
				ModelState.AddModelError("Email", "No account found in this email");
				return View();
			}

			string token = await userManager.GeneratePasswordResetTokenAsync(appUser);

			string link = Url.Action("ResetPassword", "Account", new { userid = appUser.Id, token = token }, HttpContext.Request.Scheme);

			await mailService.SendEmailAsync(new MailRequestVM { ToEmail = forgotPasswordVM.Email, Subject = "Reset Your Password", Body = $"<a href={link}> Reset Password <a/>" });

			return RedirectToAction(nameof(Login));
		}
		public async Task<IActionResult> ResetPassword(string userid, string token)
		{
			if (string.IsNullOrWhiteSpace(userid) || string.IsNullOrWhiteSpace(token)) { return BadRequest(); }
			AppUser appUser = await userManager.FindByIdAsync(userid);
			if (appUser == null) { return BadRequest(); }
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordVM, string userid, string token)
		{
			if (string.IsNullOrWhiteSpace(userid) || string.IsNullOrWhiteSpace(token)) { return BadRequest(); }
			AppUser appUser = await userManager.FindByIdAsync(userid);
			if (appUser == null) { return BadRequest(); }

			var res = await userManager.ResetPasswordAsync(appUser, token, resetPasswordVM.NewPassword);
			if (res.Succeeded) { return RedirectToAction("Login"); }
			return BadRequest();
		}
		#endregion
	}
}
