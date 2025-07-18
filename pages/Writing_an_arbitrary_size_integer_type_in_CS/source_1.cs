
void print_number(int[] numbers)
{
    var temp = "";
    foreach (var num in numbers)
    {
        temp += $"[{num}]";
    }
    System.Console.WriteLine(temp);
}

void increment(int[] numbers)
{
    int least_significant_index = numbers.Length - 1;
    numbers[least_significant_index]++;
}

int[] numbers =
[
    1   // most significant position
    ,2
    ,3
    ,9  // least significant position
];

increment(numbers);

// prints: [1][2][3][10]
print_number(numbers);