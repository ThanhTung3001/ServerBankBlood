using System;
using System.Collections.Generic;

namespace Models.DTOs.Account
{
    public class UserDto
    {
        public int Id {get;set;}
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public List<string> roles { get; set; }

        public string phoneNumber{get; set;}

        public string avatar {get;set;}

        public DateTime createDate {get;set;}
    }
}