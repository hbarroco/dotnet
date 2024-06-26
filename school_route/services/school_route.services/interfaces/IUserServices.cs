﻿using school_route.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_route.services.interfaces
{
    public interface IUserServices : IGenericServices<UserLoginModel>
    {
        Task<UserLoginModel> LoginAsync(UserLoginModel lognModel, CancellationToken cancellationToken = default);
    }
}
