using System.Text;

// Wywołania funkcji z zadaniami
Task1();
Task2();
Task3();
Task4();
Task5();


void Task1() 
{
    Console.WriteLine("--- Zadanie 1 ---");
    string name = "CodeIsMySpotter";
    int age = 21;
    double height = 1.78;
    char grade = 's';
    bool isCool = true;

    string interpolatedString = $"My name is {name}. I am {age} yo. My height is {height} and best grade is {grade}. Am i cool? {isCool}";
    Console.WriteLine(interpolatedString);



}

void Task2() 
{
    Console.WriteLine("\n--- Zadanie 2 ---");

    string[] games = new string[3];
    games[0] = "WoT";
    games[1] = "WoWs";
    games[2] = "LoL";

    int length = games.Length;
    Console.WriteLine($"The length of the array is {length}");


}

void Task3() 
{
    Console.WriteLine("\n--- Zadanie 3 ---");
    double number1 = 0.67;
    double number2 = number1;
    number1 = 0.42;

    Console.WriteLine($"{number1 == number2}");

    string[] array1 = { "1", "2" };
    var array2 = array1;
    array2[0] = "0";

    Console.WriteLine($"{array1[0] == array2[0]}");

}

void Task4() 
{
    Console.WriteLine("\n--- Zadanie 4 ---");

    char[] chars = {'C', '#', '!'};
    string reversedChars = $"{chars[2]}{chars[1]}{chars[0]}";

    Console.WriteLine(reversedChars);
}

void Task5() 
{
    Console.WriteLine("\n--- Zadanie 5 ---");
    double[] grades = { 3, 3.5, 5.0 };
    double avg = (grades[0] + grades[1] + grades[2]) / grades.Length;

    StringBuilder report = new StringBuilder()
        .AppendLine("Student report")
        .AppendLine($"Grades: {grades[0]}, {grades[1]}, {grades[2]}.")
        .AppendLine($"Avg. Grade: {avg}.");

    Console.WriteLine(report.ToString());


}
