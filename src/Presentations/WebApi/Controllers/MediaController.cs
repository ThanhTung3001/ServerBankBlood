using AutoMapper;
using Data.Repos;
using Models.DbEntities.Attachments;

namespace WebApi.Controllers;

public class MediaController:CrudControllerBase<Media>
{
    public MediaController(IGenericRepository<Media> genericRepository, IMapper mapper) : base(genericRepository, mapper)
    {
    }
}