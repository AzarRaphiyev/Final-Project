using Microsoft.AspNetCore.Mvc;

namespace JobBoard.Controllers
{
    public class ServicesController : Controller
    {
        private readonly JobBoardContext jobBoardContext;

        public ServicesController(JobBoardContext jobBoardContext)
        {
            this.jobBoardContext = jobBoardContext;
        }
        #region Index
        public IActionResult Index()
        {
            List<ServicesSite> services=jobBoardContext.services.ToList();
            return View(services);
        }

        #endregion


        #region Details

        public IActionResult Details(int id) 
        {
            ServicesSite services=jobBoardContext.services.FirstOrDefault(x=>x.Id==id);
            if (services==null)
            {
                return View("error");
            }
            ServicesDetailsViewModel servicesDetailsVM = new ServicesDetailsViewModel
            {
                ServicesSite = services,
                ServicesSiteList = jobBoardContext.services.ToList()
            };

            return View(servicesDetailsVM);
        }


        #endregion
    }
}
