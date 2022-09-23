using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentManage
{
    class Invoice : Payable
    {
        public double getPaymentAmount()
        {
            return 1.5;
        }
        private string partNumber;
        public string PartNumber
        {
            get { return partNumber; }
            set { partNumber = value; }
        }

        private string partDescription;
        public string PartDescription
        {
            get { return partDescription; }
            set { partDescription = value; }
        }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private double pricePeritem;
        public double PricePeritem
        {
            get { return pricePeritem; }
            set { pricePeritem = value; }
        }
    }
}
