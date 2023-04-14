using AutoMapper;
using Data.Repos;
using Models.DbEntities.User;

namespace WebApi.Controllers;

public class UserInfoController:CrudControllerBase<UserInfo>
{
    public UserInfoController(IGenericRepository<UserInfo> genericRepository, IMapper mapper) : base(genericRepository, mapper)
    {
    }
}