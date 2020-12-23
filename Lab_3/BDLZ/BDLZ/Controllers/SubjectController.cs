using BDLZ.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace BDLZ.Controllers
{
    public class SubjectController : BaseController
    {
        public SubjectController() : base() { }
        public override void Read()
        {
            Console.Clear();
            try
            {
                foreach(var i in context.subjects)
                {
                    Console.WriteLine("Id: {0}", i.id);
                    Console.WriteLine("Name: {0}", i.name);
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
            string sqlInsert = "Insert into subjects(name) VALUES(@name)";

            var subject = new Subject();

            Console.Clear();
            Console.WriteLine("Enter Subjects properties:");
            Console.WriteLine("Name:");
            subject.name = Console.ReadLine();
            
            try
            {
                context.subjects.Add(subject);
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
            var entity = context.subjects.Find(base.deleteId);
            context.subjects.Remove(entity);
            context.SaveChanges();
        }
        public override void Update()
        {
            base.Update();
            var entity = context.subjects.Find(base.updateId);
            context.subjects.Update(entity);
            context.SaveChanges();
        }
        public override void Find()
        {
            base.Find();
            var i = context.subjects.Find(base.findId);

            Console.WriteLine("Id: {0}", i.id);
            Console.WriteLine("Name: {0}", i.name);
            Console.WriteLine();
        }
    }
}
