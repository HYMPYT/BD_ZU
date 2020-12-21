using BDLZ.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace BDLZ.Controllers
{
    public class TeacherController : BaseController
    {
        public TeacherController(string connectionString) : base(connectionString) { }
        public override void Read(string whereCondition)
        {
            Console.Clear();

            sqlConnection.Open();

            string sqlSelect = "select id, name, surname, salary from groups";

            using var cmd = new NpgsqlCommand(sqlSelect + whereCondition, sqlConnection);
            try
            {
                using NpgsqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine("Id: {0}", rdr.GetValue(0));
                    Console.WriteLine("Name: {0}", rdr.GetValue(1));
                    Console.WriteLine("Surname: {0}", rdr.GetValue(2));
                    Console.WriteLine("Salary: {0}", rdr.GetValue(3));
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
            string sqlInsert = "Insert into teacher(name, surname, salary) VALUES(@name, @surname, @salary)";

            var teacher = new Teacher();

            Console.Clear();
            Console.WriteLine("Enter Teacher properties:");
            Console.WriteLine("Name:");
            teacher.name = Console.ReadLine();

            Console.WriteLine("Surname:");
            teacher.surname = Console.ReadLine();

            Console.WriteLine("Salary:");
            teacher.salary = Decimal.Parse(Console.ReadLine());

            sqlConnection.Open();

            using var cmd = new NpgsqlCommand(sqlInsert, sqlConnection);
            cmd.Parameters.AddWithValue("name", teacher.name);
            cmd.Parameters.AddWithValue("surname", teacher.surname);
            cmd.Parameters.AddWithValue("salary", teacher.salary);
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
            base.Delete("delete from teachers where id = ");
        }
        public override void Update()
        {
            base.Update("Update teachers ");
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

            string sqlGenerate = "insert into teachers(name, surname, salary) (select "
                + base.sqlRandomString
                + ", "
                + base.sqlRandomString
                + ", "
                + base.sqlRandomInteger
                + " from generate_series(1, 1000000)  limit(" + recordsAmount + "))";
            base.Generate(sqlGenerate);
        }

    }
}
