using AutoMapper;
using Data.Repos;
using Models.DbEntities.Post;

namespace WebApi.Controllers;

public class TagController:CrudControllerBase<Tag>
{
    public TagController(IGenericRepository<Tag> genericRepository, IMapper mapper) : base(genericRepository, mapper)
    {
    }
}