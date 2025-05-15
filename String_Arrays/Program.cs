using System;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== Меню завдань ====");
            Console.WriteLine("1. Кількість парних, непарних, унікальних елементів масиву");
            Console.WriteLine("2. Кількість значень менше заданого числа");
            Console.WriteLine("3. Пошук послідовності трьох чисел в масиві");
            Console.WriteLine("4. Загальні елементи двох масивів без повторень");
            Console.WriteLine("5. Мінімальне і максимальне значення у двовимірному масиві");
            Console.WriteLine("6. Підрахунок кількості слів у реченні");
            Console.WriteLine("7. Перевертання кожного слова в реченні");
            Console.WriteLine("8. Підрахунок кількості голосних літер у реченні");
            Console.WriteLine("9. Підрахунок входжень підрядка в рядок");
            Console.WriteLine("0. Вихід");
            Console.Write("\nВиберіть завдання (0-9): ");

            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > 9)
            {
                Console.WriteLine("Невірний вибір. Натисніть будь-яку клавішу для продовження...");
                Console.ReadKey();
                continue;
            }

            if (choice == 0) break;

            Console.Clear();
            switch (choice)
            {
                case 1: Task1(); break;
                case 2: Task2(); break;
                case 3: Task3(); break;
                case 4: Task4(); break;
                case 5: Task5(); break;
                case 6: Task6(); break;
                case 7: Task7(); break;
                case 8: Task8(); break;
                case 9: Task9(); break;
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу для повернення в меню...");
            Console.ReadKey();
        }
    }

    // Завдання 1
    static void Task1()
    {
        Console.WriteLine("=== Завдання 1: Кількість парних, непарних, унікальних елементів масиву ===\n");
        
        int[] array = InputArray();
        
        int evenCount = array.Count(x => x % 2 == 0);
        int oddCount = array.Count(x => x % 2 != 0);
        int uniqueCount = array.Distinct().Count();
        
        Console.WriteLine($"Кількість парних елементів: {evenCount}");
        Console.WriteLine($"Кількість непарних елементів: {oddCount}");
        Console.WriteLine($"Кількість унікальних елементів: {uniqueCount}");
    }

    // Завдання 2
    static void Task2()
    {
        Console.WriteLine("=== Завдання 2: Кількість значень менше заданого числа ===\n");
        
        int[] array = InputArray();
        
        Console.Write("Введіть число для порівняння: ");
        if (int.TryParse(Console.ReadLine(), out int threshold))
        {
            int countLess = array.Count(x => x < threshold);
            Console.WriteLine($"Кількість значень менших за {threshold}: {countLess}");
        }
        else
        {
            Console.WriteLine("Помилка введення числа.");
        }
    }

    // Завдання 3
    static void Task3()
    {
        Console.WriteLine("=== Завдання 3: Пошук послідовності трьох чисел в масиві ===\n");
        
        int[] array = InputArray();
        
        Console.WriteLine("Введіть три числа послідовності:");
        int[] sequence = new int[3];
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Число {i + 1}: ");
            if (!int.TryParse(Console.ReadLine(), out sequence[i]))
            {
                Console.WriteLine("Помилка введення числа.");
                return;
            }
        }
        
        int count = 0;
        for (int i = 0; i <= array.Length - 3; i++)
        {
            if (array[i] == sequence[0] && array[i + 1] == sequence[1] && array[i + 2] == sequence[2])
            {
                count++;
            }
        }
        
        Console.WriteLine($"Послідовність {sequence[0]} {sequence[1]} {sequence[2]} зустрічається {count} разів");
    }

    // Завдання 4
    static void Task4()
    {
        Console.WriteLine("=== Завдання 4: Загальні елементи двох масивів без повторень ===\n");
        
        Console.WriteLine("Введіть перший масив:");
        int[] array1 = InputArray();
        
        Console.WriteLine("Введіть другий масив:");
        int[] array2 = InputArray();
        
        int[] commonElements = array1.Intersect(array2).ToArray();
        
        Console.WriteLine("Загальні елементи без повторень:");
        if (commonElements.Length == 0)
        {
            Console.WriteLine("Немає спільних елементів");
        }
        else
        {
            Console.WriteLine(string.Join(" ", commonElements));
        }
    }

    // Завдання 5
    static void Task5()
    {
        Console.WriteLine("=== Завдання 5: Мінімальне і максимальне значення у двовимірному масиві ===\n");
        
        Console.Write("Введіть кількість рядків: ");
        if (!int.TryParse(Console.ReadLine(), out int rows) || rows <= 0)
        {
            Console.WriteLine("Невірна кількість рядків.");
            return;
        }
        
        Console.Write("Введіть кількість стовпців: ");
        if (!int.TryParse(Console.ReadLine(), out int cols) || cols <= 0)
        {
            Console.WriteLine("Невірна кількість стовпців.");
            return;
        }
        
        int[,] matrix = new int[rows, cols];
        
        Console.WriteLine("Виберіть спосіб заповнення матриці:");
        Console.WriteLine("1. Випадковими числами");
        Console.WriteLine("2. Вручну");
        Console.Write("Ваш вибір (1-2): ");
        
        if (!int.TryParse(Console.ReadLine(), out int fillChoice) || (fillChoice != 1 && fillChoice != 2))
        {
            Console.WriteLine("Невірний вибір. Заповнюємо випадковими числами.");
            fillChoice = 1;
        }
        
        if (fillChoice == 1)
        {
            Random rnd = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rnd.Next(-100, 101);
                }
            }
        }
        else
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Елемент [{i},{j}]: ");
                    if (!int.TryParse(Console.ReadLine(), out matrix[i, j]))
                    {
                        Console.WriteLine("Помилка введення. Встановлено значення 0.");
                        matrix[i, j] = 0;
                    }
                }
            }
        }
        
        Console.WriteLine("\nМатриця:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{matrix[i, j],5}");
            }
            Console.WriteLine();
        }
        
        int min = matrix[0, 0];
        int max = matrix[0, 0];
        int minRow = 0, minCol = 0;
        int maxRow = 0, maxCol = 0;
        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    minRow = i;
                    minCol = j;
                }
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    maxRow = i;
                    maxCol = j;
                }
            }
        }
        
        Console.WriteLine($"\nМінімальне значення: {min} (позиція [{minRow},{minCol}])");
        Console.WriteLine($"Максимальне значення: {max} (позиція [{maxRow},{maxCol}])");
    }

    // Завдання 6
    static void Task6()
    {
        Console.WriteLine("=== Завдання 6: Підрахунок кількості слів у реченні ===\n");
        
        Console.WriteLine("Введіть речення:");
        string sentence = Console.ReadLine();
        
        string[] words = sentence.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        
        Console.WriteLine($"Кількість слів у реченні: {words.Length}");
    }

    // Завдання 7
    static void Task7()
    {
        Console.WriteLine("=== Завдання 7: Перевертання кожного слова в реченні ===\n");
        
        Console.WriteLine("Введіть речення:");
        string sentence = Console.ReadLine();
        
        string[] words = sentence.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        
        for (int i = 0; i < words.Length; i++)
        {
            char[] charArray = words[i].ToCharArray();
            Array.Reverse(charArray);
            words[i] = new string(charArray);
        }
        
        string reversed = string.Join(" ", words);
        Console.WriteLine("Результат перевертання:");
        Console.WriteLine(reversed);
    }

    // Завдання 8
    static void Task8()
    {
        Console.WriteLine("=== Завдання 8: Підрахунок кількості голосних літер у реченні ===\n");
        
        Console.WriteLine("Введіть речення:");
        string sentence = Console.ReadLine().ToLower();
        
        char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y', 'а', 'е', 'є', 'и', 'і', 'ї', 'о', 'у', 'ю', 'я' };
        int vowelCount = sentence.Count(c => vowels.Contains(c));
        
        Console.WriteLine($"Кількість голосних літер: {vowelCount}");
    }

    // Завдання 9
    static void Task9()
    {
        Console.WriteLine("=== Завдання 9: Підрахунок входжень підрядка в рядок ===\n");
        
        Console.WriteLine("Введіть текст:");
        string text = Console.ReadLine();
        
        Console.WriteLine("Введіть підрядок для пошуку:");
        string substring = Console.ReadLine();
        
        if (string.IsNullOrEmpty(substring))
        {
            Console.WriteLine("Підрядок не може бути порожнім.");
            return;
        }
        
        int count = CountSubstringOccurrences(text, substring);
        
        Console.WriteLine($"Підрядок '{substring}' зустрічається {count} разів");
    }

    static int CountSubstringOccurrences(string text, string substring)
    {
        int count = 0;
        int position = 0;
        
        while ((position = text.IndexOf(substring, position)) != -1)
        {
            count++;
            position += 1; 
        }
        
        return count;
    }

    static int[] InputArray()
    {
        Console.WriteLine("Виберіть спосіб введення масиву:");
        Console.WriteLine("1. Через пробіл (наприклад: 1 2 3 4 5)");
        Console.WriteLine("2. Випадково згенерований масив");
        Console.Write("Ваш вибір (1-2): ");
        
        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
        {
            Console.WriteLine("Невірний вибір. Використовуємо введення через пробіл.");
            choice = 1;
        }
        
        if (choice == 1)
        {
            Console.Write("Введіть елементи масиву через пробіл: ");
            string input = Console.ReadLine();
            string[] parts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            int[] array = new int[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                if (!int.TryParse(parts[i], out array[i]))
                {
                    Console.WriteLine($"Помилка конвертації '{parts[i]}'. Встановлено значення 0.");
                    array[i] = 0;
                }
            }
            
            return array;
        }
        else
        {
            Console.Write("Введіть розмір масиву: ");
            if (!int.TryParse(Console.ReadLine(), out int size) || size <= 0)
            {
                Console.WriteLine("Невірний розмір. Створено масив розміром 10.");
                size = 10;
            }
            
            Console.Write("Введіть мінімальне значення: ");
            if (!int.TryParse(Console.ReadLine(), out int min))
            {
                Console.WriteLine("Невірне значення. Встановлено -100.");
                min = -100;
            }
            
            Console.Write("Введіть максимальне значення: ");
            if (!int.TryParse(Console.ReadLine(), out int max) || max <= min)
            {
                Console.WriteLine("Невірне значення. Встановлено max = min + 200.");
                max = min + 200;
            }
            
            int[] array = new int[size];
            Random rnd = new Random();
            
            for (int i = 0; i < size; i++)
            {
                array[i] = rnd.Next(min, max + 1);
            }
            
            Console.WriteLine("Згенерований масив:");
            Console.WriteLine(string.Join(" ", array));
            
            return array;
        }
    }
}