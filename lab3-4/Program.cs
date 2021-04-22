using System;
using System.Linq;

namespace lab3_4
{

    class Program
    {
        static void Main(string[] args)
        {
            int examGrade, sumOfGrades=0;

            Console.WriteLine("Iveskite varda\n");
            string name = Console.ReadLine();

            Console.WriteLine("\nIveskite pavarde\n");
            string surname = Console.ReadLine();

            Console.WriteLine("\nIveskite namu darbu skaiciu\n");
            int numberOfHomeWork = Convert.ToInt32(Console.ReadLine());

            int[] grades = new int[numberOfHomeWork];

            Console.WriteLine("\nAr norite kad pazymiai butu sukurti atsitiktine tvarka? (T - taip; N - ne)\n");
            string answer = Console.ReadLine();

            if (answer == "N")
            {
                for (int i = 0; i < numberOfHomeWork; i++)
                {
                    Console.WriteLine("\nIveskite namu darbu pazymi nuo 1-10\n");
                    grades[i] = Convert.ToInt32(Console.ReadLine());
                    if (grades[i] > 0 && grades[i] <= 10)
                    {
                        sumOfGrades += grades[i];
                    }
                    else
                    {
                        Console.WriteLine("\nIvestas blogas pazymis\n");
                        i--;
                    }
                }
            }

            Console.WriteLine("\nIveskite egzamino ivertinima nuo 1-10\n");
           int g = Convert.ToInt32(Console.ReadLine());
            if ( g> 0 && g <= 10)
                examGrade = g;
            else
            {
                Console.WriteLine("Ivyko klaida <(O_O<)<(O_O)>(>O_O)>\n");
                return;
            }
            int halfIndex = numberOfHomeWork / 2;
            var sortedGrades = grades.OrderBy(n =>n);
            double median;
            if ((numberOfHomeWork % 2) == 0)
            {
                median = ((sortedGrades.ElementAt(halfIndex) + sortedGrades.ElementAt((halfIndex - 1))) / 2);
            }
            else
            {
                median = sortedGrades.ElementAt(halfIndex);
            }
            double finalResultAvarage = (0.3 * (sumOfGrades / numberOfHomeWork)) + (0.7 * examGrade);
            double finalResultMedian = (0.3 * median) + (0.7 * examGrade);
            Console.WriteLine("\nPavarde " + surname + "\nVardas" + name + "\nGalutinis resultatas (vidurkis) - " + String.Format("{0:0.00}", finalResultAvarage)+ String.Format("{0:0.00}", finalResultMedian));
        }
    }
}
