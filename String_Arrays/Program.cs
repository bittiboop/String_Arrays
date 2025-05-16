using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("==== Меню завдань ====");
            Console.WriteLine("1. Робота з одновимірним та двовимірним масивами");
            Console.WriteLine("2. Сума елементів між мінімальним і максимальним");
            Console.WriteLine("3. Шифр Цезаря");
            Console.WriteLine("4. Операції над матрицями");
            Console.WriteLine("5. Обчислення арифметичного виразу");
            Console.WriteLine("6. Зміна регістру першої літери в реченнях");
            Console.WriteLine("7. Перевірка тексту на неприпустимі слова");
            Console.WriteLine("0. Вихід");
            Console.Write("\nВиберіть завдання (0-7): ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.Clear();
                switch (choice)
                {
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        Task1();
                        break;
                    case 2:
                        Task2();
                        break;
                    case 3:
                        Task3();
                        break;
                    case 4:
                        Task4();
                        break;
                    case 5:
                        Task5();
                        break;
                    case 6:
                        Task6();
                        break;
                    case 7:
                        Task7();
                        break;
                    default:
                        Console.WriteLine("Невірний вибір завдання.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Некоректний ввід. Спробуйте ще раз.");
            }

            if (!exit)
            {
                Console.WriteLine("\nНатисніть будь-яку клавішу для повернення в меню...");
                Console.ReadKey();
            }
        }
    }

    // Завдання 1
    static void Task1()
    {
        Console.WriteLine("=== Завдання 1: Робота з одновимірним та двовимірним масивами ===\n");

        // Оголошення масивів
        const int A_SIZE = 5;
        const int B_ROWS = 3;
        const int B_COLS = 4;
        
        double[] A = new double[A_SIZE];
        double[,] B = new double[B_ROWS, B_COLS];
        
        Console.WriteLine("Введіть 5 чисел для масиву A:");
        for (int i = 0; i < A_SIZE; i++)
        {
            Console.Write($"A[{i}] = ");
            while (!double.TryParse(Console.ReadLine(), out A[i]))
            {
                Console.Write("Помилка введення. Спробуйте ще раз: ");
            }
        }
        
        Random random = new Random();
        for (int i = 0; i < B_ROWS; i++)
        {
            for (int j = 0; j < B_COLS; j++)
            {
                B[i, j] = random.NextDouble() * 100 - 50; 
            }
        }
        
        Console.WriteLine("\nМасив A:");
        for (int i = 0; i < A_SIZE; i++)
        {
            Console.Write($"{A[i]:F2} ");
        }
        
        Console.WriteLine("\n\nМасив B:");
        for (int i = 0; i < B_ROWS; i++)
        {
            for (int j = 0; j < B_COLS; j++)
            {
                Console.Write($"{B[i, j]:F2}\t");
            }
            Console.WriteLine();
        }
        
        double maxElement = A[0];
        double minElement = A[0];
        double sum = 0;
        double product = 1;
        double sumEvenA = 0; 
        double sumOddColsB = 0; 
        
        for (int i = 0; i < A_SIZE; i++)
        {
            if (A[i] > maxElement) maxElement = A[i];
            if (A[i] < minElement) minElement = A[i];
            sum += A[i];
            product *= A[i];
            
            if (i % 2 == 0) 
            {
                sumEvenA += A[i];
            }
        }
        
        for (int i = 0; i < B_ROWS; i++)
        {
            for (int j = 0; j < B_COLS; j++)
            {
                if (B[i, j] > maxElement) maxElement = B[i, j];
                if (B[i, j] < minElement) minElement = B[i, j];
                sum += B[i, j];
                product *= B[i, j];
                
                if (j % 2 != 0) 
                {
                    sumOddColsB += B[i, j];
                }
            }
        }
        
        Console.WriteLine("\nРезультати обчислень:");
        Console.WriteLine($"Максимальний елемент: {maxElement:F2}");
        Console.WriteLine($"Мінімальний елемент: {minElement:F2}");
        Console.WriteLine($"Загальна сума всіх елементів: {sum:F2}");
        Console.WriteLine($"Загальний добуток всіх елементів: {product:E}");
        Console.WriteLine($"Сума парних елементів масиву A: {sumEvenA:F2}");
        Console.WriteLine($"Сума непарних стовпців масиву B: {sumOddColsB:F2}");
    }

    // Завдання 2
    static void Task2()
    {
        Console.WriteLine("=== Завдання 2: Сума елементів між мінімальним і максимальним ===\n");
        
        const int SIZE = 5;
        int[,] matrix = new int[SIZE, SIZE];
        
        Random random = new Random();
        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                matrix[i, j] = random.Next(-100, 101);
            }
        }
        
        Console.WriteLine("Згенерована матриця:");
        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                Console.Write($"{matrix[i, j],5}");
            }
            Console.WriteLine();
        }
        
        int min = matrix[0, 0];
        int max = matrix[0, 0];
        int minI = 0, minJ = 0;
        int maxI = 0, maxJ = 0;
        
        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    minI = i;
                    minJ = j;
                }
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    maxI = i;
                    maxJ = j;
                }
            }
        }
        
        Console.WriteLine($"\nМінімальний елемент: {min} на позиції [{minI},{minJ}]");
        Console.WriteLine($"Максимальний елемент: {max} на позиції [{maxI},{maxJ}]");
        
        int[] flatMatrix = new int[SIZE * SIZE];
        int index = 0;
        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                flatMatrix[index++] = matrix[i, j];
            }
        }
        
        int flatMinIndex = minI * SIZE + minJ;
        int flatMaxIndex = maxI * SIZE + maxJ;
        
        if (flatMinIndex > flatMaxIndex)
        {
            int temp = flatMinIndex;
            flatMinIndex = flatMaxIndex;
            flatMaxIndex = temp;
        }
        
        int sum = 0;
        for (int i = flatMinIndex + 1; i < flatMaxIndex; i++)
        {
            sum += flatMatrix[i];
        }
        
        Console.WriteLine($"\nСума елементів між мінімальним та максимальним: {sum}");
    }

    // Завдання 3
    static void Task3()
    {
        Console.WriteLine("=== Завдання 3: Шифр Цезаря ===\n");
        
        Console.Write("Введіть рядок для шифрування: ");
        string text = Console.ReadLine();
        
        Console.Write("Введіть зсув (ціле число): ");
        if (!int.TryParse(Console.ReadLine(), out int shift))
        {
            Console.WriteLine("Помилка введення зсуву. Використовуємо зсув = 3");
            shift = 3;
        }
        
        string encrypted = CaesarCipher(text, shift);
        Console.WriteLine($"Зашифрований текст: {encrypted}");
        
        string decrypted = CaesarCipher(encrypted, -shift);
        Console.WriteLine($"Розшифрований текст: {decrypted}");
    }
    static string CaesarCipher(string text, int shift)
    {
        if (string.IsNullOrEmpty(text))
            return text;
            
        shift = shift % 26;
        
        StringBuilder result = new StringBuilder();
        
        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                char offset = char.IsUpper(c) ? 'A' : 'a';
                result.Append((char)((((c - offset) + shift + 26) % 26) + offset));
            }
            else
            {
                result.Append(c);
            }
        }
        
        return result.ToString();
    }

    // Завдання 4
    static void Task4()
    {
        Console.WriteLine("=== Завдання 4: Операції над матрицями ===\n");
        
        Console.WriteLine("Виберіть операцію:");
        Console.WriteLine("1. Множення матриці на число");
        Console.WriteLine("2. Додавання матриць");
        Console.WriteLine("3. Добуток матриць");
        Console.Write("Ваш вибір (1-3): ");
        
        if (!int.TryParse(Console.ReadLine(), out int operation) || operation < 1 || operation > 3)
        {
            Console.WriteLine("Невірний вибір операції.");
            return;
        }
        
        if (operation == 1)
        {
            Console.WriteLine("\nМноження матриці на число");
            
            // Введення розмірів матриці
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
            double[,] matrix = CreateMatrix(rows, cols);
            
            Console.Write("Введіть число для множення: ");
            if (!double.TryParse(Console.ReadLine(), out double number))
            {
                Console.WriteLine("Невірне число.");
                return;
            }
            
            double[,] result = MultiplyMatrixByNumber(matrix, number);
            
            Console.WriteLine("\nРезультат множення матриці на число:");
            PrintMatrix(result);
        }
        else if (operation == 2)
        {
            Console.WriteLine("\nДодавання матриць");
            
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
            Console.WriteLine("\nПерша матриця:");
            double[,] matrix1 = CreateMatrix(rows, cols);
            
            Console.WriteLine("\nДруга матриця:");
            double[,] matrix2 = CreateMatrix(rows, cols);
            
            double[,] result = AddMatrices(matrix1, matrix2);
            
            Console.WriteLine("\nРезультат додавання матриць:");
            PrintMatrix(result);
        }
        else
        {
            Console.WriteLine("\nДобуток матриць");
            
            Console.Write("Введіть кількість рядків першої матриці: ");
            if (!int.TryParse(Console.ReadLine(), out int rows1) || rows1 <= 0)
            {
                Console.WriteLine("Невірна кількість рядків.");
                return;
            }
            
            Console.Write("Введіть кількість стовпців першої матриці: ");
            if (!int.TryParse(Console.ReadLine(), out int cols1) || cols1 <= 0)
            {
                Console.WriteLine("Невірна кількість стовпців.");
                return;
            }
            
            Console.WriteLine("\nПерша матриця:");
            double[,] matrix1 = CreateMatrix(rows1, cols1);
            
            Console.Write("\nВведіть кількість рядків другої матриці (має бути рівним кількості стовпців першої, тобто " + cols1 + "): ");
            int rows2 = cols1;
            Console.WriteLine(rows2);
            
            Console.Write("Введіть кількість стовпців другої матриці: ");
            if (!int.TryParse(Console.ReadLine(), out int cols2) || cols2 <= 0)
            {
                Console.WriteLine("Невірна кількість стовпців.");
                return;
            }
            Console.WriteLine("\nДруга матриця:");
            double[,] matrix2 = CreateMatrix(rows2, cols2);
            double[,] result = MultiplyMatrices(matrix1, matrix2);
            Console.WriteLine("\nРезультат добутку матриць:");
            PrintMatrix(result);
        }
    }
    
    static double[,] CreateMatrix(int rows, int cols)
    {
        double[,] matrix = new double[rows, cols];
        
        Console.WriteLine("Виберіть спосіб заповнення матриці:");
        Console.WriteLine("1. Вручну");
        Console.WriteLine("2. Випадковими числами");
        Console.Write("Ваш вибір (1-2): ");
        
        if (!int.TryParse(Console.ReadLine(), out int fillMethod) || (fillMethod != 1 && fillMethod != 2))
        {
            Console.WriteLine("Невірний метод заповнення. Використовуємо випадкові числа.");
            fillMethod = 2;
        }
        
        if (fillMethod == 1)
        {
            Console.WriteLine("Введіть елементи матриці:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Елемент [{i},{j}]: ");
                    while (!double.TryParse(Console.ReadLine(), out matrix[i, j]))
                    {
                        Console.Write("Помилка введення. Спробуйте ще раз: ");
                    }
                }
            }
        }
        else
        {
            Random random = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = Math.Round(random.NextDouble() * 20 - 10, 2);
                }
            }
            
            Console.WriteLine("Згенерована матриця:");
            PrintMatrix(matrix);
        }
        
        return matrix;
    }
    
    static void PrintMatrix(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{matrix[i, j],8:F2}");
            }
            Console.WriteLine();
        }
    }
    
    static double[,] MultiplyMatrixByNumber(double[,] matrix, double number)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        double[,] result = new double[rows, cols];
        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix[i, j] * number;
            }
        }
        
        return result;
    }
    
    static double[,] AddMatrices(double[,] matrix1, double[,] matrix2)
    {
        int rows = matrix1.GetLength(0);
        int cols = matrix1.GetLength(1);
        double[,] result = new double[rows, cols];
        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }
        
        return result;
    }
    
    static double[,] MultiplyMatrices(double[,] matrix1, double[,] matrix2)
    {
        int rows1 = matrix1.GetLength(0);
        int cols1 = matrix1.GetLength(1);
        int cols2 = matrix2.GetLength(1);
        
        double[,] result = new double[rows1, cols2];
        
        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < cols2; j++)
            {
                double sum = 0;
                for (int k = 0; k < cols1; k++)
                {
                    sum += matrix1[i, k] * matrix2[k, j];
                }
                result[i, j] = sum;
            }
        }
        return result;
    }

    // Завдання 5
    static void Task5()
    {
        Console.WriteLine("=== Завдання 5: Обчислення арифметичного виразу ===\n");
        
        Console.Write("Введіть арифметичний вираз (використовуйте тільки + та -): ");
        string expression = Console.ReadLine().Trim();
        
        Regex regex = new Regex(@"[^\d\+\-\s]");
        if (regex.IsMatch(expression))
        {
            Console.WriteLine("Помилка: вираз містить недопустимі символи. Допускаються лише цифри, + та -.");
            return;
        }
        try
        {
            double result = CalculateExpression(expression);
            Console.WriteLine($"Результат: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при обчисленні: {ex.Message}");
        }
    }
    
    static double CalculateExpression(string expression)
    {
        expression = expression.Replace(" ", "");
        
        if (expression.StartsWith("+"))
        {
            expression = expression.Substring(1);
        }
        
        string[] parts = expression.Split(new char[] { '+', '-' }, StringSplitOptions.RemoveEmptyEntries);
        bool startsWithMinus = expression.StartsWith("-");
        double result = startsWithMinus ? -double.Parse(parts[0]) : double.Parse(parts[0]);
        
        int partIndex = 1;
        for (int i = startsWithMinus ? 1 : 0; i < expression.Length; i++)
        {
            if (expression[i] == '+' || expression[i] == '-')
            {
                if (partIndex < parts.Length)
                {
                    double nextNumber = double.Parse(parts[partIndex]);
                    
                    if (expression[i] == '+')
                    {
                        result += nextNumber;
                    }
                    else // -
                    {
                        result -= nextNumber;
                    }
                    
                    partIndex++;
                }
            }
        }
        
        return result;
    }

    // Завдання 6
    static void Task6()
    {
        Console.WriteLine("=== Завдання 6: Зміна регістру першої літери в реченнях ===\n");
        
        Console.WriteLine("Введіть текст (можна декілька речень):");
        string text = Console.ReadLine();
        
        if (string.IsNullOrEmpty(text))
        {
            Console.WriteLine("Текст не може бути порожнім.");
            return;
        }
        
        string capitalizedText = CapitalizeFirstLetterOfSentences(text);
        Console.WriteLine("\nРезультат:");
        Console.WriteLine(capitalizedText);
    }
    
    static string CapitalizeFirstLetterOfSentences(string text)
    {
        string[] sentences = Regex.Split(text, @"(?<=[.!?])\s+");
        
        StringBuilder result = new StringBuilder();
        
        for (int i = 0; i < sentences.Length; i++)
        {
            string sentence = sentences[i];
            
            if (!string.IsNullOrEmpty(sentence))
            {
                int firstLetterIndex = -1;
                
                for (int j = 0; j < sentence.Length; j++)
                {
                    if (char.IsLetter(sentence[j]))
                    {
                        firstLetterIndex = j;
                        break;
                    }
                }
                if (firstLetterIndex >= 0)
                {
                    sentence = sentence.Substring(0, firstLetterIndex) + 
                               char.ToUpper(sentence[firstLetterIndex]) + 
                               sentence.Substring(firstLetterIndex + 1);
                }
            }
            result.Append(sentence);
            
            if (i < sentences.Length - 1)
            {
                result.Append(" ");
            }
        }
        
        return result.ToString();
    }

    // Завдання 7
    static void Task7()
    {
        Console.WriteLine("=== Завдання 7: Перевірка тексту на неприпустимі слова ===\n");
        
        Console.WriteLine("Введіть текст:");
        string text = Console.ReadLine();
        
        if (string.IsNullOrEmpty(text))
        {
            Console.WriteLine("Текст не може бути порожнім.");
            return;
        }
        
        Console.Write("Введіть неприпустиме слово: ");
        string forbiddenWord = Console.ReadLine().Trim().ToLower();
        
        if (string.IsNullOrEmpty(forbiddenWord))
        {
            Console.WriteLine("Неприпустиме слово не може бути порожнім.");
            return;
        }
        
        int replacementCount = 0;
        string censoredText = CensorText(text, forbiddenWord, ref replacementCount);
        
        Console.WriteLine("\nРезультат:");
        Console.WriteLine(censoredText);
        Console.WriteLine($"\nСтатистика: {replacementCount} заміни слова {forbiddenWord}");
    }
    
    static string CensorText(string text, string forbiddenWord, ref int replacementCount)
    {
        string replacement = new string('*', forbiddenWord.Length);
        string pattern = $"\\b{Regex.Escape(forbiddenWord)}\\b";
        string originalText = text;
        string censoredText = Regex.Replace(text, pattern, replacement, RegexOptions.IgnoreCase);
        replacementCount = Regex.Matches(text, pattern, RegexOptions.IgnoreCase).Count;
        
        return censoredText;
    }
}