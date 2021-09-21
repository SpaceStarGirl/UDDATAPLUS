using UDDATA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace UDDATA.Controllers
{
    class StudentCRUD
    {
        const string connectionString =
            "Data Source=.;" +
            "Initial Catalog=UDDATADB;" +
            "Integrated Security=True";

        public List<Student> Select(int studentId)
        {
            List<Student> studentList = new List<Student>();
            string sql =
$"SELECT S.id, S.[Name], S.DateOfBirth" +
$"FROM Teacher AS T " +
$"JOIN student AS S ON S.Id = T.Studentid " +
$"WHERE T.TeacherId = {studentId}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        studentList.Add(
                            new Student()
                            {
                                Id = (int)reader[0],
                                Name = (string)reader[1],
                                DateOfBirth = (DateTime)reader[2]
                            });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR:" + ex.GetType() + ex.Message);
                    return null;
                }
            }
            return studentList;
        }

        public List<Student> Select()
        {
            List<Student> studentList = new List<Student>();
            string sql = $"SELECT id, [name], DateOfBirth, FROM Student";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        studentList.Add(
                            new Student()
                            {
                                Id = (int)reader[0],
                                Name = (string)reader[1],
                                DateOfBirth = (DateTime)reader[2]
                            });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR:" + ex.GetType() + ex.Message);
                    return null;
                }
            }
            return studentList;
        }
        public static int? Insert(Student student)
        {
            string sql = "INSERT INTO Student ([name], DateOfBirth) " +
                    "OUTPUT INSERTED.id " +
                    "VALUES(@name, @DateOfBirth) ";

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = student.Name;
                        cmd.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = student.DateOfBirth;

                        var id = cmd.ExecuteScalar();
                        return (int?)id;
                    }
                }
                catch (Exception ex)
                {
                    // We should log the error somewhere, 
                    // for this example let's just show a message
                    Console.WriteLine("ERROR:" + ex.Message);
                    return null;
                }
            }
        }

    }
}