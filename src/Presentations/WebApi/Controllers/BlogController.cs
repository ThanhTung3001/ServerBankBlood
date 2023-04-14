using AutoMapper;
using Data.Repos;
using Models.DbEntities.Post;

namespace WebApi.Controllers;

public class BlogController:CrudControllerBase<Blog>
{
    public BlogController(IGenericRepository<Blog> genericRepository, IMapper mapper) : base(genericRepository, mapper)
    {
    }
}