using Data.Repos;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Models.DbEntities.User;
using Models.Enums;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Seeds
{
    public static class DefaultSuperAdmin
    {


        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            IGenericRepository<UserInfo> _repository = new GenericRepository<UserInfo>();
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "thanhtung",
                Email = "tungle3001.itfreelancer@gmail.com",
                FirstName = "Thanh",
                LastName = "Tung",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Abcd@123");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.Moderator.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.SuperAdmin.ToString());
                    var userInfo = new UserInfo()
                    {
                        AppUserId = defaultUser.Id,
                        FullName = defaultUser.FirstName + " " + defaultUser.LastName,
                        Avatar = $"https://ui-avatars.com/api/?name={defaultUser.UserName}",
                        Email = defaultUser.Email
                    };
                    var userResponse = _repository.Insert(userInfo);
                    
                }
            }
        }
    }
}
