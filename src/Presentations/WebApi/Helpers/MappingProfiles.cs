using AutoMapper;
using Data.Mongo.Collections;
using Identity.Models;
using Models.DbEntities;
using Models.DbEntities.Hospitals;
using Models.DbEntities.Registration;
using Models.DbEntities.User;
using Models.DTOs.Account;
using Models.DTOs.BloodgroupDtos;
using Models.DTOs.Log;
using Models.DTOs.Note;

namespace WebApi.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ApplicationUser, UserDto>();

            CreateMap<Note, NoteDto>();

            CreateMap<LoginLog, LogDto>();

            CreateMap<BloodGroup, BloodGroupDto>();

            CreateMap<UserInfo, UserAppDto>();

            CreateMap<Hospital, HospitalDto>();

            CreateMap<Register, RegisterDto>();
        }
    }
}
