using System.Text;
//1



Random random = new Random();
int[] numbers = new int[random.Next(1, 100)];
String output;
for (int i = 0; i < numbers.Length; i++)
{
    numbers[i] = random.Next(10, 20);
}
output = string.Join(" ", numbers);
Console.WriteLine($"{output}, Длина = {numbers.Length}");
Console.WriteLine("\n");



//2
int x = random.Next(1,10);
int y = random.Next(1,10);
int[,] lotOfNumbers = new int[x, y]; 
for  (int i = 0; i < x; i++)
{
    for (int j = 0; j < y; j++)
    {
        lotOfNumbers[i, j] = random.Next(1, 100);
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

