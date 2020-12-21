using BDLZ.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace BDLZ.Controllers
{
    public class StudentController : BaseController
    {
        public StudentController(string connectionString) : base(connectionString) { }
        public override void Read(string whereCondition)
        {
            Console.Clear();

            sqlConnection.Open();

            string sqlSelect = "select id, name, surname,age, group_id from students";

            using var cmd = new NpgsqlCommand(sqlSelect + whereCondition, sqlConnection);
            try
            {
                using NpgsqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine("Id: {0}", rdr.GetValue(0));
                    Console.WriteLine("Name: {0}", rdr.GetValue(1));
                    Console.WriteLine("Surname: {0}", rdr.GetValue(2));
                    Console.WriteLine("Age: {0}", rdr.GetValue(3));
                    Console.WriteLine("Group_id: {0}", rdr.GetValue(4));
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            finally
            {
                sqlConnection.Close();
            }


            Console.ReadLine();
        }

        public override void Create()
        {
            string sqlInsert = "Insert into students(name, surname, age, group_id) VALUES(@name, @surname, @age, @group_id)";

            var student = new Student();

            Console.Clear();
            Console.WriteLine("Enter Student properties:");
            Console.WriteLine("Name:");
            student.name = Console.ReadLine();

            Console.WriteLine("Surname:");
            student.surname = Console.ReadLine();

            Console.WriteLine("Age:");
            student.age = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Group id:");
            student.group_id = Int32.Parse(Console.ReadLine());
            
            sqlConnection.Open();

            using var cmd = new NpgsqlCommand(sqlInsert, sqlConnection);
            cmd.Parameters.AddWithValue("name", student.name);
            cmd.Parameters.AddWithValue("surname", student.surname);
            cmd.Parameters.AddWithValue("group_id", student.group_id);
            cmd.Parameters.AddWithValue("age", student.age);
            cmd.Prepare();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public override void Delete()
        {
            base.Delete("delete from students where id = ");
        }
        public override void Update()
        {
            base.Update("Update students ");
        }
        public override void Find()
        {
            base.Find();
        }

        public override void Generate()
        {
            Console.WriteLine("How many records do you want?");
            bool correct = false;
            int recordsAmount;

            correct = Int32.TryParse(Console.ReadLine(), out recordsAmount);

            string sqlGenerate = "insert into students(name, surname, age, group_id) (select "
                + base.sqlRandomString
                + ", "
                + base.sqlRandomString
                + ", 18 + trunc(random() * 10)::int"
                + ", groups.id from generate_series(1, 1000000), groups  limit(" + recordsAmount + "))";
            base.Generate(sqlGenerate);
        }

    }
}
