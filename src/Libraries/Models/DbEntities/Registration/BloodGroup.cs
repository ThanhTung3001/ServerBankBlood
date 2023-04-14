using System.Collections.Generic;
using Models.DbEntities.User;

namespace Models.DbEntities.Registration;

public class BloodGroup:BaseEntity
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public bool Urgent { get; set; }
    
    public long Capacity { get; set; }
    
    public string Avatar { get; set; }
    
    public IEnumerable<UserInfo>UserInfo { get; set; }
    
    
}