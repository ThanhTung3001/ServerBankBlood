using AutoMapper;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Models.DbEntities.Hospitals;

namespace WebApi.Controllers;

public class HospitalController:CrudControllerBase<Hospital>
{
    public HospitalController(IGenericRepository<Hospital> genericRepository, IMapper mapper) : base(genericRepository, mapper)
    {
    }
    [HttpGet("GetById/{id}")]
    public IActionResult GetById(int id){
        return Ok(_GenericRepository.GetById(id));
    }
}