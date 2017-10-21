using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                Student st = new Student(input[0]);
                for (int j = 1; j < input.Length; j++)
                {
                    st.Grades.Add(double.Parse(input[j]));
                }
                students.Add(st);

            }
            for (int i = 0; i < students.Count; i++)
            {
                students[i].AverageGrade = students[i].Grades.Average();
            }

            var validStudents = students.Where(x => x.AverageGrade >= 5.00).ToList();
            var sortedValidStudents = validStudents.OrderBy(x => x.Name).ThenByDescending(x => x.AverageGrade).ToList();
            for (int i = 0; i < sortedValidStudents.Count; i++)
            {
                Console.WriteLine("{0} -> {1:F2}",sortedValidStudents[i].Name, sortedValidStudents[i].AverageGrade);
            }
        }

        
    }

    class Student
    {
        public string Name { get; set; }
        public List<double> Grades { get; set; }

        public double AverageGrade { get; set; }

        public Student(string name)
        {
            this.Name = name;
            this.Grades = new List<double>();
        }
    }
}
