using System;
using System.IO;

namespace lab3_4
{
    public class Student
    {
        private string vardas;
        private string pavarde;
        private int numberOfHomework;
        private int examGrade;
        private double finalResultAvarage;

        public string Vardas
        {
            get => vardas;
            set => vardas = value;
        }

        public string Pavarde
        {
            get => pavarde;
            set => pavarde = value;
        }

        public int NumberOfHomeWork
        {
            get => numberOfHomework;
            set => numberOfHomework = value;
        }

        public int ExamGrade
        {
            get => examGrade;
            set => examGrade = value;
        }

        public double FinalResultAvarage
        {
            get => finalResultAvarage;
            set => finalResultAvarage = value;
        }


        public Student(string vardas, string pavarde, int nuberofhomework, int examgrade, double finalresultavarage)
        {
            this.Vardas = vardas;
            this.Pavarde = pavarde;
            this.NumberOfHomeWork = nuberofhomework;
            this.ExamGrade = examgrade;
            this.FinalResultAvarage = finalresultavarage;
        }

        public Student()
        {
        }
public void FinalReesult(Student[] studentArray)
        {
            int sum=0;
            Random rnd = new Random();
            foreach(var i in studentArray)
            {
                int[] grades = new int[i.NumberOfHomeWork];
                for (int r = 0; r<0; r++)
                {
                    grades[r] = rnd.Next(1, 10);
                    sum += grades[r];
                }
                double finalRes = (0.3 * (sum / i.NumberOfHomeWork)) + (0.7 * i.ExamGrade);
                i.finalResultAvarage = finalRes;
            }
        }
        class Program

        {
            static void Main(string[] args)
            {
                
                var lines = File.ReadAllLines(@"d:\Users\Sir Lancelot Joker\source\repos\lab3-4\lab3-4\students.csv");
                Student[] studentArray = new Student[lines.Length];
                int size = 0;
                foreach (var i in lines)
                {
                    var val = i.Split(',');
                    studentArray[size] = new Student(val[0], val[1], int.Parse(val[2]), double.Parse(val[3]));
                    size++;
                }
                Random rnd = new Random();
                int sumOfGrades = 0;
                int[] grades = new int[size];
                for (int i = 0; i<size; i++)
                {
                    grades[i] += rnd.Next(1, 10);
                    sumOfGrades += grades[i];
                }
                Console.WriteLine("Studentu sarasas: ");
                foreach (var i in studentArray)
                {
                    Console.WriteLine(i.Vardas + " " + i.Pavarde + " ");
                    
                }
                //double finalResult = (0.3 * (grades / numberOfHomeWork)) + (0.7 * examGrade);
            }
        }
    }
}
