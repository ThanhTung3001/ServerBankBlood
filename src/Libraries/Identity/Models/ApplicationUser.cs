using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Models.DbEntities.Hospitals;
using Models.DbEntities.User;

namespace Identity.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ApplicationUserRole> UserRoles { get; set; } = new List<ApplicationUserRole>();
        public Hospital Hospital { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}
