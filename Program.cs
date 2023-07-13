using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace student_management
{
    class Program
    {
        class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Sex { get; set; }
            public int Age { get; set; }
            public double PointMath { get; set; }
            public double PointPhysics { get; set; }
            public double PointChemistry { get; set; }
            public double PointAverage { get; set; }
            public string Level { get; set; }
        }

        class StudentManagement
        {
            private List<Student> ListStudent = null;

            public StudentManagement() 
            {
                ListStudent = new List<Student>();
            }

            public int GenerateID()
            {
                int max = 1;
                if(ListStudent != null && ListStudent.Count > 0)
                {
                    max = ListStudent[0].Id;
                    foreach(Student sv in ListStudent)
                    {
                        if (max < sv.Id)
                        {
                            max = sv.Id;
                        }
                    }
                    max++;
                }
                return max;
            }

            public void EnterStudent()
            {
                Student sv = new Student();
                sv.Id = GenerateID();

                Console.Write("Enter name's student: ");
                sv.Name = Console.ReadLine();

                Console.Write("Enter sex's student: ");
                sv.Sex = Console.ReadLine();

                Console.Write("Enter age's student: ");
                sv.Age = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter point math: ");
                sv.PointMath = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter point physics: ");
                sv.PointPhysics = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter point chemistry: ");
                sv.PointChemistry = Convert.ToDouble(Console.ReadLine());

                ListStudent.Add(sv);
            }
            
            public void ShowStudent(List<Student> ListS)
            {
                Console.WriteLine("ID     Name              Sex     Age     Point math     Point physics     Point chemistry     Point average");

                if(ListS != null && ListS.Count > 0)
                {
                    foreach(Student s in ListS)
                    {
                        Console.WriteLine(s.Id +"     "+ s.Name + "              " + s.Sex + "     " + s.Age + "     " + s.PointMath + "     " + s.PointPhysics + "     " + s.PointChemistry + "     " + s.PointAverage);
                    }
                }
                Console.WriteLine();
            }


            public List<Student> GetListStudent()
            {
                return ListStudent;
            }
        }


        static void Main(string[] args)
        {
            StudentManagement SM = new StudentManagement();

            SM.EnterStudent();
         
            SM.ShowStudent(SM.GetListStudent());
            Console.ReadLine();
        }
    }
}
