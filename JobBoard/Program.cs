

using JobBoard.Areas.manage.services;
using JobBoard.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<JobBoardContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Def")));
builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
	opt.Password.RequiredLength = 8;
	opt.Password.RequireNonAlphanumeric = false;
	opt.Password.RequireDigit = true;
	opt.Password.RequireLowercase = true;
	opt.Password.RequireUppercase = true;
	opt.User.RequireUniqueEmail = false;

	//opt.SignIn.RequireConfirmedEmail= true;
}).AddEntityFrameworkStores<JobBoardContext>().AddDefaultTokenProviders();
builder.Services.AddScoped<LayoutServices>();
builder.Services.AddScoped<AdminLayoutService>();

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

builder.Services.AddTransient<IMailService, MailService>();

builder.Services.AddSession(opt =>
{
    opt.IdleTimeout = TimeSpan.FromSeconds(5);
});
builder.Services.AddHttpContextAccessor();
var app = builder.Build();



app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
			name: "areas",
			pattern: "{area:exists}/{controller=dashboard}/{action=Index}/{id?}"
		  );



app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
