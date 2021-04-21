using System;

namespace lab3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int examGrade, grades=0;

            Console.WriteLine("Iveskite varda\n");
            string name = Console.ReadLine();

            Console.WriteLine("\nIveskite pavarde\n");
            string surname = Console.ReadLine();

            Console.WriteLine("\nIveskite namu darbu skaiciu\n");
            int numberOfHomeWork = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numberOfHomeWork; i++)
            {
                Console.WriteLine("\nIveskite namu darbu pazymi nuo 1-10\n");
                grades = Convert.ToInt32(Console.ReadLine());
                if (g > 0 && g <= 10)
                {
                    grades += grades;
                }
                else
                {
                    Console.WriteLine("\nIvestas blogas pazymis\n");
                    i--;
                }
            }

            Console.WriteLine("\nIveskite egzamino ivertinima nuo 1-10\n");
            g = Convert.ToInt32(Console.ReadLine());
            if (g > 0 && g <= 10)
                examGrade = g;
            else
            {
                Console.WriteLine("Ivyko klaida <(O_O<)<(O_O)>(>O_O)>\n");
                return;
            }

            double finalResult = (0.3 * (grades / numberOfHomeWork)) + (0.7 * examGrade);
        }
    }
}
