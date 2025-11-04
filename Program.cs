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
    string inputErrorMessage = "Ошибка ввода";
    string commandExit = "exit";
    string commandInputHeads = "орел";
    string commandInputTails = "решка";
    StringBuilder userInput = new StringBuilder();
    while (exit != true)
    {
        Console.WriteLine($"Побед {wins}");
        Console.WriteLine($"Поражений {loses}");
        Console.WriteLine($"Выберите сторону: {commandInputHeads} или {commandInputTails}; чтобы выйти введите {commandExit}");
        userInput.Append(Console.ReadLine().ToLower());
        computerChoice = random.Next(0,2);
        if (userInput.Equals(commandInputHeads))
        {
            playerChoice = 0;
            winCheck(playerChoice, computerChoice, ref loses, ref wins);
        }
        else if(userInput.Equals(commandInputTails))
        {
            playerChoice = 1;
            winCheck(playerChoice, computerChoice, ref loses, ref wins);
        }
        else if (userInput.Equals(commandExit))
        {
            exit = true;
        }
        else
        {
            Console.WriteLine(inputErrorMessage);
        }
        userInput.Clear();
    }
}

playHeadsAndTails();

//4
void FindSum()
{



    string commandGetResult = "=";
    string commandExit = "exit";
    string commandRestart = "restart";
    string errorInputMessage = "Ошибка ввода";
    StringBuilder allInputedNumbersOutput = new StringBuilder(); //пофиксить нейминг
    bool isPlaying = true;
    bool exit = false;
    while (exit == false)
    {
        
        double sum = 0d;
        while (isPlaying == true)
        {
            Console.WriteLine($"Введите число для сложения или {commandGetResult} для вывода суммы");
            string userInput = Console.ReadLine();
            if (double.TryParse(userInput, out double inputNumber))
            {
                allInputedNumbersOutput.Append(userInput + " ");
                sum += inputNumber;
                inputNumber = 0d;
            }
            else if (userInput == commandGetResult)
            {
                Console.WriteLine(allInputedNumbersOutput);
                Console.WriteLine(Math.Round(sum, 5));
                allInputedNumbersOutput.Remove(0, allInputedNumbersOutput.Length);
                isPlaying = false;
            }
            else
            {
                Console.WriteLine(errorInputMessage);
            }
        }
        Console.WriteLine($"Хотите продолжить? Введите {commandRestart}, если да или {commandExit} для выхода");
        
        string commandInput = Console.ReadLine().ToLower();
        if (commandInput == commandExit)
        {
            exit = true;
        }
        else if (commandInput == commandRestart)
        {
            isPlaying = true;
        }
        else
        {
            Console.WriteLine(errorInputMessage);
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


Random xCreate = new Random();
Random yCreate = new Random();
int xFieldSize = 3;
int yFieldSize = 3;
int WinScore = 3;
int tries = 6;
string inputErrorMessage = "Ошибка ввода";

(int, int)[] guessedMapPositions = new (int, int)[6];
int playerScore = 0;
int guessedMapPositionsCount = 0;
(int,int) GetNumbers(int xFieldSize,int yFieldSize)
{
    bool allAlright = false;
    int xPlayerInput = 0;
    int yPlayerInput = 0;
    while (allAlright != true)
    {
        
        Console.WriteLine("Введите номер строки и номер столбца");
        Console.WriteLine("Номер строки начиная с 1");
        if (int.TryParse(Console.ReadLine(), out  xPlayerInput) && (xPlayerInput >= 1 && xPlayerInput <= xFieldSize))
        {
            Console.WriteLine("Номер столбца начиная с 1");
        }
        else
        {
            Console.WriteLine(inputErrorMessage);
            continue;
        }
        if (int.TryParse(Console.ReadLine(), out  yPlayerInput) && (yPlayerInput >= 1 && yPlayerInput <= yFieldSize))
        {
            if (!guessedMapPositions.Contains((xPlayerInput, yPlayerInput)))
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
            Console.WriteLine(inputErrorMessage);
            continue;
        }
    }
    return (xPlayerInput,yPlayerInput);
    
}
(int, int) GetComputerNumbers(int xFieldSize, int yFieldSize)
{
    int xCompInput = 0;
    int yCompInput = 0;
    bool allAlright = false;
    while (allAlright != true)
    {
            xCompInput = xCreate.Next(1, xFieldSize + 1);
            yCompInput = yCreate.Next(1, yFieldSize + 1);
            if (!guessedMapPositions.Contains((xCompInput, yCompInput)))
            {
                allAlright = true;
            }
    }
    return (xCompInput, yCompInput);
}

(int, int) computerPosition = GetComputerNumbers(xFieldSize, yFieldSize);
for (int i = 0; i < tries; i++)
{
    (int, int) playerPosition = GetNumbers(xFieldSize, yFieldSize);
    if (playerPosition == computerPosition)
    {
        guessedMapPositions[guessedMapPositionsCount] = computerPosition;
        guessedMapPositionsCount++;
        playerScore++;
        computerPosition = GetComputerNumbers(xFieldSize, yFieldSize);
        Console.WriteLine("Верно!");
        Console.WriteLine($"Осталось еще {WinScore-playerScore}");
    }
    else
    {
        Console.WriteLine("Неверно, попробуй еще");
        Console.WriteLine($"Осталось попыток {tries - (i+1)}");
    }
    if (playerScore == WinScore)
    {
        Console.WriteLine("Вы победили");
        break;
    }
}
if (playerScore != WinScore)
{
    Console.WriteLine("Вы проиграли");
}

void initializeField(int xSize, int ySize, (int,int)[] guessedMapPositions)
{
    char[,] field = new char[xSize, ySize];
    for (int i = 0; i < xSize; i++)
    {
        for (int j = 0; j < ySize; j++)
        {
            if (guessedMapPositions.Contains((i+1, j+1)))
            {
                field[i, j] = 'x';
            }
            else
            {
                field[i, j] = 'o';
            }
            Console.Write(field[i,j]);
        }
        Console.WriteLine();
    }
    
}

initializeField(xFieldSize, yFieldSize, guessedMapPositions);