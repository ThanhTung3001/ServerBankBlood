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
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
        
        public Hospital Hospital { get; set; }
        
        public UserInfo UserInfo { get; set; }
        
   
        
    }
}
