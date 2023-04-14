﻿using Data.Repos;
using Data.UnitOfWork;
using Models.DbEntities;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class NoteService : INoteService
    {
        private readonly IGenericRepository<Note> _repository;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _userEmail;
        public NoteService(IGenericRepository<Note> repository, IAuthenticatedUserService authenticatedUserService, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _authenticatedUserService = authenticatedUserService;
            _userEmail = _authenticatedUserService.UserEmail;
            _unitOfWork = unitOfWork;
        }

        public bool DeleteNote(int id)
        {
            Note note = _repository.Find(x => x.Id == id && x.OwnerEmail.Equals(_userEmail));
            if (note != null)
            {
                if (_repository.Delete(note) > 0)
                    return true;
            }
            return false;
        }

        public List<Note> GetAllMyNotes()
        {
            //UnitofWork Usage Sample
            //List<Note> notes = _unitOfWork.Repository<Note>().FindAll(x => x.OwnerEmail.Equals(_userEmail));
            return _repository.FindAll(x => x.OwnerEmail.Equals(_userEmail));
        }

        public async Task<List<Note>> GetAllMyNotesAsync()
        {
            return await _repository.FindAllAsync(x => x.OwnerEmail.Equals(_userEmail));
        }

        public Note GetNoteById(int id)
        {
            return _repository.Find(x => x.Id == id && x.OwnerEmail.Equals(_userEmail));
        }

        public List<Note> GetNotesByCategory(string category)
        {
            return _repository.FindAll(x => x.Category.Equals(category) && x.OwnerEmail.Equals(_userEmail));
        }

        public Note InsertNote(Note note)
        {
            return _repository.Insert(note);
        }
    }
}
