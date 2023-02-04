using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace BookReader.Domain.Extensions
{
	public static class HashPasswordExtension
	{
		public static string HashPassword(string password)
		{
			using(var sha256 = SHA256.Create())
			{
				var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
				var hash = BitConverter.ToString(hashBytes).ToLower();
				return hash;
			}
		}
	}
}
