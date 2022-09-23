using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentManage
{
    class HourtyEmployee:Employee
    {
        private double wage;
        public double Wage
        {
            get { return wage; }
            set { wage = value; }
        }

        private double workingHours;
        public double WorkingHours
        {
            get { return workingHours; }
            set { workingHours = value; }
        }
    }
}
