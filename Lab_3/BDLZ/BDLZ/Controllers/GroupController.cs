using BDLZ.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace BDLZ.Controllers
{
    public class GroupController : BaseController
    {
        public GroupController( ) : base() { }
        public override void Read( )
        {
            Console.Clear();

            try
            {
                
                foreach(var i in context.groups)
                {
                    Console.WriteLine("Id: {0}", i.id);
                    Console.WriteLine("Name: {0}", i.name);
                    Console.WriteLine("Year: {0}", i.year);
                    Console.WriteLine("amount_of_students: {0}", i.year);
                    Console.WriteLine("faculty_id: {0}", i.faculty_id);
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
            var group = new Group();

            Console.Clear();
            Console.WriteLine("Enter Group properties:");
            Console.WriteLine("Name:");
            group.name = Console.ReadLine();
                
            Console.WriteLine("Year:");
            group.year = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Amount of students:");
            group.amount_of_students = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Faculty id:");
            group.faculty_id = Int32.Parse(Console.ReadLine());
            

            try
            {
                context.groups.Add(group);
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
            var entity = context.groups.Find(base.deleteId);
            context.groups.Remove(entity);
            context.SaveChanges();
        }
        public override void Update()
        {
            base.Update();
            var entity = context.groups.Find(base.updateId);
            context.groups.Update(entity);
            context.SaveChanges();
        }
        public override void Find()
        {
            base.Find();
            var i = context.groups.Find(base.findId);
            Console.WriteLine("Id: {0}", i.id);
            Console.WriteLine("Name: {0}", i.name);
            Console.WriteLine("Year: {0}", i.year);
            Console.WriteLine("amount_of_students: {0}", i.year);
            Console.WriteLine("faculty_id: {0}", i.faculty_id);
            Console.WriteLine();
        }

    }
}
