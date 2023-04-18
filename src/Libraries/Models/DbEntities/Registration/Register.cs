using System.Collections.Generic;
using System;
using Models.DbEntities.Hospitals;
using Models.DbEntities.User;
using Models.Enums;
using Models.DbEntities.Attachments;

namespace Models.DbEntities.Registration;

public class Register : BaseEntity
{

    public int BloodGroupId { get; set; }
    public BloodGroup BloodGroup { get; set; }

    public int Capacity { get; set; }

    public DateTime RegisterTime { get; set; }

    public int HospitalId { get; set; }
    public Hospital Hospital { get; set; }

    public int UserId { get; set; }

    public UserInfo UserInfo { get; set; }

    public StatusType status { get; set; }

    public List<MediaRegister> Medias { get; set; } = new List<MediaRegister>();

}

