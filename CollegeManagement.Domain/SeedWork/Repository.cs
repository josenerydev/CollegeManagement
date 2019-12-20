using System.Linq;

namespace CollegeManagement.Domain.SeedWork
{
    public abstract class Repository<T>
        where T : AggregateRoot
    {
        private readonly UnitOfWork _unitOfWork;

        protected Repository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public T GetById(long id)
        {
            return _unitOfWork.Get<T>(id);
        }

        public void Save(T aggregateRoot)
        {
            _unitOfWork.SaveOrUpdate(aggregateRoot);
        }

        public void Delete(T aggregateRoot)
        {
            _unitOfWork.Delete(aggregateRoot);
        }

        public IQueryable<K> Query<K>()
        {
            return _unitOfWork.Query<K>();
        }
    }
}
