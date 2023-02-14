using BookReader.DAL.Interfaces;
using BookReader.Domain.Entity;
using BookReader.Domain.Enum;
using BookReader.Domain.Extensions;
using BookReader.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BookReader.DAL.Repositories
{
	public class ProfileRepository: IBaseRepository<UserProfile>, IProfileRepository
	{
		public readonly ApplicationDbContext _db;

		public ProfileRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public Task<bool> Create(UserProfile entity)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Delete(UserProfile entity)
		{
			throw new NotImplementedException();
		}

		public Task<UserProfile> Get(int id)
		{
			throw new NotImplementedException();
		}

		public IQueryable<UserProfile> GetAll()
		{
			throw new NotImplementedException();
		}

		public async Task<UserProfile> GetByLogin(string loginName)
		{
            //return await _db.UserProfiles.FirstOrDefaultAsync(x => x.User.Login == loginName);
            return await _db.UserProfiles.Include(p =>p.User).Where(x=>x.User.Login == loginName).FirstOrDefaultAsync();
        }

		public Task<IEnumerable<UserProfile>> Select()
		{
			throw new NotImplementedException();
		}

		public bool Update(UserProfile entity)
		{
			throw new NotImplementedException();
		}
	}
}
