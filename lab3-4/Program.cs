using System;
using System.IO;
using System.Linq;

namespace lab3_4
{
    public class Student
    {
        private string vardas;
        private string pavarde;
        private int numberOfHomework;
        private int examGrade;
        private double finalResultAvarage;
        private double finalResultMedian;

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
        public double FinalResultMedian
        {
            get => finalResultMedian;
            set => finalResultMedian = value;
        }

        public Student(string vardas, string pavarde, int nuberofhomework, int examgrade, double finalresultavarage, double finalResultMedian)
        {
            this.Vardas = vardas;
            this.Pavarde = pavarde;
            this.NumberOfHomeWork = nuberofhomework;
            this.ExamGrade = examgrade;
            this.FinalResultAvarage = finalresultavarage;
            this.FinalResultMedian = finalResultMedian;
        }

        public Student()
        {
        }
        public void FinalResult(Student[] studentArray)
        {
            int sum = 0;
            Random rnd = new Random();
            foreach (var i in studentArray)
            {
                try
                {
                    Console.WriteLine("Ar " + i.Vardas + " " + i.Pavarde + " balus: \n1. Parinkti atsitiktinai\n2. Suvesti ranka\n");
                    int c = Convert.ToInt32(Console.ReadLine());
                    int[] grades = new int[i.NumberOfHomeWork];
                    if (c == 1)
                    {
                        for (int r = 0; r < i.NumberOfHomeWork; r++)
                        {
                            grades[r] = rnd.Next(1, 10);
                            sum += grades[r];
                        }
                        i.ExamGrade = rnd.Next(1, 10);
                    }
                    else
                    {
                        for (int r = 0; r < i.NumberOfHomeWork; r++)
                        {
                            Console.WriteLine("Irasykite bala\n");
                            grades[r] = Convert.ToInt32(Console.ReadLine());
                            sum += grades[r];
                        }
                        i.ExamGrade = rnd.Next(1, 10);
                    }
                    double finalRes = (0.3 * (sum / i.NumberOfHomeWork)) + (0.7 * i.ExamGrade);
                    i.finalResultAvarage = finalRes;
                    int halfIndex = i.NumberOfHomeWork % 2;
                    var sortedGrades = grades.OrderBy(n => n);
                    double median;
                    if ((i.NumberOfHomeWork % 2) == 0)
                    {
                        median = ((sortedGrades.ElementAt(halfIndex) +
            sortedGrades.ElementAt((halfIndex - 1))) / 2);
                    }
                    else
                    {
                        median = sortedGrades.ElementAt(halfIndex);
                    }
                    double finalResMed = (0.3 * median) + (0.7 * i.ExamGrade);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oops kazkas negerai (FinalResult())");
                }
            }
        }
        public void SortByName(Student[] studentArray)
        {
            foreach (var q in studentArray)
            {
                var SortedstudentArray = studentArray.OrderBy(n => n);
                foreach (var i in studentArray)
                {
                    File.AppendAllText("Students_Sorted_By_Name.csv", $"{i.Vardas},{i.Pavarde},{i.FinalResultAvarage},{i.FinalResultMedian}\n");
                }
            }
        }
        class Program

        {
            static void Main(string[] args)
            {

                try
                {
                    var lines = File.ReadAllLines(@"d:\Users\Sir Lancelot Joker\source\repos\lab3-4\lab3-4\students.csv");
                    Student[] studentArray = new Student[lines.Length];
                    int size = 0;
                    foreach (var i in lines)
                    {
                        var val = i.Split(',');
                        studentArray[size] = new Student(val[0], val[1], int.Parse(val[2]), int.Parse(val[3]), double.Parse(val[4]), double.Parse(val[5]));
                        size++;
                    }

                    Random rnd = new Random();
                    int sumOfGrades = 0;
                    int[] grades = new int[size];
                    for (int i = 0; i < size; i++)
                    {
                        grades[i] += rnd.Next(1, 10);
                        sumOfGrades += grades[i];
                    }

                    Student student = new Student();
                    student.FinalResult(studentArray);
                    student.SortByName(studentArray);
                    Console.WriteLine("Studentu sarasas:\n Vardas     Pavarde         Galutinis rezultas       Galutinis rezultas(median)\n--- ");
                    foreach (var i in studentArray)
                    {
                        Console.WriteLine(i.Vardas + " " + i.Pavarde + " " + i.FinalResultAvarage + " " + i.FinalResultMedian);

                    }
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine($"The file was not found: '{e}'");
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine($"The directory was not found: '{e}'");
                }
                catch (IOException e)
                {
                    Console.WriteLine($"The file could not be opened: '{e}'");
                }
                //double finalResult = (0.3 * (grades / numberOfHomeWork)) + (0.7 * examGrade);
            }
        }
    }
}
