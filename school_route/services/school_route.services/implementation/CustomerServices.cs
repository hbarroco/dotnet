using school_route.models;
using school_route.repository.interfaces;
using school_route.services.interfaces;

namespace school_route.services.implementation
{
    public class CustomerServices : ICustomerServices
    {
        public readonly ICustomerRepository _repository;

        public CustomerServices(ICustomerRepository repository) 
        {
            this._repository = repository;
        }

        public Task<int> AddAsync(CustomerModel entity)
        {
                return this._repository.AddAsync(entity);
        }

        public Task<int> DeleteAsync(int id)
        {
                return this._repository.DeleteAsync(id);
        }

        public Task<IEnumerable<CustomerModel>> GetAllAsync()
        {
            return this._repository.GetAllAsync();
        }

        public Task<CustomerModel?> GetByIdAsync(int id)
        {
                return this._repository.GetByIdAsync(id);
        }

        public Task<int> UpdateAsync(CustomerModel entity)
        {
                return this._repository.UpdateAsync(entity);
        }
    }
}
