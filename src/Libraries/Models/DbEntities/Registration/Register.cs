using System;
using System.Collections.Generic;
using Models.DbEntities.Hospitals;
using Models.DbEntities.User;

namespace Models.DbEntities.Registration;

public class Register : BaseEntity
{
    
    public BloodGroup BloodGroup { get; set; }
    
    public int Capacity { get; set; }
    
    public DateTime RegisterTime { get; set; }
    
    public int HospitalId { get; set; }
    public Hospital Hospital { get; set; }
    
    // public IEnumerable<RegisterUser> RegisterUser { get; set; }
    
    public int UserId { get; set; }
    
    public UserInfo  UserInfo { get; set; }
    
}

