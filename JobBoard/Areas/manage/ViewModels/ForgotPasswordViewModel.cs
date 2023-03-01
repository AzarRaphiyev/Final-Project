namespace JobBoard.Areas.manage.ViewModels
{
	public class ForgotPasswordViewModel
	{
		[Required]
		[StringLength(maximumLength:100,ErrorMessage ="Maksimum 100 simvol ola biler")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
	}
}
