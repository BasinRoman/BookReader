using System.ComponentModel.DataAnnotations;


namespace BookReader.Domain.ViewModel
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "Please enter login")]
		public string Login { get; set; }	

		[Required]
		[Display(Name = "Password")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		[Display(Name = "Confirm your password")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Password do not match")]
		public string PasswordConfirm { get; set; }

	}
}
