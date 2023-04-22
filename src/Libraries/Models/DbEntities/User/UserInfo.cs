using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Models.DbEntities.Post;
using Models.DbEntities.Registration;
using Models.DTOs.Event;

namespace Models.DbEntities.User;

public class UserInfo : BaseEntity
{
    public int AppUserId { get; set; }

    public string? Email { get; set; }

    public string FullName { get; set; }

    public int Age { get; set; } = 0;

    public string? Avatar { get; set; }

    public string? PhoneNumber { get; set; }

    public int DonateAmount { get; set; } = 0;

    public int Star { get; set; } = 0;

    public int TotalDonate { get; set; } = 0; //

    public DateTime? BirthDate { get; set; }

    public long Iccid { get; set; }

    [JsonIgnore]
    public IEnumerable<Register> Register { get; set; }

    public int? BloodId { get; set; }

    public BloodGroup BloodGroup { get; set; }
    public IEnumerable<EventUserSub> EventUserSubs { get; set; }
}

public class UserInfoDto : BaseEntity
{
    public int AppUserId { get; set; }

    public string? Email { get; set; }

    public string FullName { get; set; }

    public int Age { get; set; } = 0;

    public string? Avatar { get; set; }

    public string? PhoneNumber { get; set; }

    public int DonateAmount { get; set; } = 0;

    public int Star { get; set; } = 0;

    public int TotalDonate { get; set; } = 0; //

    public DateTime? BirthDate { get; set; }

    public long Iccid { get; set; }

    [JsonIgnore]
    public IEnumerable<Register> Register { get; set; }

    public int? BloodId { get; set; }

    public BloodGroup BloodGroup { get; set; }
    public IEnumerable<EventUserSubDto> EventUserSubs { get; set; }
}