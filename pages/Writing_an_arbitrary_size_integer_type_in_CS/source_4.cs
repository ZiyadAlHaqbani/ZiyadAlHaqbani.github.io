
// recursion helper function
public void decrement()
{
    _decrement(0);
}

private void _decrement(int index)
{
    numbers[index]--;
}

private void expand()
{
    var new_numbers = new int[numbers.Length + 1];

    for (int i = 0; i < numbers.Length; i++)
    {
        new_numbers[i] = numbers[i];
    }

    this.numbers = new_numbers;
}

...

public static void Main()
{

    LargeNumber number = new LargeNumber(999);
    number.decrement();

    // 998
    System.Console.WriteLine(number);

    number = new LargeNumber(10);
    number.decrement();

    // 1-1
    System.Console.WriteLine(number);
}