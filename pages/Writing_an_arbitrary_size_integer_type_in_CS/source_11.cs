public static LargeNumber operator -(LargeNumber a, LargeNumber b)
{
    // early exit, our type doesn't support negatives
    if (a < b)
    {
        return new(0);
    }

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

        int diff = a_current - b_current
        - (carry ? 1 : 0); // take carry into account
        carry = false; // reset carry signal

        // detect carry
        if (diff > 9)
        {
            carry = true;
            diff += 10;
        }

        c.numbers[i] = (byte)diff;
    }

    // move the remaining values
    var larger_number = (a.numbers.Length > b.numbers.Length) ? a : b;
    for (int i = smaller_length; i < larger_length; i++)
    {
        c.numbers[i] = larger_number.numbers[i];
    }

    return c;
}