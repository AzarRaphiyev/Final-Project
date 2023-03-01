using JobBoard.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace JobBoard.Controllers
{
	public class ContactController : Controller
	{
		private readonly JobBoardContext jobBoardContext;

		public ContactController(JobBoardContext jobBoardContext)
		{
			this.jobBoardContext = jobBoardContext;
		}
		#region Create
		public IActionResult Create()
		{
			ViewBag.InfoBar=jobBoardContext.ContactİnfoBars.Take(1).ToList();
			ViewBag.HappyComment=jobBoardContext.commentSites.Where(x=>x.IsFavorıte==true).Take(2).ToList();

			return View();
		}
		[HttpPost]
		public IActionResult Create(Contact contact)

		{
			ViewBag.InfoBar = jobBoardContext.ContactİnfoBars.Take(1).ToList();
			ViewBag.HappyComment = jobBoardContext.commentSites.Where(x => x.IsFavorıte == true).Take(2).ToList();
			if (!ModelState.IsValid)
			{
				return View();
			}
			if (contact==null)
			{
				return View("error");
			}
			
			contact.Data = DateTime.Now;
			jobBoardContext.Contacts.Add(contact);
			jobBoardContext.SaveChanges();
			return RedirectToAction("Create","Contact");
		}

		#endregion
	}
}
