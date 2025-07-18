public static bool operator >(LargeNumber a, LargeNumber b)
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

    if (a.numbers.Length > b.numbers.Length)
        return true;
    else if (a.numbers.Length < b.numbers.Length)
        return false;

    // after all early exists check the values
    var length_remaining = a.numbers.Length - current_a;
    for (int i = 0; i < length_remaining; i++)
    {
        var a_current = a.numbers[a.numbers.Length - 1 - (current_a + i)];
        var b_current = b.numbers[b.numbers.Length - 1 - (current_b + i)];

        if (a_current > b_current)
            return true;
        else if (a_current == b_current)
            continue;
        else if (a_current < b_current)
            return false;
    }

    return false;
}

public static bool operator <(LargeNumber a, LargeNumber b)
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

    if (a.numbers.Length < b.numbers.Length)
        return true;
    else if (a.numbers.Length > b.numbers.Length)
        return false;

    // after all early exists check the values
    var length_remaining = a.numbers.Length - current_a;
    for (int i = 0; i < length_remaining; i++)
    {
        var a_current = a.numbers[a.numbers.Length - 1 - (current_a + i)];
        var b_current = b.numbers[b.numbers.Length - 1 - (current_b + i)];

        if (a_current < b_current)
            return true;
        else if (a_current == b_current)
            continue;
        else if (a_current > b_current)
            return false;
    }

    return false;
}