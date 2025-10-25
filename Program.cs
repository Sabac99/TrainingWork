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
            output.Append(array[i, j]);
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
    StringBuilder answer = new StringBuilder(); //пофиксить нейминг
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



//5
//## 5. Игра 3x3
//-Есть массив 3×3 из символов `"o"`.
//- Программа случайно загадывает элемент.
//- Пользователь вводит **номер строки и столбца** (нумерация с 1).
//- Если угадал — заменить `"o"` на `"x"`.
//- Победа при 3 угаданных элементах (всего 6 попыток).
//- Не выбирать уже отгаданные элементы.
//- Проверять корректность ввода номеров.
string[,] initializeField()
{ 
    string[,] field = new string[3, 3];
    for(int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            field[i, j] = "o";   
        }
    }
    return field;
}

string[,] field = initializeField();
string[] alreadyUsed = new string[6];
Random xCreate = new Random(13);
Random yCreate = new Random(8);
int playerScore = 0;
int xPos = xCreate.Next(1, 4);
int yPos = yCreate.Next(1, 4);
for (int i = 0; i < 6; i++)
{
    int xCurr;
    int yCurr;

    if (playerScore == 3)
    {
        Console.WriteLine("Вы победили");
        break;
    }
    Console.WriteLine("Введите номер строки и номер столбца");
    Console.WriteLine("Номер строки начиная с 1");
    if (int.TryParse(Console.ReadLine(), out xCurr) && xCurr >= 1 && xCurr <= 3) Console.WriteLine("Номер столбца начиная с 1");
    else
    {
        Console.WriteLine("Ошибка ввода");
        i--;
        continue;
    }
    if (int.TryParse(Console.ReadLine(), out yCurr) && yCurr >= 1 && yCurr <= 3);
    else
    {
        Console.WriteLine("Ошибка ввода");
        i--;
        continue;
    }

    if ((xCurr == xPos) && (yCurr == yPos) && !alreadyUsed.Contains(xCurr + " " + yCurr))
    {
        alreadyUsed[i] = (xCurr + " " + yCurr);
        field[xCurr - 1, yCurr - 1] = "x";
        playerScore += 1;
        Console.WriteLine("Верно");
        Console.WriteLine($"Счет = {playerScore}");
        do
        {
            xPos = xCreate.Next(1, 4);
            yPos = yCreate.Next(1, 4);
        }
        while (!alreadyUsed.Contains(xPos + " " + yPos));
        {
            xPos = xCreate.Next(1, 4);
            yPos = yCreate.Next(1, 4);
        }
    }
    else if(alreadyUsed.Contains(xCurr + " " + yCurr))
    {
        Console.WriteLine("Ошибка, ячейка уже была использована");
        i--;
        continue;
    }
    else
    {
        Console.WriteLine("Неверно");
        Console.WriteLine($"Осталось Попыток = {5-i}");
    }
}
if (count != 3)
{
    Console.WriteLine("Вы проиграли");
}