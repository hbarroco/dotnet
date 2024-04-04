using school_route.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_route.repository.interfaces
{
    public interface IUserRepository : IGenericRepository<UserLoginModel>
    {
        Task<UserLoginModel> LoginAsync(UserLoginModel lognModel);
    }
}
