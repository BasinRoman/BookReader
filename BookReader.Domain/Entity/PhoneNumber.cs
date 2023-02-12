using BookReader.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReader.Domain.Entity
{
	public class PhoneNumber
	{
		public PhoneCountryCode phoneCountryCode { get; set; }
		public int phoneNumbers { get; set; }

		public PhoneNumber(PhoneCountryCode phoneCountryCode, int phoneNumbers)
		{
			this.phoneCountryCode = phoneCountryCode;
			this.phoneNumbers = phoneNumbers;
		}		
	}
}
