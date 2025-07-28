public static bool operator !=(LargeNumber a, LargeNumber b)
{
    int current_a = 0;
    int current_b = 0;

    // skip preceding zeros
    if (a.numbers.Length > b.numbers.Length)
    {
        var curr = a.numbers[a.numbers.Length - 1];
        while (curr == 0 && (a.numbers.Length - current_a) > b.numbers.Length)
        {
            current_a++;
            curr = a.numbers[a.numbers.Length - 1 - current_a];
        }
    }
    else if (b.numbers.Length > a.numbers.Length)
    {
        var curr = b.numbers[b.numbers.Length - 1];
        while (curr == 0 && (b.numbers.Length - current_b) > a.numbers.Length)
        {
            current_b++;
            curr = b.numbers[b.numbers.Length - 1 - current_b];
        }
    }

    // early exit
    if ((a.numbers.Length - current_a) != (b.numbers.Length - current_b))
    {
        return false;
    }

    // check for the first different pair
    for (int i = 0; i < a.numbers.Length - current_a; i++)
    {
        if (a.numbers[a.numbers.Length - 1 - i] != b.numbers[b.numbers.Length - 1 - i]) return true;
    }

    return false;
}

public static bool operator ==(LargeNumber a, LargeNumber b)
{
    var result = a != b;
    return result;
}