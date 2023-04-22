using AutoMapper;
using Data.Mongo.Collections;
using Identity.Models;
using Models.DbEntities;
using Models.DbEntities.Hospitals;
using Models.DbEntities.Post;
using Models.DbEntities.Registration;
using Models.DbEntities.User;
using Models.DTOs.Account;
using Models.DTOs.Blogs;
using Models.DTOs.BloodgroupDtos;
using Models.DTOs.Event;
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

            CreateMap<Blog, BlogDto>();

            CreateMap<Tag, TagDto>();

            CreateMap<BlogTag,BlogTagDto>();

            CreateMap<Category,CategoryDto>();
            
            CreateMap<Event,EventDto>();

            CreateMap<EventUserSub,EventUserSubDto>();

            CreateMap<UserInfo,UserInfoDto>();
        }
    }
}
