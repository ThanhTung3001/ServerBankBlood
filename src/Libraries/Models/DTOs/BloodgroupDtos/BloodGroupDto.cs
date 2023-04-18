
using System;
using Models.Enums;

namespace Models.DTOs.BloodgroupDtos
{

    public class BloodGroupDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Urgent { get; set; }

        public long Capacity { get; set; }

        public string Avatar { get; set; }
    }

    public class UserAppDto
    {
        public int AppUserId { get; set; }

        public string FullName { get; set; }

        public int Age { get; set; } = 0;

        public string? Avatar { get; set; }

        public string? PhoneNumber { get; set; }

        public int DonateAmount { get; set; } = 0;

        public int Star { get; set; } = 0;

        public int TotalDonate { get; set; } = 0; //

        public DateTime? BirthDate { get; set; }

        public long Iccid { get; set; }



        public int? BloodId { get; set; }
    }

    public class HospitalDto
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public int UserId { get; set; }

        // public List<Media> MediaList { get; set; }

        public double Lat { get; set; }

        public double Long { get; set; }
    }

    public class RegisterDto
    {
        public int Id { get; set; }
        public int BloodGroupId { get; set; }
        public BloodGroupDto BloodGroup { get; set; }

        public int Capacity { get; set; }

        public DateTime RegisterTime { get; set; }

        public int HospitalId { get; set; }
        public HospitalDto Hospital { get; set; }

        public int UserId { get; set; }

        public UserAppDto UserInfo { get; set; }

        public StatusType status { get; set; }

        //public List<MediaRegister> Medias { get; set; } = new List<MediaRegister>();
    }

}