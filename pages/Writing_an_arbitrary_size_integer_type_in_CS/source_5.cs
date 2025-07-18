// recursion helper function
public void decrement()
{
    _decrement(0);
}

private void _decrement(int index)
{
    // checking bounds
    if (index >= numbers.Length)
    {
        return;
    }

    numbers[index]--;

    // check for wraparound
    if (numbers[index] < 0)
    {
        numbers[index] = 9;
        _decrement(index + 1);
    }


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

    // 09
    System.Console.WriteLine(number);

    // demo for decrementing value
    for (var num = new LargeNumber(435); int.Parse(num.ToString()) > 0; num.decrement())
        /*Do something*/
        ;
}