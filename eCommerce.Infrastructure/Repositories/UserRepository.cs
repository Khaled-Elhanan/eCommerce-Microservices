using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;

namespace eCommerce.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            user.UserID = Guid.NewGuid();   
            return Task.FromResult<ApplicationUser?>(user);
        }

        public Task<ApplicationUser?> GetUserByEmailAndPassword(string email, string password)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserID = Guid.NewGuid(),
                Email = email,
                Password = password,
                PersonName = "Jans celine",
                Gender = GenderOptions.Male.ToString()
            };

            return Task.FromResult<ApplicationUser?>(user);
        }
    }
}
