using AutoMapper;
using Data.Repos;
using Models.DbEntities;
using Models.DTOs.Note;

namespace WebApi.Controllers;

public class NoteController:CrudControllerBase<Note,NoteDto>
{
    public NoteController(IGenericRepository<Note> genericRepository, IMapper mapper) : base(genericRepository, mapper)
    {
    }
}