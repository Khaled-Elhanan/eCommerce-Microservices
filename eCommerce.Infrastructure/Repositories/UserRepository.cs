using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
using Dapper;

namespace eCommerce.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperDbContext _dbContext;

        public UserRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            user.UserID = Guid.NewGuid();

            string query = @"INSERT INTO public.""Users""
                    (""UserID"", ""Email"", ""PersonName"", ""Gender"", ""Password"")
                    VALUES
                    (@UserID, @Email, @PersonName, @Gender, @Password);";

            int rowCountAffected=await
                _dbContext.DbConnection.ExecuteAsync(query , user);
            if(rowCountAffected > 0 )
            {
                return user;
            }
            else { return null; }

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
