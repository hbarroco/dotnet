
using Dapper;
using Microsoft.Extensions.Configuration;
using school_route.models;
using school_route.repository.connection;
using school_route.repository.interfaces;

namespace school_route.repository.implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        //private readonly IConfiguration _configuration;

        //public CustomerRepository(IConfiguration configuration)
        //{
        //    this._configuration = configuration;
        //}

        private readonly ProviderConnection _providerConnection;
 
        public CustomerRepository(ProviderConnection providerConnection)
        {
            this._providerConnection = providerConnection;
        }       

        public async Task<int> AddAsync(Customer customer)
        {
            var sql = "INSERT INTO Customer (firstName, lastName, email, dob) VALUES (@FirstName, @LastName, @Email, @DOB)";
            //using var connection = new SqliteConnection(_configuration.GetConnectionString("DefaultConnection"));
            using var connection = this._providerConnection.GetSchoolRouteConnection;
            return await connection.ExecuteAsync(sql, customer);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Customer WHERE ID = @ID";
            using var connection = this._providerConnection.GetSchoolRouteConnection;
            var result = await connection.ExecuteAsync(sql, new { ID = id });
            return result;

        }

        public async Task<IReadOnlyList<Customer>> GetAllAsync()
        {
            var sql = "SELECT * FROM customer";
            using var connection = this._providerConnection.GetSchoolRouteConnection;
            var result = await connection.QueryAsync<Customer>(sql);
            return result.ToList();

        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Customer WHERE ID = @ID";
            using var connection = this._providerConnection.GetSchoolRouteConnection;
            var result = await connection.QuerySingleOrDefaultAsync<Customer>(sql, new { ID = id });
            return result ?? null;
        }

        public async Task<int> UpdateAsync(Customer entity)
        {
            var sql = "UPDATE Customer SET FirstName = @FirstName, LastName = @LastName, DOB = @DOB, Email = @Email WHERE ID = @ID";
            using var connection = this._providerConnection.GetSchoolRouteConnection;
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }

    }
}
