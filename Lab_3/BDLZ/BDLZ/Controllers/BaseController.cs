using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace BDLZ.Controllers
{
    public abstract class BaseController
    {
        public BaseController()
        {
        }

        protected ApplicationContext context = new ApplicationContext();
        protected int findId;
        protected int updateId;
        protected int deleteId { get; set; }
        protected int recordsAmount;

        protected string fieldString;


        public virtual void Create()
        {
            
        }

        public virtual void Read()
        {
            throw new NotImplementedException();
        }

        public virtual void Update()
        {
            Console.WriteLine("Enter id of entity you want to update:");
            updateId = Int32.Parse(Console.ReadLine());
        }

        public virtual void Delete()
        {

            bool success = false;
            int id = 0;
            do
            {
                Console.WriteLine("Enter number of record you want to delete (or 0 to step back):");
                success = Int32.TryParse(Console.ReadLine(), out id);
                if (success == false)
                {
                    Console.WriteLine("Id must be a number...");
                    Console.ReadLine();
                    continue;
                }
            } while (success == false || id < 0);
            this.deleteId = id;
        }

        public virtual void Find()
        {
            Console.WriteLine("Enter id of record you want to find");
            findId = Int32.Parse(Console.ReadLine());
        }
    }
}
