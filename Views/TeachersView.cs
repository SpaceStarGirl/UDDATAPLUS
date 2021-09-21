using System;
using System.Collections.Generic;
using System.ComponentModel;
using UDDATA.Models;

namespace UDDATA.Views
{
    class TeachersView
    {
        public void Show(Object teacherobject)
        {
            Console.WriteLine("...SHOW TEACHER...");
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(teacherobject))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(teacherobject);
                Console.WriteLine($"{name}: {value}");
            }

        }
        public Teacher AddTeacher()
        {
            Teacher teacher = new Teacher();
            Console.WriteLine("...ADD NEW TEACHER...");
            Console.Write("Name: ");
            teacher.Name = Tools.cr();
            Console.Write("Member of CC?: ");
            teacher.CoffeeClub = Tools.cr();

            foreach (var subjects in Enum.GetValues(typeof(Subjects)))
            {
                Console.WriteLine((int)subjects + " " + subjects.ToString());
            }
            Console.Write("Subject: ");
            Subjects s = new Subjects();
            while (!Enum.TryParse(Tools.cr(), out s))
            { Console.WriteLine("Wrong input, please try again."); }
            teacher.Subjects = s;

            Console.Write("Date of Birth (dd-mm-yyyy): ");

            teacher.DateOfBirth = Tools.String2Datetime(Tools.cr());
            return teacher;
        }

        internal void ShowTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}
