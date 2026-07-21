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
            ApplicationUser? user = await _userRepository.GetUserByEmailAndPassword(loginRequest.Email , loginRequest.Password);
            if (user == null)
                return null;

            return new AuthenticationResponse
            (user.UserID, user.Email, user.PersonName, user.Gender, "Token", Success:true);
        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
        {

            ApplicationUser user = new ApplicationUser()
            {
                PersonName = registerRequest.Email,
                Password = registerRequest.Password,
                Email = registerRequest.Email,
                Gender = registerRequest.Gender.ToString(),
            };
            ApplicationUser ? registeredUser = await _userRepository.AddUser(user);
            _userRepository.AddUser(user);

            if(registeredUser == null)
                return null;

            return new AuthenticationResponse(registeredUser.UserID, registeredUser.Email, registeredUser.PersonName, registeredUser.Gender,
                "Token", Success: true);

        }
    }
}
