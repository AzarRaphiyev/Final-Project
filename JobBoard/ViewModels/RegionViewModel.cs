namespace JobBoard.ViewModels
{
	public class RegionViewModel
	{
			public RegionViewModel(int ıd, string regionTitle)
			{
				Id = ıd;
				RegionTitle = regionTitle;
			}
			public RegionViewModel()
			{

			}

			public int Id { get; set; }
			public string RegionTitle { get; set; }
	}
}
