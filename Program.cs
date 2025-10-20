using System.Text;
//1



Random random = new Random();
int[] numbers = new int[random.Next(1, 101)];
String output;
for (int i = 0; i < numbers.Length; i++)
{
    numbers[i] = random.Next(10, 21);
}
output = string.Join(" ", numbers);
Console.WriteLine($"{output}, Длина = {numbers.Length}");
Console.WriteLine("\n");



//2
int x = random.Next(1,11);
int y = random.Next(1,11);
int[,] lotOfNumbers = new int[x, y]; 
for  (int i = 0; i < x; i++)
{
    for (int j = 0; j < y; j++)
    {
        lotOfNumbers[i, j] = random.Next(1, 101);
    }
}
int FindMax(int[,] array) {
    int max = -1;
    x = lotOfNumbers.GetUpperBound(0) + 1;
    y = lotOfNumbers.GetUpperBound(1) + 1;
    for (int i = 0; i < x; i++)
    {
        for (int j = 0; j < y; j++)
        {
            if (lotOfNumbers[i, j] > max)
            {
                max = lotOfNumbers[i, j];
            }
        }
    }
    return max;
}

void printArray(int[,] array)
{
    StringBuilder output = new StringBuilder();
    x = lotOfNumbers.GetUpperBound(0) + 1;
    y = lotOfNumbers.GetUpperBound(1) + 1;
    for (int i = 0; i < x; i++)
    {
        for (int j = 0; j < y; j++)
        {
            output.Append(array[i, j].ToString());
            output.Append(" ");
        }
        output.Append('\n');
    }
    Console.WriteLine(output);
}
printArray(lotOfNumbers);
Console.WriteLine($"Максимум = {FindMax(lotOfNumbers)}");

//3
 


void playHeadsAndTails()
{
    bool exit = false;
    int answer;
    int wins = 0;
    int loses = 0;
    StringBuilder choice = new StringBuilder();
    while (exit != true)
    {
        Console.WriteLine($"Побед {wins}");
        Console.WriteLine($"Поражений {loses}");
        Console.WriteLine("Выберите сторону: Орел или Решка; чтобы выйти введите exit");
        choice.Append(Console.ReadLine().ToLower());
        answer = random.Next(0,2);
        if (choice.Equals("орел"))
        {
            if (answer == 0)
            {
                Console.WriteLine("Вы победили!");
                wins += 1;
                choice.Remove(0, choice.Length);
            }
            else Console.WriteLine("Вы проиграли"); loses += 1; choice.Remove(0, choice.Length);
        }
        else if(choice.Equals("решка"))
        {
            if (answer == 1)
            {
                Console.WriteLine("Вы победили!");
                wins += 1;
                choice.Remove(0, choice.Length);
            }
            else Console.WriteLine("Вы проиграли"); loses += 1; choice.Remove(0, choice.Length);
        }
        else if (choice.Equals("exit"))
        {
            exit = true;
            choice.Remove(0, choice.Length);
        }
        else
        {
            Console.WriteLine("Ошибка ввода");
            choice.Remove(0, choice.Length);
        }        
    }
}

playHeadsAndTails();

//4


void FindSum()
{
    double sum = 0d;
    bool end = false;
    bool exit = false;
    double inputNumber;
    string line;
    string select;
    StringBuilder answer = new StringBuilder();
    while (exit == false)
    {
        while (end == false)
        {
            Console.WriteLine("Введите число для сложения или '=' для вывода суммы");
            line = Console.ReadLine();
            if (double.TryParse(line, out inputNumber))
            {
                answer.Append(line + " ");
                sum += inputNumber;
                inputNumber = 0d;
            }
            else if (line == "=")
            {
                Console.WriteLine(answer);
                Console.WriteLine(Math.Round(sum, 5));
                answer.Remove(0, answer.Length);
                sum = 0;
                end = true;
            }
        }
        Console.WriteLine("Хотите продолжить? Введите restart, если да или exit для выхода");
        select = Console.ReadLine();
        if (select == "exit")
        {
            exit = true;
        }
        else if (select == "restart")
        {
            end = false;
        }
        else Console.WriteLine("Ошибка ввода");

    }
}

FindSum();
