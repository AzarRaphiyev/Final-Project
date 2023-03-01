namespace JobBoard.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private readonly JobBoardContext jobBoardContext;

        public FooterViewComponent(JobBoardContext jobBoardContext)
        {
            this.jobBoardContext = jobBoardContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            FooterViewModel footerViewModel = new FooterViewModel
            {
                servicesSites = jobBoardContext.services.OrderByDescending(x => x.Id).ToList(),
                companies = jobBoardContext.companies.OrderBy(x => x.Id).Take(3).ToList(),
                settings= jobBoardContext.settings.ToList(),
            };

            return View(await Task.FromResult(footerViewModel));
        }

    }

    
}
