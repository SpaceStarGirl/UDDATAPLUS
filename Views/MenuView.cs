using System;
using System.Collections.Generic;
using System.Linq;
using UDDATA.Models;


namespace UDDATA.Views
{
    class MenuView
    {
        public void Menu()
        {
            Console.WriteLine(
    "\n*** MENU ***\n" +
    "1 Add Student\n" +
    "2 Show All Students\n" +
    "3 Search for Students\n" +
    "4 Add Teacher\n" +
    "5 Show All Teachers\n" +
    "6 Search for Teacher\n");
            string str = Console.ReadLine();
            switch (str)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    ShowAllStudents();
                    break;
                case "3":
                    break;
                case "4":
                    AddTeacher();
                    break;
                case "5":

                    var list = new TeacherCRUD(Tools.connectionString).Select();
                    new TeachersView().Show(list);
                    break;
                case "6":
                    break;
                default:
                    break;
            }
        }

        private void AddTeacher()
        {
            TeachersView tv = new TeachersView();
            Teacher teacher = tv.AddTeacher();
            int? id = TeacherCRUD.Insert(teacher);
            if (id != null)
            {
                teacher.Id = (int)id;
                tv.ShowTeacher(teacher);
            }
            else Console.WriteLine("Something went wrong!!!");
        }

        private void ShowAllStudents()
        {
            StudentCRUD sql = new StudentCRUD();
            List<Student> studentList = sql.Select();
            StudentsView sv = new StudentsView();
            sv.ShowAllStudents(studentList);

        }

        private static void AddStudent()
        {
            StudentsView sv = new StudentsView();
            Student student = sv.AddStudent();
            int? id = StudentCRUD.Insert(student);
            if (id != null)
            {
                student.Id = (int)id;
                sv.ShowStudent(student);
            }
            else Console.WriteLine("Something went wrong!!!");
        }
    }

    internal class TeacherCRUD
    {
        public TeacherCRUD(object connectionString)
        {
        }


    }
}
