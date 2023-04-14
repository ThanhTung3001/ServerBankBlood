using AutoMapper;
using Data.Repos;
using Models.DbEntities.Hospitals;

namespace WebApi.Controllers;

public class HospitalController:CrudControllerBase<Hospital>
{
    public HospitalController(IGenericRepository<Hospital> genericRepository, IMapper mapper) : base(genericRepository, mapper)
    {
    }
}