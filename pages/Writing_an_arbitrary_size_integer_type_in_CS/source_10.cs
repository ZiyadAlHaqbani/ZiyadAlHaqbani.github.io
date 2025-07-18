public static LargeNumber operator +(LargeNumber a, LargeNumber b)
{
    int larger_length = (a.numbers.Length > b.numbers.Length) ? a.numbers.Length : b.numbers.Length;
    int smaller_length = (a.numbers.Length < b.numbers.Length) ? a.numbers.Length : b.numbers.Length;
    var c_arr = new byte[larger_length];
    var c = new LargeNumber(c_arr);

    int a_current;
    int b_current;
    bool carry = false;

    for (int i = 0; i < smaller_length; i++)
    {
        a_current = a.numbers[i];
        b_current = b.numbers[i];

        int sum = a_current + b_current
        + (carry ? 1 : 0); // take carry into account
        carry = false; // reset carry signal

        // detect carry
        if (sum > 9)
        {
            carry = true;
            sum -= 10;
        }

        c.numbers[i] = (byte)sum;
    }

    // move the remaining values
    var larger_number = (a.numbers.Length > b.numbers.Length) ? a : b;
    for (int i = smaller_length; i < larger_length; i++)
    {
        c.numbers[i] = larger_number.numbers[i];
    }

    // handling trailing carry
    if (carry)
    {
        c.expand();
        c.numbers[c.numbers.Length - 1]++;
    }

    return c;
}