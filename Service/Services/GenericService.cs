using Core.IRepository;
using Core.IService;
using Core.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        protected readonly IGenericRepository<T> _repository;
        protected readonly IUnitOfWork _unitOfWork;
        public GenericService(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public T Add(T entity)
        {
            _repository.Add(entity);
            _unitOfWork.saveChanges();
            return entity;

        }

        public void AddRange(List<T> entities)
        {
            _repository.AddRange(entities);
            _unitOfWork.saveChanges();
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return _repository.Any(expression);
        }

        public int Count(Expression<Func<T, bool>> expression)
        {
            return _repository.Count(expression);
        }

        public void Remove(T entity)
        {
            _repository.Remove(entity);
        }

        public void RemoveRange(List<T> entities)
        {
            _repository.RemoveRange(entities);
        }

        public List<T> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public List<T> GetBy(Expression<Func<T, bool>> expression)
        {
            return _repository.GetBy(expression).ToList();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
            _unitOfWork.saveChanges();
        }

        public void UpdateRange(List<T> entities)
        {
            _repository.UpdateRange(entities);
            _unitOfWork.saveChanges();
        }
    }
}
