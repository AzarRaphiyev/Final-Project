

using JobBoard.Database;
using JobBoard.Models;
using JobBoard.Services;

namespace JobBoard.Areas.manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IMailService mailService;
		private readonly JobBoardContext jobBoardContext;

		public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager, IMailService mailService,JobBoardContext jobBoardContext)
		{
			this.userManager = userManager;
			this.roleManager = roleManager;
			this.signInManager = signInManager;
			this.mailService = mailService;
			this.jobBoardContext = jobBoardContext;
		}

        #region Create_Super_Admin
  //public async Task<IActionResult> CreateSuperAdmin()
        //{
        //    AppUser SuperAdmin = new AppUser
        //    {
        //        Email = "Raphiyev@gmail.com",
        //        UserName = "SuperAdmin",
        //        FullName = "Azer Raphiyev",
        //        Image = "rəngli.png"
        //    };
        //    var result = await userManager.CreateAsync(SuperAdmin, "Azer1234");
        //    return Ok(SuperAdmin);
        //}
        //public async Task<IActionResult> CreateRole()
        //{
        //    IdentityRole role1=new IdentityRole("SuperAdmin");
        //    IdentityRole role2=new IdentityRole("Admin");
        //    IdentityRole role3=new IdentityRole("Company");
        //    IdentityRole role4=new IdentityRole("Member");
        //    await roleManager.CreateAsync(role1);
        //    await roleManager.CreateAsync(role2);
        //    await roleManager.CreateAsync(role3);
        //    await roleManager.CreateAsync(role4);
        //    return Ok("Created Roles");
        //}
        //public async Task<IActionResult> AddRole()
        //{
        //    AppUser user = await userManager.FindByEmailAsync("Raphiyev@gmail.com");
        //    await userManager.AddToRoleAsync(user, "SuperAdmin");
        //    return Ok("Add Role");
        //}
        #endregion
      





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
            AppUser member = await userManager.FindByEmailAsync(loginVM.Email);
            if (member == null)
            {
                ModelState.AddModelError("", "Email or Password invalid");
                return View();
            }
			if (member.Enabled == false)
			{
				ModelState.AddModelError("", "Sizin Hesabini admin terefinden tesdiqlenmeyib");
				return View();
			}
			var result = await signInManager.PasswordSignInAsync(member, loginVM.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Email or Password invalid");
                return View();
            }
            return RedirectToAction("Index", "dashboard");
        }
        #endregion

        #region Register
  [Authorize(Roles = "SuperAdmin")]



        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModels registerVM)
        {
            if (!ModelState.IsValid)  return View();
            AppUser user = await userManager.FindByEmailAsync(registerVM.Email);
            if (user != null)
            {
                ModelState.AddModelError("Email", "Email Is token");
                return View();
            }
            user = await userManager.FindByNameAsync(registerVM.UserName);

            if (user != null)
            {
                ModelState.AddModelError("Username", "Username Is token");
                return View();
            }
            AppUser member = new AppUser
            {
                FullName = $"{registerVM.Name} {registerVM.Surname}",
                Email = registerVM.Email,
                UserName = registerVM.UserName,
                Role="Admin",
                Image= "default-profile.png",
                Enabled=true
			};

            var result = await userManager.CreateAsync(member,registerVM.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                    return View();
                }
            }

			await userManager.AddToRoleAsync(member, "Admin");
			jobBoardContext.SaveChanges();
			return RedirectToAction("index","dashboard");
        }
        #endregion


        #region LogOut
  public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("login");
        }
        #endregion

        #region Forgot_and_Restart_password
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
            
            AppUser appUser= await userManager.FindByEmailAsync(forgotPasswordVM.Email);
            if (appUser == null) 
            {
                ModelState.AddModelError("Email", "No account found in this email");
                return View();
            }

            string token=await userManager.GeneratePasswordResetTokenAsync(appUser);

            string link = Url.Action("ResetPassword","Account",new { userid=appUser.Id ,token=token },HttpContext.Request.Scheme);
            await mailService.SendEmailAsync(new MailRequestVM { ToEmail = forgotPasswordVM.Email, Subject = "Reset Your Password", Body = $"<a href={link}> Reset Password <a/>" });

            return RedirectToAction(nameof(Login));
        }
        public async Task< IActionResult> ResetPassword(string userid,string token)
        {
			if(string.IsNullOrWhiteSpace(userid) || string.IsNullOrWhiteSpace(token)) { return BadRequest(); }
			AppUser appUser = await userManager.FindByIdAsync(userid);
			if (appUser == null) { return BadRequest(); }
			return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordVM,string userid,string token)
        {
			if (string.IsNullOrWhiteSpace(userid) || string.IsNullOrWhiteSpace(token)) { return BadRequest(); }
			AppUser appUser = await userManager.FindByIdAsync(userid);
			if (appUser == null) { return BadRequest(); }
           
            var res = await userManager.ResetPasswordAsync(appUser,token,resetPasswordVM.NewPassword);
            if (res.Succeeded) { return RedirectToAction("Login"); }
            return BadRequest();
		}
        #endregion


     

	}
}
