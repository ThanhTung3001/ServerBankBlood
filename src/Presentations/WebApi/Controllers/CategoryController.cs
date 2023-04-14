using AutoMapper;
using Data.Repos;
using Models.DbEntities.Post;

namespace WebApi.Controllers;

public class CategoryController:CrudControllerBase<Category>
{
    public CategoryController(IGenericRepository<Category> genericRepository, IMapper mapper) : base(genericRepository, mapper)
    {
    }
}