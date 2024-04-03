using school_route.models;
using school_route.repository.interfaces;
using school_route.services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_route.services.implementation
{
    public class CustomerServices : ICustomerServices
    {
        public readonly ICustomerRepository _repository;

        public CustomerServices(ICustomerRepository repository) 
        {
            this._repository = repository;
        }

        public Task<int> AddAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Customer>> GetAllAsync()
        {
            try
            {
                var customers = this._repository.GetAllAsync();
                return customers;
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }

        public Task<Customer?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
