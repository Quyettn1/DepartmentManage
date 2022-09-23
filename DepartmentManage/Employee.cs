using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentManage
{
    public class Employee : Payable
    {
        public double getPaymentAmount()
        {
            return 1.5;
        }


        /* [Required]
         public string Name { get; set; }

         [Range(18, 60, ErrorMessage = "error")]
         public int Age { get; set; }

         [EmailAddress]
         public string Email { get; set; }

         [Required]*/

        private string ssn;
        public string Ssn
        {
            get { return ssn; }
            set { ssn = value; }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private string birthDay;
        public string BirthDay
        {
            get { return birthDay; }
            set 
            {
                DateTime valuedate;
                string inputstr = value;
                
                while (!DateTime.TryParseExact(inputstr, "dd/MM/yyyy", new CultureInfo("en-US"),
                                               DateTimeStyles.None, out valuedate))
                {
                    Console.WriteLine("Error Day - (DD/MM/YYYY)\nEnter Employee Brith Day: ");
                    inputstr = Console.ReadLine();
                }


                birthDay = valuedate.ToString("dd/MM/yyyy");

            }
        }

        private string phone;
        public string Phone
        {
            get { return phone; }
            set 
            {
                int inputphone;
                while (!int.TryParse(value, out inputphone) || value.Length < 7) 
                {
                    Console.WriteLine("Error1 \nEnter Employee Phone again: ");
                    value = Console.ReadLine();
                }
                phone = inputphone.ToString();
            }

        }

        private string email;
        public string Email
        {
            get { return email; }
            set 
            {
                while (true)
                {                   
                    var trimmedEmail = value.Trim();

                    if (trimmedEmail.EndsWith("."))
                    {
                        Console.WriteLine("Enter Employee Email again: ");
                        value = Convert.ToString(Console.ReadLine());
                        continue;
                    }
                    try
                    {
                        var addr = new System.Net.Mail.MailAddress(value);
                        if (addr.Address == trimmedEmail)
                            break;
                    }
                    catch
                    {
                        Console.WriteLine("Enter Employee Email" +
                            " again: ");
                        value = Convert.ToString(Console.ReadLine());
                        continue;
                    }
                }
                email = value; 
            }
        }


        public Employee() { }

        public Employee(string SSN , string FirstName,string LastName)
        {
            ssn = SSN;
            firstName = FirstName;
            lastName = LastName;
        }

        public string getSsn()
        {
            return ssn;
        }
        public void setSsn(string SSN)
        {
            ssn = SSN;
        }

        public void Display(Employee ep)
        {
            Console.WriteLine("{0, 20} {1, 20} {2, 20} {3, 20} {4, 20} {5, 20} ",
                       ep.ssn, ep.firstName, ep.lastName, ep.birthDay, ep.phone,ep.email);
        }
    }
}
