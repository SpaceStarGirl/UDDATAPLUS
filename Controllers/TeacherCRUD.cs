using UDDATA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UDDATA.Views;

namespace BuhuZoo.Controllers
{
    class TeacherCRUD
    {
        private string connectionString;

        public TeacherCRUD() { }
        public TeacherCRUD(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public List<Teacher> Select()
        {
            List<Teacher> teacherList = new List<Teacher>();
            string sql = $"SELECT TeacherId, TeacherName, DateOfBirth,FROM Teacher";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        teacherList.Add(
                            new Teacher()
                            {
                                Id = (int)reader[0],
                                Name = (string)reader[1],
                                DateOfBirth = (DateTime)reader[2],
                                studentList = new StudentCRUD().Select((int)reader[0])
                            });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR:" + ex.GetType() + ex.Message);
                    return null;
                }
            }
            return teacherList;
        }

        public int? Insert(Teacher teacher)
        {
            string sql = "INSERT INTO Teacher (TeacherName, DateOfBirth) " +
                    "OUTPUT INSERTED.id " +
                    "VALUES(@name, @DateOfBirth) ";

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = teacher.Name;
                        cmd.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = teacher.DateOfBirth;

                        var id = cmd.ExecuteScalar();
                        return (int?)id;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine("ERROR:" + ex.Message);
                    return null;
                }
            }
        }

    }
}
