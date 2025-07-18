
using System.Globalization;

class LargeNumber
{
    public int[] numbers;

    public LargeNumber(int[] numbers)
    {
        this.numbers = numbers;
    }

    // utility to automatically convert int's to LargeNumber's
    public LargeNumber(int number)
    {
        var str = number.ToString();

        this.numbers = new int[str.Length];
        for (int i = 0; i < this.numbers.Length; i++)
        {
            this.numbers[i] = int.Parse(str[i].ToString());
        }
    }

    public override String ToString()
    {
        var temp = "";
        foreach (var num in numbers)
        {
            temp += $"[{num}]";
        }
        return temp;
    }

    // recursion helper function
    public void increment()
    {
        int least_significant_index = numbers.Length - 1;
        _increment(least_significant_index);
    }

    private void _increment(int index)
    {
        // check for bounds
        if (index >= numbers.Length || index < 0)
        {
            return;
        }

        // increment
        numbers[index]++;

        // carry detection.
        if (numbers[index] > 9)
        {
            // the position loops around and sends the carry to the next position.
            numbers[index] = 0;

            // propogate carry
            this._increment(index - 1);
        }
    }
}

public class Program
{
    public static void Main()
    {
        LargeNumber number = new(1239);
        number.increment();

        // [1][2][4][0]
        System.Console.WriteLine(number);

        number = new LargeNumber(999);
        number.increment();

        // [0][0][0]
        System.Console.WriteLine(number);
    }
}
