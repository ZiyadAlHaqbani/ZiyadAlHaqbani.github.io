class LargeNumber
{
    public byte[] numbers;

    // copy constructor
    public LargeNumber(LargeNumber number)
    {
        this.numbers = (byte[])number.numbers.Clone();
    }

    public LargeNumber(byte[] numbers)
    {
        this.numbers = numbers;
    }

    // utility to automatically convert int's to LargeNumber's
    public LargeNumber(ulong number)
    {
        var str = number.ToString();

        this.numbers = new byte[str.Length];
        for (int i = 0; i < this.numbers.Length; i++)
        {
            this.numbers[numbers.Length - 1 - i] = byte.Parse(str[i].ToString());
        }
    }

    public override String ToString()
    {

        var current_pointer = 0;
        var curr = this.numbers[this.numbers.Length - 1];
        while (curr == 0)
        {
            current_pointer++;
            curr = this.numbers[this.numbers.Length - 1 - current_pointer];
        }

        var temp = "";
        for (int i = current_pointer; i < this.numbers.Length; i++)
        {
            temp = $"{this.numbers[this.numbers.Length - 1 - i]}{temp}";
        }
        return temp;
    }

    public static bool operator >(LargeNumber a, LargeNumber b)
    {
        TracyWrapper.Profiler.PushProfileZone("operator >");

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

        TracyWrapper.Profiler.PopProfileZone();
        return false;
    }

    public static bool operator <(LargeNumber a, LargeNumber b)
    {
        TracyWrapper.Profiler.PushProfileZone("operator <");
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

        TracyWrapper.Profiler.PopProfileZone();
        return false;
    }

    public static bool operator !=(LargeNumber a, LargeNumber b)
    {
        TracyWrapper.Profiler.PushProfileZone("operator !=");
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

        TracyWrapper.Profiler.PopProfileZone();
        return false;
    }

    public static bool operator ==(LargeNumber a, LargeNumber b)
    {
        TracyWrapper.Profiler.PushProfileZone("operator ==");
        var result = a != b;
        TracyWrapper.Profiler.PopProfileZone();
        return result;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || obj is not LargeNumber) return false;
        return this == (LargeNumber)(obj);
    }

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

    public static LargeNumber operator -(LargeNumber a, LargeNumber b)
    {
        TracyWrapper.Profiler.PushProfileZone("operator -");

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

        TracyWrapper.Profiler.PopProfileZone();
        return c;
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

    private void expand()
    {
        var new_numbers = new byte[numbers.Length + 1];

        for (int i = 0; i < numbers.Length; i++)
        {
            new_numbers[i] = numbers[i];
        }

        this.numbers = new_numbers;
    }
}
