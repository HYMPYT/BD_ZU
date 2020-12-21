using BDLZ.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace BDLZ.Controllers
{
    public class GroupController : BaseController
    {
        public GroupController(string connectionString) : base(connectionString) { }
        public override void Read(string whereCondition)
        {
            Console.Clear();

            sqlConnection.Open();

            string sqlSelect = "select id, name, year, amount_of_students, faculcy_id from groups";

            using var cmd = new NpgsqlCommand(sqlSelect + whereCondition, sqlConnection);
            try
            {
                using NpgsqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine("Id: {0}", rdr.GetValue(0));
                    Console.WriteLine("Name: {0}", rdr.GetValue(1));
                    Console.WriteLine("Year: {0}", rdr.GetValue(2));
                    Console.WriteLine("amount_of_students: {0}", rdr.GetValue(3));
                    Console.WriteLine("faculty_id: {0}", rdr.GetValue(3));
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
            string sqlInsert = "Insert into groups(name, year, amount_of_students, faculcy_id) VALUES(@name, @year, @amount_of_students, @faculcy_id)";

            var group = new Group();

            Console.Clear();
            Console.WriteLine("Enter Companies properties:");
            Console.WriteLine("Name:");
            group.name = Console.ReadLine();
                
            Console.WriteLine("Owner:");
            group.year = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Amount of students:");
            group.amount_of_students = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Faculty id:");
            group.faculty_id = Int32.Parse(Console.ReadLine());
            

            sqlConnection.Open();

            using var cmd = new NpgsqlCommand(sqlInsert, sqlConnection);
            cmd.Parameters.AddWithValue("name", group.name);
            cmd.Parameters.AddWithValue("year", group.year);
            cmd.Parameters.AddWithValue("amount_of_students", group.amount_of_students);
            cmd.Parameters.AddWithValue("faculcy_id", group.faculty_id);
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
            base.Delete("delete from groups where id = ");
        }
        public override void Update()
        {
            base.Update("Update groups ");
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

            string sqlGenerate = "insert into groups(name, year, amount_of_students, faculcy_id) (select "
                + base.sqlRandomString
                + ", "
                + base.sqlRandomInteger
                + ", "
                + base.sqlRandomInteger
                + ", "
                + base.sqlRandomInteger
                + " from generate_series(1, 1000000)  limit(" + recordsAmount + "))";
            base.Generate(sqlGenerate);
        }

    }
}
