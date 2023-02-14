using BookReader.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReader.Domain.Entity
{
	public class UserProfile //user profile
	{
		public int Id { get; set; }
		public int Age { get; set; }
		public Gender Gender { get; set; }
		public string Email { get; set; }

		//ForeignKey
		public int UserId { get; set; }
		public User User { get; set; }
	}
}
