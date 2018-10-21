using EnterprisePatterns.Api.Common.Domain.ValueObject;
using EnterprisePatterns.Api.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnterprisePatterns.Api.Common.Application
{
    public interface IProject
    {
        long Id { get; set; }
        string ProjectName { get; set; }
        int NumberDaysProject { get; set; }
        Money Budget { get; set; }
        Student Student { get; set; }
    }

    public class NotFound_Project : IProject
    {
        public long Id { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public int NumberDaysProject { get; set; }
        public Money Budget { get; set; }
        public Student Student { get; set; }
    }


}
