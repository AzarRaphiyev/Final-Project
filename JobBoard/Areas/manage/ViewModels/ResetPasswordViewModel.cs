namespace JobBoard.Areas.manage.ViewModels
{
	public class ResetPasswordViewModel
	{

		[Required]
		[StringLength(64)]
		[DataType(DataType.Password)]
		public string NewPassword { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[StringLength(64)]
		[Compare(nameof(NewPassword))]
		public string ConfirmPassword { get; set;}



	}
}
