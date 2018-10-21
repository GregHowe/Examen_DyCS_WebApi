using EnterprisePatterns.Api.Common.Application;
using EnterprisePatterns.Api.Common.Domain.ValueObject;
using EnterprisePatterns.Api.Customers;
namespace EnterprisePatterns.Api.Projects
{
    public class Project : IProject
    {
        public virtual long Id { get; set; }
        public virtual string ProjectName { get; set; }
        public virtual int NumberDaysProject { get; set; }
        public virtual Money Budget { get; set; }
        public virtual Student Student { get; set; }

        public Project()
        {
        }
    }
}
