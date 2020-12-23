using BDLZ.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace BDLZ.Controllers
{
    public class TeacherController : BaseController
    {
        public TeacherController() : base() { }
        public override void Read()
        {
            Console.Clear();

            try
            {
                foreach(var i in context.teachers)
                {
                    Console.WriteLine("Id: {0}", i.id);
                    Console.WriteLine("Name: {0}", i.name);
                    Console.WriteLine("Surname: {0}", i.surname);
                    Console.WriteLine("Salary: {0}", i.salary);
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

            Console.ReadLine();
        }

        public override void Create()
        {
            var teacher = new Teacher();

            Console.Clear();
            Console.WriteLine("Enter Teacher properties:");
            Console.WriteLine("Name:");
            teacher.name = Console.ReadLine();

            Console.WriteLine("Surname:");
            teacher.surname = Console.ReadLine();

            Console.WriteLine("Salary:");
            teacher.salary = Decimal.Parse(Console.ReadLine());


            try
            {
                context.teachers.Add(teacher);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

        }

        public override void Delete()
        {
            base.Delete();
            var entity = context.teachers.Find(base.deleteId);
            context.teachers.Remove(entity);
            context.SaveChanges();
        }
        public override void Update()
        {
            base.Update();
            var entity = context.teachers.Find(base.updateId);
            context.teachers.Update(entity);
            context.SaveChanges();
        }
        public override void Find()
        {
            base.Find();
            var i = context.teachers.Find(base.findId);

            Console.WriteLine("Id: {0}", i.id);
            Console.WriteLine("Name: {0}", i.name);
            Console.WriteLine("Surname: {0}", i.surname);
            Console.WriteLine("Salary: {0}", i.salary);
            Console.WriteLine();
        }
    }
}
