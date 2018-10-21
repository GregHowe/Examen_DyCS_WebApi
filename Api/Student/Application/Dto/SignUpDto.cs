using EnterprisePatterns.Api.Common.Application.Enum;
using EnterprisePatterns.Api.Common.Domain.ValueObject;
using System;

namespace EnterprisePatterns.Api.Customers.Application.Dto
{
    public class SignUpDto
    {
        public string OrganizationName { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Pais { get; set; }
        public int Edad { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ProjectName { get; set; }
        public decimal Budget { get; set; }
        public Currency CurrencyCode { get; set; }
        public int NumberDaysProject { get; set; }
        //public Address Adress { get; set; }

    }
}
