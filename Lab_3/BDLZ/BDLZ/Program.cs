using BDLZ.Controllers;
using System;

namespace BDLZ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            int table = 0;
            int action = 0;
            do
            {
                table = FirstMenu();
                if (table == 0)
                {
                    return;
                }

                BaseController controller = null;

                switch (table)
                {
                    case 1:
                        action = SecondMenu("Faculty");
                        controller = new FacultyController();
                        break;
                    case 2:
                        action = SecondMenu("Group");
                        controller = new GroupController();
                        break;
                    case 3:
                        action = SecondMenu("Lectures");
                        controller = new LecturesPlanController();
                        break;
                    case 4:
                        action = SecondMenu("Student");
                        controller = new StudentController();
                        break;
                    case 5:
                        action = SecondMenu("Subject");
                        controller = new SubjectController();
                        break;
                    case 6:
                        action = SecondMenu("Teacher");
                        controller = new TeacherController();
                        break;
                }


                switch (action)
                {
                    case 1:
                        controller.Create();
                        break;
                    case 2:
                        controller.Read();
                        break;
                    case 3:
                        controller.Update();
                        break;
                    case 4:
                        controller.Delete();
                        break;
                    case 5:
                        controller.Find();
                        break;
                }



            } while (true);
        }

        public static int FirstMenu()
        {
            var choice = 0;
            var correct = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Enter table number or 0 to exit:");
                Console.WriteLine("1.\tFaculty");
                Console.WriteLine("2.\tGroup");
                Console.WriteLine("3.\tLecturesPlan");
                Console.WriteLine("4.\tStudent");
                Console.WriteLine("5.\tSubject");
                Console.WriteLine("6.\tTeacher");
                correct = Int32.TryParse(Console.ReadLine(), out choice);
            } while (choice < 0 || choice > 6 || correct == false);


            return choice;
        }

        public static int SecondMenu(string tableToChange)
        {
            var choice = 0;
            var correct = false;
            do
            {
               // Console.Clear();
                Console.WriteLine("Choose what you want to do with '" + tableToChange + "' table:");
                Console.WriteLine("Enter number in range 1-6 or 0 to exit:");
                Console.WriteLine("1.\tCreate");
                Console.WriteLine("2.\tRead");
                Console.WriteLine("3.\tUpdate");
                Console.WriteLine("4.\tDelete");
                Console.WriteLine("5.\tFind");
                Console.WriteLine("6.\tGenerate");
                correct = Int32.TryParse(Console.ReadLine(), out choice);
            } while (choice < 0 || choice > 6 || correct == false);

            return choice;
        }
    }
}
