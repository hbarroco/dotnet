using HB.Vendas.Online.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.Vendas.Online.Services.Interfaces
{
    public interface IUserService
    {
        void Add(User entity);
        void Update(User entity);
        void Remove(string entityId);
        User GetById(string entityId);
        User GetByUserNamePasswordAndStore(string entityUserName, string entityPassword, int storeId);
        List<User> GetAll();
    }
}
