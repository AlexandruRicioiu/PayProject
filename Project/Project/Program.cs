using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Staff> staffs = new List<Staff>();
            FileReader fr = new FileReader();
            int Month = 0, Year = 0;
            while(Year == 0)
            {
                Console.WriteLine("Please enter the year : ");
                try
                {
                    Year = Convert.ToInt32(Console.ReadLine());
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message + "Please inser again !");
                }
            }
            while(Month == 0)
            {
                Console.WriteLine("Please enter the month : ");
                try
                {
                    Month = Convert.ToInt32(Console.ReadLine());
                    if(Month <1 || Month > 12)
                    {
                        Console.WriteLine("Please insert again an correct month !");
                        Month = 0;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "Please inser again !");
                }
            }
            staffs = fr.ReadFile();
            for(int i= 0; i < staffs.Count; i++)
            {
                try
                {
                    Console.WriteLine("Enter hours worked for {0}: ", staffs[i].NameOfStaff);
                    staffs[i].HoursWorked = Convert.ToInt32(Console.ReadLine());
                    staffs[i].CalculatePay();
                    Console.WriteLine(staffs[i].ToString());
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
            }
            PaySlip ps = new PaySlip(Month, Year);
            ps.GeneratePaySlip(staffs);
            ps.GenerateSummary(staffs);
            Console.Read();
        }
    }
}
