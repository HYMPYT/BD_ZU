using BDLZ.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace BDLZ.Controllers
{
    public class LecturesPlanController : BaseController
    {
        public LecturesPlanController() : base() { }
        public override void Read()
        {
            Console.Clear();
            try
            {
                foreach(var i in context.lectures_plan)
                {
                    Console.WriteLine("Id: {0}", i.id);
                    Console.WriteLine("group_id: {0}", i.group_id);
                    Console.WriteLine("subject_id: {0}", i.subject_id);
                    Console.WriteLine("teacher_id: {0}", i.teacher_id);
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
            var lecturesPlan = new LecturesPlan();

            Console.Clear();
            Console.WriteLine("Enter Lectures_plan properties:");
            Console.WriteLine("Group id:");
            lecturesPlan.group_id = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Subject id:");
            lecturesPlan.subject_id = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Teacher id:");
            lecturesPlan.teacher_id = Int32.Parse(Console.ReadLine());

            try
            {
                context.lectures_plan.Add(lecturesPlan);
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
            var entity = context.lectures_plan.Find(base.deleteId);
            context.lectures_plan.Remove(entity);
            context.SaveChanges();
        }
        public override void Update()
        {
            base.Update();
            var entity = context.lectures_plan.Find(base.updateId);
            context.lectures_plan.Update(entity);
            context.SaveChanges();
        }
        public override void Find()
        {
            base.Find();
            var i = context.lectures_plan.Find(base.findId);

            Console.WriteLine("Id: {0}", i.id);
            Console.WriteLine("group_id: {0}", i.group_id);
            Console.WriteLine("subject_id: {0}", i.subject_id);
            Console.WriteLine("teacher_id: {0}", i.teacher_id);
            Console.WriteLine();
        }
    }
}
