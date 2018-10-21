using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnterprisePatterns.Api.Common.Application
{
    public interface INumberDaysProject
    {
        int GetNumberProjectDays();
    }

    public class Null_NumberDaysProject : INumberDaysProject
    {
        private static Null_NumberDaysProject _instance;
        private Null_NumberDaysProject()
        { }
        public static Null_NumberDaysProject Instance
        {
            get
            {
                if (_instance == null)
                    return new Null_NumberDaysProject();
                return _instance;
            }
        }

        public int GetNumberProjectDays()
        {
            return 15;
        }
    }

    public class NumberDaysProject : INumberDaysProject
    {
        public int GetNumberProjectDays()
        {
            return 30;
        }
    }


}
