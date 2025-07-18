
// recursion helper function
public void decrement()
{
    _decrement(0);
}

private void _decrement(int index)
{
    numbers[index]--;
}

...

public static void Main()
{

    LargeNumber number = new LargeNumber(5);
    number.decrement();

    // 4
    System.Console.WriteLine(number);

    number = new LargeNumber(10);
    number.decrement();

    // 1-1
    System.Console.WriteLine(number);
}