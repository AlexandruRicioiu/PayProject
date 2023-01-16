using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class PaySlip
    {
        private int Month;
        private int Year;

        enum MonthsOfYear { jan = 1, feb = 2, mar = 3, apr = 4, may = 5, jun = 6, jul = 7, aug = 8, sep = 9, oct = 10, nov = 11, dec = 12}

        public PaySlip(int PayMonth, int PayYear)
        {
            Month = PayMonth;
            Year = PayYear;
        }
        public void GeneratePaySlip(List<Staff> staffs)
        {
            string path;

            foreach(Staff f in staffs)
            {
                path = "C:\\Users\\Alex_R\\Desktop\\Project\\Project\\" + f.NameOfStaff + ".txt";
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("PAYSLIP FOR {0} {1}", (MonthsOfYear) Month, Year);
                    sw.WriteLine("**************************************");
                    sw.WriteLine("Name of Staff : {0}", f.NameOfStaff);
                    sw.WriteLine("Hours Worked : {0}", f.HoursWorked);
                    sw.WriteLine("");
                    sw.WriteLine("Basic Pay: {0:C}", f.BasicPay);
                    if(f.GetType() == typeof(Manager))
                    {
                        sw.WriteLine("Allowance: {0:C}", ((Manager)f).Allowance);
                    }
                    else if (f.GetType() == typeof(Admin))
                    {
                        sw.WriteLine("Overtime: {0:C}", ((Admin)f).Overtime);
                    }
                    sw.WriteLine("");
                    sw.WriteLine("**************************************");
                    sw.WriteLine("Total Pay: {0:C}", f.TotalPay);
                    sw.WriteLine("**************************************");
                    sw.Close();
                }
            }
        }
        public void GenerateSummary(List<Staff> staffs)
        {
            var result = from f in staffs where f.HoursWorked < 100 orderby f.NameOfStaff ascending select new { f.NameOfStaff, f.HoursWorked };
            string path = "C:\\Users\\Alex_R\\Desktop\\Project\\Project\\summary.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Staff with less than 10 working hours");
                sw.WriteLine("");
                foreach (var f in result)
                    sw.WriteLine("Name of Staff: {0}, Hours Worked: {1}", f.NameOfStaff, f.HoursWorked);
                sw.Close();
            }
        }
        public override string ToString()
        {
            return "month = " + Month + "year = " + Year;
        }
    }
}
