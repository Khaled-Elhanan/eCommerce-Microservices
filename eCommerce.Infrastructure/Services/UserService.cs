using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Infrastructure.Services
{
    public class UserService : IUsersService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
            if (string.IsNullOrWhiteSpace(loginRequest.Email) ||
                string.IsNullOrWhiteSpace(loginRequest.Password))
            {
                return null;
            }

            ApplicationUser? user = await _userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
            if (user == null)
                return null;

            return new AuthenticationResponse
            (user.UserID, user.Email, user.PersonName, user.Gender, "Token", Success:true);
        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
        {
            if (string.IsNullOrWhiteSpace(registerRequest.Email) ||
                string.IsNullOrWhiteSpace(registerRequest.Password) ||
                string.IsNullOrWhiteSpace(registerRequest.PersonName))
            {
                return null;
            }

            ApplicationUser user = new ApplicationUser()
            {
                PersonName = registerRequest.PersonName,
                Password = registerRequest.Password,
                Email = registerRequest.Email,
                Gender = registerRequest.Gender.ToString(),
            };
            ApplicationUser? registeredUser = await _userRepository.AddUser(user);

            if(registeredUser == null)
                return null;

            return new AuthenticationResponse(registeredUser.UserID, registeredUser.Email, registeredUser.PersonName, registeredUser.Gender,
                "Token", Success: true);

        }
    }
}
