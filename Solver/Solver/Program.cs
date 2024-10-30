using System;
using System.IO;

namespace Solver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите способ ввода данных:");
            Console.WriteLine("1. Считать из файла");
            Console.WriteLine("2. Ввести с клавиатуры");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Введите путь к файлу с коэффициентами уравнений (формат: a b c):");
                string filePath = Console.ReadLine();

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Файл не найден.");
                    return;
                }

                foreach (var line in File.ReadLines(filePath))
                {
                    ProcessEquation(line);
                }
            }
            else if (choice == "2")
            {
                Console.WriteLine("Введите коэффициенты квадратного уравнения (формат: a b c):");
                string input;
                while ((input = Console.ReadLine()) != null && input.Trim() != "")
                {
                    ProcessEquation(input);
                }
            }
            else
            {
                Console.WriteLine("Некорректный выбор.");
            }
        }

        private static void ProcessEquation(string line)
        {
            var sanitizedLine = line.Replace('.', ',');
            var parts = sanitizedLine.Split(' ');

            if (parts.Length != 3 ||
                !double.TryParse(parts[0], out double a) ||
                !double.TryParse(parts[1], out double b) ||
                !double.TryParse(parts[2], out double c))
            {
                Console.WriteLine($"Некорректная строка: {line}");
                return;
            }

            try
            {
                var (x1, x2) = EquationSolver.SolveQuadratic(a, b, c);

                if (x1.HasValue && x2.HasValue)
                {
                    Console.WriteLine($"Корни уравнения {a}x^2 + {b}x + {c} = 0: x1 = {x1}, x2 = {x2}");
                }
                else
                {
                    Console.WriteLine($"Уравнение {a}x^2 + {b}x + {c} = 0 не имеет действительных корней.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}