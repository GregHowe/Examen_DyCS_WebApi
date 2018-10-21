using FluentNHibernate.Mapping;

namespace EnterprisePatterns.Api.Customers.Infrastructure.Persistence.NHibernate.Mapping
{
    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Id(x => x.Id).Column("student_id");
            Map(x => x.Nombre).Column("nombre");
            Map(x => x.Apellido).Column("apellido");
            Map(x => x.Pais).Column("pais");
            Map(x => x.Username).Column("username");
            Map(x => x.Password).Column("password");
            Map(x => x.Edad).Column("edad");
        }
    }
}
