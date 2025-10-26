using System.Text;
//1 завершено



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



//2 завершено
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
void winCheck(int playerChoice, int computerChoice, ref int loses, ref int wins)
{

    if(playerChoice == computerChoice)
    {
        Console.WriteLine("Вы победили!");
        wins++;
    }
    else
    {
        Console.WriteLine("Вы проиграли");
        loses++;
    }
}

void playHeadsAndTails()
{
    bool exit = false;
    int computerChoice;
    int playerChoice;
    int wins = 0;
    int loses = 0;
    StringBuilder input = new StringBuilder();
    while (exit != true)
    {
        Console.WriteLine($"Побед {wins}");
        Console.WriteLine($"Поражений {loses}");
        Console.WriteLine("Выберите сторону: Орел или Решка; чтобы выйти введите exit");
        input.Append(Console.ReadLine().ToLower());
        computerChoice = random.Next(0,2);
        if (input.Equals("орел"))
        {
            playerChoice = 0;
            winCheck(playerChoice, computerChoice, ref loses, ref wins);
        }
        else if(input.Equals("решка"))
        {
            playerChoice = 1;
            winCheck(playerChoice, computerChoice, ref loses, ref wins);
        }
        else if (input.Equals("exit"))
        {
            exit = true;
        }
        else
        {
            Console.WriteLine("Ошибка ввода");
        }
        input.Clear();
    }
}

playHeadsAndTails();

//4
void FindSum()
{
    
    bool isPlaying = true;
    bool exit = false;
    string CommandExit = "exit";
    string CommandRestart = "restart";
    StringBuilder answer = new StringBuilder(); //пофиксить нейминг
    while (exit == false)
    {
        double sum = 0d;
        while (isPlaying == true)
        {
            Console.WriteLine("Введите число для сложения или '=' для вывода суммы");
            string userInput;
            userInput = Console.ReadLine();
            if (double.TryParse(userInput, out double inputNumber))
            {
                answer.Append(userInput + " ");
                sum += inputNumber;
                inputNumber = 0d;
            }
            else if (userInput == "=")
            {
                Console.WriteLine(answer);
                Console.WriteLine(Math.Round(sum, 5));
                answer.Remove(0, answer.Length);
                isPlaying = false;
            }
            else
            {
                Console.WriteLine("Ошибка ввода");
            }
        }
        Console.WriteLine("Хотите продолжить? Введите restart, если да или exit для выхода");
        string commandInput;
        commandInput = Console.ReadLine().ToLower();
        if (commandInput == CommandExit)
        {
            exit = true;
        }
        else if (commandInput == CommandRestart)
        {
            isPlaying = true;
        }
        else
        {
            Console.WriteLine("Ошибка ввода");
        }
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
string[,] initializeField(int xSize, int ySize)
{ 
    string[,] field = new string[xSize, ySize];
    for(int i = 0; i < xSize; i++)
    {
        for (int j = 0; j < ySize; j++)
        {
            field[i, j] = "o";   
        }
    }
    return field;
}

int xSize = 3;
int ySize = 3;
Random xCreate = new Random();
Random yCreate = new Random();
string[,] field = initializeField(xSize, ySize);
(int, int)[] alreadyUsed = new (int, int)[6];
(int, int) cellPosition;
int playerScore = 0;
int usedCellsCounter = 0;
void GetNumbers(int xSize,int ySize, ref int xPlayer, ref int yPlayer, ref (int , int)[] alreadyUsed, out (int,int) cellPosition)
{
    bool allAlright = false;
    while (allAlright != true)
    {
        Console.WriteLine("Введите номер строки и номер столбца");
        Console.WriteLine("Номер строки начиная с 1");
        if (int.TryParse(Console.ReadLine(), out xPlayer) && (xPlayer >= 1 && xPlayer <= xSize))
        {
            Console.WriteLine("Номер столбца начиная с 1");
        }
        else
        {
            Console.WriteLine("Ошибка ввода");
            continue;
        }
        if (int.TryParse(Console.ReadLine(), out yPlayer) && (yPlayer >= 1 && yPlayer <= ySize))
        {
            cellPosition = (xPlayer, yPlayer);
            if (!alreadyUsed.Contains(cellPosition))
            {
                allAlright = true;
            }
            else
            {
                Console.WriteLine("Ошибка, клетка уже была введена");
                continue;
            }
        }
        else
        {
            Console.WriteLine("Ошибка ввода");
            continue;
        }
        
    }
    cellPosition = (xPlayer, yPlayer);
}
int xComp = xCreate.Next(1, xSize + 1);
int yComp = yCreate.Next(1, ySize + 1);
for (int i = 0; i < 6; i++)
{
    int xPlayer = 0;
    int yPlayer = 0;
    
    GetNumbers(xSize, ySize ,ref xPlayer, ref yPlayer, ref alreadyUsed, out cellPosition);
    if (cellPosition.Item1 == xComp && cellPosition.Item2 == yComp)
    {
        xComp = xCreate.Next(1, xSize + 1);
        yComp = yCreate.Next(1, ySize + 1);
        field[xComp - 1, yComp - 1] = "x";
        alreadyUsed[usedCellsCounter] = cellPosition;
        usedCellsCounter++;
        playerScore++;
        Console.WriteLine("Верно!");
        Console.WriteLine($"Осталось еще {3-playerScore}");
    }
    else
    {
        Console.WriteLine("Неверно, попробуй еще");
        Console.WriteLine($"Осталось попыток {5 - i}");
    }
    if (playerScore == 3)
    {
        Console.WriteLine("Вы победили");
        break;
    }
}
if (playerScore != 3)
{
    Console.WriteLine("Вы проиграли");
}