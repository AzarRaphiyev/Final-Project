using Microsoft.AspNetCore.Mvc;

namespace JobBoard.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly JobBoardContext jobBoardContext;

        public PortfolioController(JobBoardContext jobBoardContext)
        {
            this.jobBoardContext = jobBoardContext;
        }
        #region Index
        public IActionResult Index()
        {
            PortfolioViewModel portfolioViewModel = new PortfolioViewModel
            {
                PortfolioItems = jobBoardContext.portfolioItems.Include(x => x.portfolioItemImages).ToList(),
                commentSites = jobBoardContext.commentSites.Where(x => x.IsFavorıte == true).ToList(),
                poerfolioCatagories=jobBoardContext.poerfolioCatagories.ToList(),
            };
            return View(portfolioViewModel);
        }



        #endregion

        #region Details
        public IActionResult Details(int id)
        {
            PortfolioDetailsViewModel portfolioDetailsViewModel = new PortfolioDetailsViewModel
            {

                PortfolioItem = jobBoardContext.portfolioItems.Include(x => x.portfolioItemImages).Include(x => x.poerfolioCatagories).Include(x => x.Team).FirstOrDefault(x => x.Id == id),
                commentSites = jobBoardContext.commentSites.Where(x => x.IsFavorıte == true).Take(2).ToList(),
            };
            return View(portfolioDetailsViewModel);
        }

        #endregion
    }
}
