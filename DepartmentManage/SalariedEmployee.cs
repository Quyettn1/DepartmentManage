using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentManage
{
    public class SalariedEmployee:Employee
    {
        private double commissionRate;
        public double CommissionRate
        {
            get { return commissionRate; }
            set { commissionRate = value; }
        }

        private double grossSales;
        public double GrossSales
        {
            get { return grossSales; }
            set { grossSales = value; }
        }

        private double basicSalary;
        public double BasicSalary
        {
            get { return basicSalary; }
            set { basicSalary = value; }
        }
    }
}
