using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Models.DbEntities.Attachments;
using Models.DbEntities.Hospitals;
using Models.DbEntities.Registration;
using Models.DbEntities.User;
using Models.DTOs.Account;

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
