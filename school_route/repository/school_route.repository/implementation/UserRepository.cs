using Dapper;
using school_route.models;
using school_route.repository.connection;
using school_route.repository.interfaces;

namespace school_route.repository.implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ProviderConnection _providerConnection;

        public UserRepository(ProviderConnection providerConnection)
        {
            this._providerConnection = providerConnection;
        }

        public async Task<UserLoginModel> LoginAsync(UserLoginModel loginModel)
        {
            var sql = "SELECT * FROM [User] WHERE UPPER(Email) = @EMAIL AND UPPER(Password) = @PASSWORD AND Active = 1";
            using var connection = this._providerConnection.GetSchoolRouteConnection;
            var result = await connection.QuerySingleOrDefaultAsync<UserLoginModel>(sql, new {EMAIL = loginModel .Email, PASSWORD = loginModel.Password});
            return result ?? null;
        }

        public Task<int> AddAsync(UserLoginModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserLoginModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserLoginModel?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(UserLoginModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
