using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Admin : Project.Staff
    {
        private const float OvertimeRare = 15.5f;
        private const float AdminHourlyRate = 30f;

        public float Overtime{get ; set;}
        public Admin(string name) : base(name, AdminHourlyRate)
        {
        }
        public override void CalculatePay()
        {
            base.CalculatePay();
            if(HoursWorked > 160)
            {
                Overtime = Overtime * (HoursWorked - 160);
            }
        }
        public override string ToString()
        {
            return "\nNameOfStaff = " + NameOfStaff
            + "\nadminHourlyRate = " + AdminHourlyRate + "\nHoursWorked = " + HoursWorked
            + "\nBasicPay = " + BasicPay + "\nOvertime = " + Overtime + "\n\nTotalPay = " + TotalPay;
        }
    }
}
