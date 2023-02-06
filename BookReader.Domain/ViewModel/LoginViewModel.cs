using System.ComponentModel.DataAnnotations;


namespace BookReader.Domain.ViewModel
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Please enter login")]
		[Display(Name = "Login")]
		public string Login { get; set; }	

		[Required(ErrorMessage ="Please enter password")]
		[Display(Name = "Password")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
