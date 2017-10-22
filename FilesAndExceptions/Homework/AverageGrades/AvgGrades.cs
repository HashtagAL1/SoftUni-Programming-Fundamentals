using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AverageGrades
{
    class AvgGrades
    {
        static void Main(string[] args)
        {
            File.Delete("output.txt");
            string[] lines = File.ReadAllLines("input.txt");
            int n = int.Parse(lines[0]);
            List<Student> students = new List<Student>();

            
            for (int j = 1; j < lines.Length; j++)
            {
                string[] input = lines[j].Split(' ');
                Student st = new Student(input[0]);
                for (int k = 1; k < input.Length; k++)
                {
                    st.Grades.Add(double.Parse(input[k]));
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
                File.AppendAllText("output.txt", $"{sortedValidStudents[i].Name} -> {sortedValidStudents[i].AverageGrade}" + Environment.NewLine);
                //Console.WriteLine("{0} -> {1:F2}", sortedValidStudents[i].Name, sortedValidStudents[i].AverageGrade);
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
