using school_route.infrastructure.JwtToken;
using school_route.models;
using school_route.repository.interfaces;
using school_route.services.interfaces;

namespace school_route.services.implementation
{
    public class UserServices : IUserServices
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserRepository _userRepository;

        public UserServices(ITokenHelper tokenHelper, IUserRepository userRepository)
        {
            this._tokenHelper = tokenHelper;
            this._userRepository = userRepository;
        }
        public async Task<UserLoginModel> LoginAsync(UserLoginModel loginModel, CancellationToken cancellationToken = default)
        {
            var user = await this._userRepository.LoginAsync(loginModel);

            if (user == null)
                return null;

            var jwt = _tokenHelper.GenerateJWT(user);
            user.Jwt = jwt;
            return user;
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
