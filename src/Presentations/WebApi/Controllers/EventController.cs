using AutoMapper;
using Data.Repos;
using Models.DbEntities.Post;

namespace WebApi.Controllers;

public class EventController:CrudControllerBase<Event>
{
    public EventController(IGenericRepository<Event> genericRepository, IMapper mapper) : base(genericRepository, mapper)
    {
    }
}