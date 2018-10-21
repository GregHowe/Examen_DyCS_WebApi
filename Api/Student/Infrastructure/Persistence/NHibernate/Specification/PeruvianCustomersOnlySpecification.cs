using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EnterprisePatterns.Api.Common.Domain.Specification;

namespace EnterprisePatterns.Api.Customers.Infrastructure.Persistence.NHibernate.Specification
{
    public sealed class PeruvianStudentsOnlySpecification : Specification<Student>
    {
        public override Expression<Func<Student, bool>> ToExpression()
        {
            return customer => customer.Pais.Contains("PERU");
        }
    }
}
