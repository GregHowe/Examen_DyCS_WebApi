using EnterprisePatterns.Api.Common.Infrastructure.Persistence.NHibernate;
using EnterprisePatterns.Api.Customers.Domain.Repository;
using System.Collections.Generic;
using System;
using System.Linq;
using EnterprisePatterns.Api.Common.Domain.Specification;

namespace EnterprisePatterns.Api.Customers.Infrastructure.Persistence.NHibernate.Repository
{
    class StudentNHibernateRepository : BaseNHibernateRepository<Student>, IStudentRepository
    {
        public StudentNHibernateRepository(UnitOfWorkNHibernate unitOfWork) : base(unitOfWork)
        {
        }

        public List< Student> GetList(
            Specification<Student> specification,
            int page = 0,
            int pageSize = 5)
        {
            List<Student> customers = new List<Student>();
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                customers = _unitOfWork.GetSession().Query<Student>()
                    .Where(specification.ToExpression())
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();
                _unitOfWork.Commit(uowStatus);
            } catch(Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                throw ex;
            }
            return customers;
        }
    }
}
