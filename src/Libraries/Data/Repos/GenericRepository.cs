using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Models.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Models.PaginationList;

namespace Data.Repos
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context = null)
        {
            _context = context;
        }

        public bool BulkInsert(List<T> entities)
        {
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            try
            {
                _context.Set<T>().AddRange(entities);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChanges();
        }

        public void UpdateEntry(T entity)
        {
            // entity.ModificationDate = DateTime.Now;
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task<PaginationListResponse<List<T>>> PaginationList(PaginationListQuery query)
        {
            var pagedData = await _context.Set<T>().OrderByDescending(e=>e.Id)
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();
            var totalRecords = await _context.Set<T>().CountAsync();
            var totalPages = totalRecords / query.PageSize;

            return new PaginationListResponse<List<T>>(pagedData, query.PageNumber, query.PageSize, totalPages + 1, totalRecords);
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().FirstOrDefault(match);
        }

        public List<T> FindAll(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().Where(match).ToList();
        }

        public async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().Where(match).ToListAsync();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            if (entity == null)
                return null;
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
    }
}
