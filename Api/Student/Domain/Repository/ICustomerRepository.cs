using EnterprisePatterns.Api.Common.Domain.Specification;
using System.Collections.Generic;
namespace EnterprisePatterns.Api.Customers.Domain.Repository
{
    public interface IStudentRepository
    {
            List<Student> GetList(
            Specification<Student> specification,
            int page = 0,
            int pageSize = 5);

        void Create(Student customer);
    }
}
