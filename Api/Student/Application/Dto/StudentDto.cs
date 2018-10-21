using System;

namespace EnterprisePatterns.Api.Customers.Application.Dto
{
    public class StudentDto
    {
        public  long Id { get; set; }
        public  string Nombre { get; set; }
        public  string Apellido { get; set; }
        public string Pais { get; set; }
        public  int Edad { get; set; }
        public  string Username { get; set; }
        public  string Password { get; set; }

    }
}
