using HB.Vendas.Online.Domain.Entities;
using HB.Vendas.Online.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.Vendas.Online.Services.Implementation
{
    public class UserService : IUserService
    {
        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(string entityId)
        {
            throw new NotImplementedException();
        }

        public User GetByUserNamePasswordAndStore(string entityUserName, string entityPassword, int storeId)
        {
            var userType = new UserType
            {
                Id = 1,
                Description = "Administrator",
                CreateOn = System.DateTime.Now
            };

            var store = new Store
            {
                Id = 1,
                Name = "C and J Modas"
            };

            var user = new User
            {
                Id = 1,
                Name = "Hélio Barroco",
                IsActive = true,
                CreateOn = System.DateTime.Now,
                Password = "pwd123",
                UserName = "hbarroco-123",
                UserType = userType,
                Store = store
            };

            return user;
        }

        public void Remove(string entityId)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
