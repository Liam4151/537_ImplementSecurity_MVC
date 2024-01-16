using SamsWarehouseWebApp.Models.Data;
using Microsoft.AspNetCore.Identity;
using SamsWarehouseWebApp.Models.DTO;
using SamsWarehouseWebApp.Models.DBContext;

namespace SamsWarehouseWebApp.Repository
{
    public enum Roles
    {
        Admin,
        StandardUser,
        Guest
    }

    public class AuthRepository
    {
        private readonly ItemDBContext _dbcontext;
        public AuthRepository(ItemDBContext context)
        {
            _dbcontext = context;
        }



        public AppUser Authenticate(LoginUserDTO credentials)
        {
            var userDetails = GetUserByUsername(credentials.Email);

            if (userDetails == null)
            {
                return null;
            }

            if (BCrypt.Net.BCrypt.EnhancedVerify(credentials.Password, userDetails.PasswordHash))
            {
                return userDetails;
            }

            return null;

        }

        private AppUser GetUserByUsername(string userName)
        {
            var user = _dbcontext.Users.Where(c => c.Email.Equals(userName)).FirstOrDefault();

            return user;
        }


    }
}
