using System;
using System.Collections.Generic;
using Models.DbEntities.Registration;

namespace Models.DbEntities.User;

public class UserInfo : BaseEntity
{
    public int AppUserId { get; set; }
    
    public string FullName { get; set; }
    
    public int Age { get; set; }
    
    public string Avatar { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public int DonateAmount { get; set; }
    
    public int Star { get; set; }
    
    public int TotalDonate { get; set; } //
    
    public DateTime BirthDate { get; set; }
    
    public long Iccid { get; set; }
    
    public IEnumerable<Register> Register { get; set; } 
    
    public int BloodId { get; set; }
    public BloodGroup BloodGroup { get; set; }
}