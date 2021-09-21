using UDDATA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BuhuZoo.Controllers
{
    class AnimalCRUD
    {
        const string connectionString =
            "Data Source=.;" +
            "Initial Catalog=BuhuzooDB;" +
            "Integrated Security=True";

        public List<Student> Select(int studentId)
        {
            List<Student> studentList = new List<Student>();
            string sql =
$"SELECT A.id, A.[Name], A.Gender, A.DateOfBirth, A.Color, A.Race " +
$"FROM ZooKeeperAnimal AS Z " +
$"JOIN animal AS A ON A.Id = Z.AnimalId " +
$"WHERE Z.ZooKeeperId = {studentId}";

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
            string sql = $"SELECT id, [name], gender, DateOfBirth, Color, Race FROM Animal";
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
            string sql = "INSERT INTO Animal ([name], gender, DateOfBirth, color, race) " +
                    "OUTPUT INSERTED.id " +
                    "VALUES(@name, @gender, @DateOfBirth, @color, @race) ";

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