using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Manager : Project.Staff
    {
        private const float ManagerHourlyRate = 50f;
        public int Allowance { get; set; }
        public Manager(string name) : base(name, ManagerHourlyRate)
        {
        }
        public override void CalculatePay()
        {
            base.CalculatePay();

            Allowance = 1000;

            if(HoursWorked > 160)
            {
                TotalPay = BasicPay+ Allowance;
            }

        }
        public override string ToString()
        {
            return "\nNameOfStaff = " + NameOfStaff + "\nManagerHourlyRate = "
            + ManagerHourlyRate + "\nHoursWorked = " + HoursWorked +
            "\nBasicPay = " + BasicPay + "\nAllowance = " + Allowance +
            "\n\nTotalPay = " + TotalPay;
        }
    }
}
