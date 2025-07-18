...
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
...