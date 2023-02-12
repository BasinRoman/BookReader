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
	internal class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
	{
		public void Configure(EntityTypeBuilder<UserProfile> builder)
		{
			builder.Property(x => x.Id).ValueGeneratedOnAdd();
			builder.Property(x => x.Age);
			builder.Property(x => x.Sex);
			builder.Property(x => x.Email);
			builder.Property(x => x.UserId);
		}
	}
}
