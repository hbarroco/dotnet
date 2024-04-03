
using school_route.repository.interfaces;

namespace school_route.repository.implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomerRepository Customers => throw new NotImplementedException();
    }
}
