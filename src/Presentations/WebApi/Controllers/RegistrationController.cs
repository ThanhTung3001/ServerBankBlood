using AutoMapper;
using Data.Repos;
using Models.DbEntities.Registration;

namespace WebApi.Controllers;

public class RegistrationController:CrudControllerBase<Register>
{
    public RegistrationController(IGenericRepository<Register> genericRepository, IMapper mapper) : base(genericRepository, mapper)
    {
    }
}