using BDLZ.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace BDLZ.Controllers
{
    public class StudentController : BaseController
    {
        public StudentController() : base() { }
        public override void Read()
        {
            Console.Clear();

            try
            {
                foreach(var i in context.students)
                {
                    Console.WriteLine("Id: {0}", i.id);
                    Console.WriteLine("Name: {0}", i.name);
                    Console.WriteLine("Surname: {0}", i.surname);
                    Console.WriteLine("Age: {0}", i.age);
                    Console.WriteLine("Group_id: {0}", i.group_id);
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
            

            try
            {
                context.students.Add(student);
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
            var entity = context.students.Find(base.deleteId);
            context.students.Remove(entity);
            context.SaveChanges();
        }
        public override void Update()
        {
            base.Update();
            var entity = context.students.Find(base.updateId);
            context.students.Update(entity);
            context.SaveChanges();
        }
        public override void Find()
        {
            base.Find();
            var i = context.students.Find(base.findId);

            Console.WriteLine("Id: {0}", i.id);
            Console.WriteLine("Name: {0}", i.name);
            Console.WriteLine("Surname: {0}", i.surname);
            Console.WriteLine("Age: {0}", i.age);
            Console.WriteLine("Group_id: {0}", i.group_id);
            Console.WriteLine();
        }

    }
}
