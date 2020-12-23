using BDLZ.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace BDLZ.Controllers
{
    public class FacultyController : BaseController
    {
        public FacultyController( ) : base() { }
        public override void Read( )
        {
            Console.Clear();
            try
            {

                foreach(var i in context.faculties)
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
            string name = null;

            Console.Clear();
            Console.WriteLine("Enter Companies properties:");
            Console.WriteLine("Name:");
            name = Console.ReadLine();

            try
            {
                context.faculties.Add(new Faculty { name = name });
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
            var entity = context.faculties.Find(base.deleteId);
            context.faculties.Remove(entity);
            context.SaveChanges();
        }
        public override void Update()
        {
            base.Update();
            var entity = context.faculties.Find(base.updateId);
            context.faculties.Update(entity);
            context.SaveChanges();
        }
        public override void Find()
        {
            base.Find();
            var i = context.faculties.Find(base.findId);
            Console.WriteLine("Id: {0}", i.id);
            Console.WriteLine("Name: {0}", i.name);
            Console.WriteLine();
            
        }

    }
}
