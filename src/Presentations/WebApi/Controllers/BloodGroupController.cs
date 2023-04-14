using AutoMapper;
using Data.Repos;
using Models.DbEntities.Registration;

namespace WebApi.Controllers;

public class BloodGroupController:CrudControllerBase<BloodGroup>
{
    public BloodGroupController(IGenericRepository<BloodGroup> genericRepository, IMapper mapper) : base(genericRepository, mapper)
    {
    }
}