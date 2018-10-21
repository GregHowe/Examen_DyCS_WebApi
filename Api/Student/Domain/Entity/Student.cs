using Common.Application;
using EnterprisePatterns.Api.Common.Domain.ValueObject;

namespace EnterprisePatterns.Api.Customers
{
    public class Student
    {
        public virtual long Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Apellido { get; set; }
        public virtual string Pais { get; set; }
        public virtual int Edad { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        //public virtual Address Address { get; set; }

        public Student()
        {
            //Address = null;
        }

        public virtual bool hasFullName()
        {
            return !string.IsNullOrWhiteSpace(this.Nombre);
        }

        public virtual Notification validateForSave()
        {
            Notification notification = new Notification();

            if (this == null)
            {
                notification.addError("The student is null");
            }

            //if (!this.hasFullName())
            //{
            //    notification.addError("The customer doesn´t have a valid organization name");
            //}

            return notification;
        }
    }
}
