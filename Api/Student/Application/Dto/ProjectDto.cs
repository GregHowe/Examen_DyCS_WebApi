using EnterprisePatterns.Api.Common.Application.Enum;
using System;

namespace EnterprisePatterns.Api.Customers.Application.Dto
{
    public class ProjectDto
    {
        public long Id { get; set; }
        public string ProjectName { get; set; }
        public  int NumberDaysProject { get; set; }
        public decimal Budget { get; set; }
        public Currency CurrencyCode { get; set; }

    }
}
