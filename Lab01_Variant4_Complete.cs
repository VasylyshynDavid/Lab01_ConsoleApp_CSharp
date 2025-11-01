using System;
using System.Globalization;

class Program
{
    /// <summary>
    /// Коректно парсить рядок у тип double, приймаючи кому або крапку як роздільник.
    /// </summary>
    static double ParseDouble(string s)
    {
        // Видаляємо пробіли, замінюємо кому на крапку для уніфікації
        s = s.Trim().Replace(',', '.'); 
        // Використовуємо інваріантну культуру для парсингу з крапкою
        return double.Parse(s, CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Обчислює корінь п'ятого степеня, коректно працюючи з від'ємними числами.
    /// </summary>
    static double FifthRoot(double value)
    {
        // Повертає знак (1, -1 або 0) * (Корінь п'ятого степеня від абсолютного значення)
        return Math.Sign(value) * Math.Pow(Math.Abs(value), 1.0 / 5.0);
    }

    static void Main()
    {
        // 1. Ввід початкових даних
        Console.Write("Введіть початкове значення Xmin (напр., -3): ");
        double xMin = ParseDouble(Console.ReadLine());

        Console.Write("Введіть кінцеве значення Xmax (напр., 3): ");
        double xMax = ParseDouble(Console.ReadLine());

        Console.Write("Введіть приріст dX (напр., 0.1): ");
        double dx = ParseDouble(Console.ReadLine());

        // 2. Вивід заголовка таблиці
        // Форматування: x1-10 символів, x2-10 символів, y-20 символів
        Console.WriteLine($"\n{"x1",10}    {"x2",10}    {"y",20}");
        Console.WriteLine(new string('-', 42));

        // 3. Цикл табулювання
        // Додавання 1e-9 гарантує, що Xmax буде включено в обчислення
        for (double x1 = xMin; x1 <= xMax + 1e-9; x1 += dx)
        {
            // Обчислення залежної змінної: x2 = 3 * x1
            double x2 = 3.0 * x1; 
            
            // Обчислення внутрішнього виразу: 0.1*x1*sin(x2)*cos(x1^2) + 55*x1*x2
            double inner = 
                0.1 * x1 * Math.Sin(x2) * Math.Cos(x1 * x1) + 
                55 * x1 * x2;
            
            // Обчислення значення функції y: корінь п'ятого степеня від inner
            double y = FifthRoot(inner);
            
            // Вивід рядка таблиці
            // x1, x2: F2 (два знаки), y: F8 (вісім знаків)
            Console.WriteLine($"{x1,10:F2}    {x2,10:F2}    {y,20:F8}");
        }

        Console.ReadKey();
    }
}
