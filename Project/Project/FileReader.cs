using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class FileReader
    {
        public List<Staff> ReadFile()
        {
            List<Staff> staffs = new List<Staff>();
            string[] result = new string[2];
            string path = "C:\\Users\\Alex_R\\Desktop\\Project\\Project\\staff.txt";
            string[] separator = { ", " };
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        result = sr.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
                        if (result[1] == "Manager")
                        {
                            staffs.Add(new Manager(result[0]));
                        }
                        else if(result[1] == "Admin")
                        {
                            staffs.Add(new Admin(result[0]));
                        }
                    }
                    sr.Close();
                }
            }
            else
            {
                Console.WriteLine("File does not exist !");
            }
            return staffs;
        }
    }
}
