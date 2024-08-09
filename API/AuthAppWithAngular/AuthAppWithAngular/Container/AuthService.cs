using AuthAppWithAngular.Helper;
using AuthAppWithAngular.Interface;
using AuthAppWithAngular.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthAppWithAngular.Container
{
    public class AuthService : IAuthInterface
    {
        private readonly AuthAppWithAngularContext _dbContext;

        public AuthService(AuthAppWithAngularContext context)
        {
            _dbContext = context;
        }

        public async Task<APIResponse> UserRegistration(UserRegister userRegister)
        {
            APIResponse response = new APIResponse();
            bool isValid = true;

            try
            {
                var user = await _dbContext.UserRegisters
                    .Where(x => x.Username == userRegister.Username)
                    .ToListAsync();
                if (user.Count > 0)
                {
                    isValid = false;
                    response.Result = "fail";
                    response.Message = "Duplicate User";
                }

                var userEmail = await _dbContext.UserRegisters
                    .Where(x => x.Email == userRegister.Email)
                    .ToListAsync();
                if (userEmail.Count > 0)
                {
                    isValid = false;
                    response.Result = "fail";
                    response.Message = "Duplicate Email";
                }

                if (userRegister != null && isValid)
                {
                    await _dbContext.UserRegisters.AddAsync(userRegister);
                    await _dbContext.SaveChangesAsync();
                    var userid = userRegister.Userid;
                    response.Result = "pass";
                    response.Message = userid.ToString();
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while registering the user.", ex);
            }
        }
    }
}
