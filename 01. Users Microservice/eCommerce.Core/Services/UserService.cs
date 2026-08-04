using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.Services;

namespace eCommerce.Infrastructure.Services
{
    public class UserService : IUsersService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
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

            return _mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = "token" };

        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
        {
            if (string.IsNullOrWhiteSpace(registerRequest.Email) ||
                string.IsNullOrWhiteSpace(registerRequest.Password) ||
                string.IsNullOrWhiteSpace(registerRequest.PersonName))
            {
                return null;
            }

            ApplicationUser user = _mapper.Map<ApplicationUser>(registerRequest);
            ApplicationUser? createdUser = await _userRepository.AddUser(user);
            
            //ApplicationUser user = new ApplicationUser()
            //{
            //    PersonName = registerRequest.PersonName,
            //    Password = registerRequest.Password,
            //    Email = registerRequest.Email,
            //    Gender = registerRequest.Gender.ToString(),
            //};
            //ApplicationUser? registeredUser = await _userRepository.AddUser(user);

            if (createdUser == null)
                return null;

            return _mapper.Map<AuthenticationResponse>(createdUser) with { Success = true, Token = "token" };

            //return new AuthenticationResponse(registeredUser.UserID, registeredUser.Email, registeredUser.PersonName, registeredUser.Gender,
            //    "Token", Success: true);

        }
    }
}
