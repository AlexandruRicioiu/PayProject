using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Staff
    {
        private float HourlyRate;
        private int HWorked;

        public float TotalPay { get; set; }
        public float BasicPay { get; set; }
        public string NameOfStaff { get; set; }
        public int HoursWorked
        {
            get { return HWorked; }
            set { if (value > 0) {
                    HWorked = value;
                }
                else
                {
                    HWorked = 0;
                }
            }
        }
        public Staff(string name, float rate)
        {
            NameOfStaff = name;
            HourlyRate = rate;
        }

       public virtual void CalculatePay()
        {
            Console.WriteLine("Calculate Pay ...");

            BasicPay = HWorked * HourlyRate;
            TotalPay = BasicPay;
        }

        public override string ToString()
        {
            return "\nNameOfStaff = " + NameOfStaff
            + "\nhourlyRate = " + HourlyRate + "\nhWorked = " + HWorked
            + "\nBasicPay = " + BasicPay + "\n\nTotalPay = " + TotalPay;
        }

    }
}
