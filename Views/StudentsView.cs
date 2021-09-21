using System;
using System.Collections.Generic;
using System.ComponentModel;
using UDDATA.Models;

namespace UDDATA.Views
{
    class StudentsView
    {
        public void ShowAllStudents(List<Student> studentList)
        {
            Console.WriteLine("\n...SHOW ALL STUDENTS...");
            foreach (var student in studentList)
            {
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(student))
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(student);
                    Console.WriteLine($"{name}: {value}");
                }
            }
        }
        
        public void ShowStudent(Student student)
        {
            Console.WriteLine("\n...SHOW STUDENT...");
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(student))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(student);
                Console.WriteLine($"{name}: {value}");
            }
        }

        public Student AddStudent()
        {
            Student student = new Student();
            Console.WriteLine("\n...ADD NEW STUDENT...");
            Console.Write("Name: ");
            student.Name = Tools.cr();
            Console.Write("Warnings: ");
            student.Warnings = Tools.cr();

            Console.Write("Date of Birth (dd-mm-yyyy): ");
            student.DateOfBirth = Tools.String2Datetime(Tools.cr());
            return student;
        }
    }
}
