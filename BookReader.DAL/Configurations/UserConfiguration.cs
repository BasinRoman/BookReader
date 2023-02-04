using BookReader.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookReader.Domain.Extensions;

namespace BookReader.DAL.Configurations
{
	internal class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.Property(x => x.Id).ValueGeneratedOnAdd();
			builder.HasData(new User
			{
				Id = 1,
				Login = "admin",
				Password = HashPasswordExtension.HashPassword("123"),
				UserRole = Domain.Enum.UserRole.admin,
			}); 
		}
	}
}
