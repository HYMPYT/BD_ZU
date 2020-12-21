using BDLZ.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace BDLZ.Controllers
{
    public class LecturesPlanController : BaseController
    {
        public LecturesPlanController(string connectionString) : base(connectionString) { }
        public override void Read(string whereCondition)
        {
            Console.Clear();

            sqlConnection.Open();

            string sqlSelect = "select id, group_id, subject_id, teacher_id from lectures_plan";

            using var cmd = new NpgsqlCommand(sqlSelect + whereCondition, sqlConnection);
            try
            {
                using NpgsqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine("Id: {0}", rdr.GetValue(0));
                    Console.WriteLine("group_id: {0}", rdr.GetValue(1));
                    Console.WriteLine("subject_id: {0}", rdr.GetValue(2));
                    Console.WriteLine("teacher_id: {0}", rdr.GetValue(3));
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
            string sqlInsert = "Insert into lectures_plan(group_id, subject_id, teacher_id) VALUES(@group_id, @subject_id, @teacher_id)";

            var lecturesPlan = new LecturesPlan();

            Console.Clear();
            Console.WriteLine("Enter Lectures_plan properties:");
            Console.WriteLine("Group id:");
            lecturesPlan.group_id = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Subject id:");
            lecturesPlan.subject_id = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Teacher id:");
            lecturesPlan.teacher_id = Int32.Parse(Console.ReadLine());

            sqlConnection.Open();

            using var cmd = new NpgsqlCommand(sqlInsert, sqlConnection);
            cmd.Parameters.AddWithValue("group_id", lecturesPlan.group_id);
            cmd.Parameters.AddWithValue("subject_id", lecturesPlan.subject_id);
            cmd.Parameters.AddWithValue("teacher_id", lecturesPlan.teacher_id);
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
            base.Delete("delete from lectures_plan where id = ");
        }
        public override void Update()
        {
            base.Update("Update lectures_plan ");
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

            string sqlGenerate = "insert into lectures_plan(group_id, subject_id, teacher_id) (select "
                + "groups.id, subjects.id, teachers.id from groups, subjects, teachers  limit(" + recordsAmount + "))";
            base.Generate(sqlGenerate);
        }
    }
}
