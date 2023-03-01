namespace JobBoard.ViewModels
{
    public class JobsViewModel
    {
        public List<Job> jobs { get; set; }
        public PaginationList<Job> paginatedlist { get; set; }
        public string Title { get; set; }
        public int RegionId { get; set; }
        public int TypeId { get; set; }
    }
}
