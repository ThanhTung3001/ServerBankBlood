using System.Collections.Generic;

namespace Models.DTOs.Account;

public class UpdateRole
{
    public List<string> roles { get; set; }
    public string UserName { get; set; }
}
public class DeleteUser{
    public string username {get;set;}
}