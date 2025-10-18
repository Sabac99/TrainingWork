Random random = new Random();
int[] numbers = new int[random.Next(1, 100)];
String output;
for (int i = 0; i < numbers.Length; i++)
{
    numbers[i] = random.Next(10, 20);
}
output = string.Join(" ", numbers);
Console.WriteLine($"{output}, Длина = {numbers.Length}");
