using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobBoard.Areas.manage.Controllers
{
    [Area("manage")]
    public class ContactListController : Controller
    {
        private readonly JobBoardContext jobBoardContext;

        public ContactListController(JobBoardContext jobBoardContext)
        {
            this.jobBoardContext = jobBoardContext;
        }
        #region Index

        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Index(int page=1)
        {
           
			var query = jobBoardContext.Contacts.AsQueryable();

			var paginatedlist = PaginationList<Contact>.Create(query, 3, page);
			return View(paginatedlist);
		}

        #endregion

        #region Details
        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Details(int id)
        {
            Contact contact = jobBoardContext.Contacts.FirstOrDefault(x => x.Id == id);
            if (contact == null) return View("error");
            contact.IsViewed= true;
            jobBoardContext.SaveChanges();
            return View(contact);
        }


        #endregion

        #region Delete
        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Delete(int id)
		{
			Contact deleteContact = jobBoardContext.Contacts.FirstOrDefault(x => x.Id == id);
			if (deleteContact == null) return View("error");
			jobBoardContext.Contacts.Remove(deleteContact);
			jobBoardContext.SaveChanges();
			return Ok();
		}


        #endregion




	}
}
