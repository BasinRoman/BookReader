using BookReader.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace BookReader.Domain.ViewModel
{
	public class UserViewModel
	{
		public string Id { get; set; }
		public string? Login { get; set; }
		public string? Password { get; set; }
		public UserRole UserRole { get; set; }

	}
}