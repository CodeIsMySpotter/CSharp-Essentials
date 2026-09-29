// Wywołania funkcji z zadaniami
Task1();
Task2();
Task3();
Task4();
Task5();

void Task1() 
{
    Console.WriteLine("--- Zadanie 1 ---");

    int number = -14;
    bool nonZero = false;

    if (number > 0)
    {
        Console.WriteLine("The number is positive");
        nonZero = true;
    }
    else if (number < 0)
    {
        Console.WriteLine("The number is negative");
        nonZero = true;
    }
    else
    {
        Console.WriteLine("The number is zero");
    }

    if (nonZero)
    {
        var isOdd = number % 2 == 1;
        Console.WriteLine($"Is the number odd? {isOdd}");
    }
    
}

void Task2() 
{
    Console.WriteLine("\n--- Zadanie 2 ---");
    double a = 14.3;
    double b = 3.14;

    char op = '+';

    if (b == 0 && op == '/')
    {
        Console.WriteLine("Can't divide by zero!");
        return;
    }

    double result = op switch 
    {
        '+' => a + b,
        '-' => a - b,
        '/' => a / b,
        _ => a * b,
    };

    Console.WriteLine($"The result: {result}");
}

void Task3() 
{
    Console.WriteLine("\n--- Zadanie 3 ---");
    int[] numbers = { 4, 8, 15, 16, 23, 42 };
    int target = 16;
    int iterator = 0;
    while (iterator < numbers.Length && numbers[iterator] != target)
    {
        iterator++;
    }

    if (iterator < numbers.Length)
    {
    Console.WriteLine($"Number found on the index: {iterator}");
    }
}

void Task4() 
{
    Console.WriteLine("\n--- Zadanie 4 ---");
    int[] mixedNumbers = { -5, 10, -3, 20, 0, 15 };
    int sum = 0;

    foreach (var number in mixedNumbers)
    {
        var cond = number >= 0;
        sum = cond switch
        {
            true => sum + number,
            _ => sum
        };
    }
    Console.WriteLine($"Sum: {sum}");
}

void Task5() 
{
    Console.WriteLine("\n--- Zadanie 5 ---");
    for (int idx = 1; idx <= 100; idx++)
    {
        if (idx % 15 == 0)
        {
            Console.WriteLine("FizzBuzz");
        }
        else if (idx % 3 == 0)
        {
            Console.WriteLine("Fizz");
        }
        else if (idx % 5 == 0)
        {
            Console.WriteLine("Buzz");
        }
        else
        {
            Console.WriteLine(idx);
        }
    }
}
