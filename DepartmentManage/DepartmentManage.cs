using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentManage
{
    class DepartmentManage
    {
        
        static void Main(string[] args)
        {
            List<Department> listOfDepartment = new List<Department>();            // List main
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Department Manage");
                Console.WriteLine("*************************MENU**************************");
                Console.WriteLine("**  1. Input Employee                                **");
                Console.WriteLine("**  2. Display Employees                             **");
                Console.WriteLine("**  3. Classify employees.                           **");
                Console.WriteLine("**  4. Employee Search.                              **");
                Console.WriteLine("**  5. Report                                        **");
                Console.WriteLine("**  0. Exit                                          **");
                Console.WriteLine("*******************************************************");
                Console.Write("Input Key: ");
                int key;
                if (!int.TryParse(Console.ReadLine(), out key))
                {
                    Console.Clear();
                    continue;
                }
                switch (key)
                {
                    case 1:
                        EnterEmployee(listOfDepartment);      // Nhập nhân viên và phòng ban
                        Console.Read();
                        break;
                    case 2:
                        DisplayEmployee(listOfDepartment);      // Hiển thị tất cả nhân viên, sắp xếp theo từng phòng ban
                        Console.Read();
                        break;
                    case 3:
                        ClassifyEmployees(listOfDepartment);    // Hiển thi nhân viên theo loại
                        break;
                    case 4:
                        FindEmployees(listOfDepartment);        // Tìm kiếm nhân viên theo tên nhân viên, hoặc tên phòng ban
                        break;
                    case 5:
                        Report(listOfDepartment);       // thống kê phòng ban
                        Console.Read();
                        break;
                    case 0:
                        Console.WriteLine("\nYou chose to exit!");
                        return;
                    default:
                        Console.WriteLine("\nwhat do you want: ");
                        break;
                }
            }
        }


        private static void EnterEmployee(List<Department> listOfDepartment)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t\tInput Employee");
                Console.WriteLine("*************************MENU**************************");
                Console.WriteLine("**  1. Enter Salaried Employee                       **");
                Console.WriteLine("**  2. Enter Hourly Employee                         **");
                Console.WriteLine("**  0. Return                                        **");
                Console.WriteLine("*******************************************************");
                int key;
                if (!int.TryParse(Console.ReadLine(), out key))
                {
                    Console.Clear();
                    continue;
                }
                switch (key)
                {
                    case 1:
                        SalariedEmployee inputSalariedEmployee = EnterSalariedEmployee();   //Nhập Salaried Nhân viên
                        EnterDepartment(listOfDepartment, inputSalariedEmployee);           // Nhập phòng ban cho nhân viên
                        break;
                    case 2:
                        HourtyEmployee inputHourtyEmployee = EnterHourtyEmployee();         //Nhập Hourty Nhân viên
                        EnterDepartment(listOfDepartment, inputHourtyEmployee);             //Nhập phòng ban cho nhân viên
                        break;
                    case 0:
                        return;
                    default:
                        break;
                }
            }            
        }

        private static SalariedEmployee EnterSalariedEmployee()
        {        
            SalariedEmployee inputemployee = new SalariedEmployee();
            // Nhập thông tin cơ bản cho nhân viên:
            Console.WriteLine("Enter Employee SSN: ");
            inputemployee.Ssn = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter Employee Frist Name: ");
            inputemployee.FirstName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter Employee Last Name: ");
            inputemployee.LastName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter Employee Brith Day: ");
            inputemployee.BirthDay = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter Employee Phone: ");
            inputemployee.Phone = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter Employee Email: ");
            inputemployee.Email = Convert.ToString(Console.ReadLine());

            // input Commission Rate:
            string inputstr;
            double inputCommissionRate;
            do
            {
                Console.WriteLine("Enter Commission Rate: ");
                inputstr = Console.ReadLine();
            }
            while (!double.TryParse(inputstr, out inputCommissionRate));
            inputemployee.CommissionRate = inputCommissionRate;

            // input Gross Sales:
            double inputGrossSales;
            do
            {
                Console.WriteLine("Enter Gross Sales: ");
                inputstr = Console.ReadLine();
            }
            while (!double.TryParse(inputstr, out inputGrossSales));
            inputemployee.GrossSales = inputGrossSales;

            // input Basic Salary:
            double inputBasicSalary;
            do
            {
                Console.WriteLine("Enter Basic Salary: ");
                inputstr = Console.ReadLine();
            }
            while (!double.TryParse(inputstr, out inputBasicSalary));
            inputemployee.BasicSalary = inputBasicSalary;

            return inputemployee;
        }

        private static HourtyEmployee EnterHourtyEmployee()
        {
            HourtyEmployee inputemployee = new HourtyEmployee();
            // Nhập thông tin cơ bản cho nhân viên:
            Console.WriteLine("Enter Employee SSN: ");
            inputemployee.Ssn = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter Employee Frist Name: ");
            inputemployee.FirstName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter Employee Last Name: ");
            inputemployee.LastName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter Employee Brith Day: ");
            inputemployee.BirthDay = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter Employee Phone: ");
            inputemployee.Phone = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter Employee Email: ");
            inputemployee.Email = Convert.ToString(Console.ReadLine());

            // input Wage:
            string inputstr;
            double inputWage;
            do
            {
                Console.WriteLine("Enter Wage: ");
                inputstr = Console.ReadLine();
            }
            while (!double.TryParse(inputstr, out inputWage));
            inputemployee.Wage = inputWage;

            // input Working Hours:
            double inputWorkingHours;
            do
            {
                Console.WriteLine("Enter Commission Rate: ");
                inputstr = Console.ReadLine();
            }
            while (!double.TryParse(inputstr, out inputWorkingHours));
            inputemployee.WorkingHours = inputWorkingHours;

            return inputemployee;
        }

        private static void EnterDepartment(List<Department> listOfDepartment, SalariedEmployee inputSalariedEmployee)
        {
            string inputstr;
            Console.WriteLine("Enter Employee Department: ");
            inputstr = Convert.ToString(Console.ReadLine());
            if (!FindDepartmentName(listOfDepartment, inputstr))        //Check nếu tên phòng ban không tồn tại thì tạo mới phòng ban
            {
                Console.WriteLine("Employee Department does not exist !   \n Create Department {0} ?\n 1 : Yes \n 2 : No and Exit" , inputstr);
                int key;
                if (int.TryParse(Console.ReadLine(), out key) && key ==1)
                {
                    Department newDepartment = new Department();
                    List<Employee> listEmployee = new List<Employee>();
                    listEmployee.Add(inputSalariedEmployee);
                    newDepartment.DepartmentName = inputstr;
                    newDepartment.ListOfEmployee = listEmployee;                        
                    listOfDepartment.Add(newDepartment);
                }                
            }
            else                                                  // Thêm  nhân viên vào phòng ban đã tồn tại
            {
                Department newDepartment = new Department();
                List<Employee> listEmployee = new List<Employee>();
                listEmployee.Add(inputSalariedEmployee);
                newDepartment.DepartmentName = inputstr;
                newDepartment.ListOfEmployee = listEmployee;
                listOfDepartment.Add(newDepartment);
            }

            Console.WriteLine("Enter Salaried Employee succerfull ! ");
        }

        private static void EnterDepartment(List<Department> listOfDepartment, HourtyEmployee inputHourtyEmployee)
        {
            string inputstr;
            Console.WriteLine("Enter Employee Department: ");
            inputstr = Convert.ToString(Console.ReadLine());
            if (!FindDepartmentName(listOfDepartment, inputstr)) //Check nếu tên phòng ban không tồn tại thì tạo mới phòng ban
            {
                Console.WriteLine("Employee Department does not exist !   \n Create Department {0} ?\n 1 : Yes \n Any key : No and Exit", inputstr);
                int key;
                if (int.TryParse(Console.ReadLine(), out key) && key == 1)
                {
                    Department newDepartment = new Department();
                    List<Employee> listEmployee = new List<Employee>();
                    listEmployee.Add(inputHourtyEmployee);
                    newDepartment.DepartmentName = inputstr;
                    newDepartment.ListOfEmployee = listEmployee;
                    listOfDepartment.Add(newDepartment);
                };                
            }
            else                                    // Thêm  nhân viên vào phòng ban đã tồn tại
            {
                Department newDepartment = new Department();
                List<Employee> listEmployee = new List<Employee>();
                listEmployee.Add(inputHourtyEmployee);
                newDepartment.DepartmentName = inputstr;
                newDepartment.ListOfEmployee = listEmployee;
                listOfDepartment.Add(newDepartment);
            }
            Console.WriteLine("Enter Hourty Employee succerfull ! ");

        }

        private static bool FindDepartmentName(List<Department> listOfDepartment,string name)
        {
            foreach(Department department in listOfDepartment)
            {
                if (department.DepartmentName == name)   // Tìm thấy phòng ban đã có trong list
                    return true;
            }           
            
            return false;
        }

        private static void DisplayEmployee(List<Department> listOfDepartment)
        {
            Console.WriteLine("DepartmentName {0, 20} {1, 20} {2, 20} {3, 20} {4, 20} {5, 20}",
                      "SSN", "FirstName", "LastName", "BirthDay", "Phone", "Email");        //Hiển thị tiêu đề
            foreach (Department department in listOfDepartment)         // Duyệt toàn bộ danh sách các phòng ban
            {                
                foreach (Employee employee in department.ListOfEmployee)    //Duyệt danh sách các nhân viên của mỗi phòng ban
                {
                    Console.Write(department.DepartmentName + "  ");       // Hiển thị từng nhân viên
                    employee.Display(employee);
                }
            }            
        }

        private static void ClassifyEmployees (List<Department> listOfDepartment)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Classify Employees");
                Console.WriteLine("*************************MENU*****************************");
                Console.WriteLine("**  1. Classify Salaried Employee                       **");
                Console.WriteLine("**  2. Classify Hourly Employee                         **");
                Console.WriteLine("**  0. Return                                           **");
                Console.WriteLine("**********************************************************");
                int key;
                if (!int.TryParse(Console.ReadLine(), out key))
                {
                    Console.Clear();
                    continue;
                }
                Console.WriteLine("DepartmentName {0, 20} {1, 20} {2, 20} {3, 20} {4, 20} {5, 20}",
                                  "SSN", "FirstName", "LastName", "BirthDay", "Phone", "Email");
                switch (key)
                {
                    case 1:
                        foreach (Department department in listOfDepartment)     // Duyệt toàn bộ danh sách các phòng ban
                        {                            
                            foreach (Employee employee in department.ListOfEmployee)        // Duyệt danh sách các nhân viên
                            {
                                if(employee.GetType() == new SalariedEmployee().GetType())      // Duyệt danh sách nhân viên có kiểu salaried 
                                {
                                    Console.Write(department.DepartmentName + "  ");        //Hiển thị nhân viên
                                    employee.Display(employee);
                                }                                
                            }
                        }
                        Console.Read();
                        break;
                    case 2:
                        foreach (Department department in listOfDepartment)     // Duyệt toàn bộ danh sách các phòng ban
                        {                            
                            foreach (Employee employee in department.ListOfEmployee)    // Duyệt danh sách các nhân viên
                            {
                                if (employee.GetType() == new HourtyEmployee().GetType())       // Duyệt danh sách nhân viên có kiểu Hourty
                                {
                                    Console.Write(department.DepartmentName + "  ");        //Hiển thị nhân viên
                                    employee.Display(employee);
                                }
                            }
                        }
                        Console.Read();
                        break;
                    case 0:                        
                        return;
                    default:
                        break;
                }
            }
        }

        private static void FindEmployees(List<Department> listOfDepartment)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Classify Employees");
                Console.WriteLine("*************************MENU**************************");
                Console.WriteLine("**  1. Search employees by name department           **");
                Console.WriteLine("**  2. Search employees by name Employee             **");
                Console.WriteLine("**  0. Return                                        **");
                Console.WriteLine("*******************************************************");
                int key;
                if (!int.TryParse(Console.ReadLine(), out key))
                {
                    Console.Clear();
                    continue;
                }                
                switch (key)
                {
                    case 1:
                        Console.Write("Enter Department Name: ");
                        string inputname = Console.ReadLine();
                        Console.WriteLine("DepartmentName {0, 20} {1, 20} {2, 20} {3, 20} {4, 20} {5, 20}",
                                  "SSN", "FirstName", "LastName", "BirthDay", "Phone", "Email");
                        foreach (Department department in listOfDepartment)         //Duyệt list Department
                        {
                            if(department.DepartmentName == inputname)          // Tìm tên phòng ban
                            {
                                foreach (Employee employee in department.ListOfEmployee)    // Hiển thị nhân viên có kiểu Salaried
                                {
                                    if (employee.GetType() == new SalariedEmployee().GetType()) 
                                    {
                                        Console.Write(department.DepartmentName + "  ");        
                                        employee.Display(employee);
                                    }
                                }
                           
                                foreach (Employee employee in department.ListOfEmployee)    //Hiển thị nhân viên có kiểu Hourty
                                {
                                    if (employee.GetType() == new HourtyEmployee().GetType())
                                    {
                                        Console.Write(department.DepartmentName + "  ");
                                        employee.Display(employee);
                                    }
                                }
                            }
                        }
                        Console.Read();
                        break;
                    case 2:
                        Console.Write("Enter Employee Name: ");
                        string inputnameEmployee = Console.ReadLine();
                        foreach (Department department in listOfDepartment)     // Tìm nhân viên theo tên và hiển thị
                        {
                            foreach (Employee employee in department.ListOfEmployee)
                            {
                                if (employee.LastName == inputnameEmployee)                                        
                                {
                                    Console.Write(department.DepartmentName + "  ");
                                    employee.Display(employee);
                                }
                            }
                        }
                        Console.Read();
                        break;
                    case 0:
                        return;
                    default:
                        break;
                }
            }
        }

        private static void Report(List<Department> listOfDepartment)
        {            
            Console.WriteLine("Department Name \t   Sum of Employee");
            foreach (Department department in listOfDepartment)             // Thống kê phòng ban và số lượng nhân viên
            {
                Console.WriteLine("{0 ,30}  {1 ,30}", department.DepartmentName, department.ListOfEmployee.Count());
            }
        }

   
    }

}
