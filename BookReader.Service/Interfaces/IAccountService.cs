using BookReader.DAL.Interfaces;
using BookReader.Domain.Entity;
using BookReader.Domain.Response;
using BookReader.Domain.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookReader.Service.Interfaces
{
	public interface IAccountService
	{
		Task<IBaseResponse<ClaimsIdentity>> Register(RegisterViewModel userViewModel);
		
    }
}
