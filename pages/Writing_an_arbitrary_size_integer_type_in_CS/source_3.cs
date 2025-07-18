
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
            this.numbers[numbers.Length - 1 - i] = int.Parse(str[i].ToString());
        }
    }

    public override String ToString()
    {
        var temp = "";
        foreach (var num in numbers)
        {
            temp = $"{num}{temp}";
        }
        return temp;
    }

    // recursion helper function
    public void increment()
    {
        int least_significant_index = 0;
        _increment(least_significant_index);
    }

    private void _increment(int index)
    {
        // check for overflow
        if (index >= numbers.Length)
        {
            expand();
        }

        // increment
        numbers[index]++;

        // carry detection.
        if (numbers[index] > 9)
        {
            // the position loops around and sends the carry to the next position.
            numbers[index] = 0;

            // propogate carry
            this._increment(index + 1);
        }
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
}

public class Program
{
    public static void Main()
    {

        LargeNumber number = new LargeNumber(999);
        number.increment();

        // 1000
        System.Console.WriteLine(number);

        // demo of the object
        for (LargeNumber i = new(0); int.Parse(i.ToString()) < 10; i.increment())
            System.Console.WriteLine(i);
    }
}
