using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentManage
{
    public class Department
    {
        private string departmentName;

        public string DepartmentName
        {
            get { return departmentName; }
            set { departmentName = value; }
        }

        private List<Employee> listOfEmployee;
        public List<Employee> ListOfEmployee
        {
            get { return listOfEmployee; }
            set { listOfEmployee = value; }
        }
    }
}
