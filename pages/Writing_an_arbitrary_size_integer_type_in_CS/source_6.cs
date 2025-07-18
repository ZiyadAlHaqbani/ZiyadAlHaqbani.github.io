public class Program
{

    static LargeNumber NaiveSum(LargeNumber a, LargeNumber b)
    {
        LargeNumber c = new(a);

        // simulated addition
        for (LargeNumber i = new(0); int.Parse(i.ToString()) < int.Parse(b.ToString()); i.increment())
            c.increment();

        return c;
    }

    public static void Main()
    {

        Stopwatch timer = new();
        timer.Start();
        LargeNumber a = new(123);
        LargeNumber b = new(654);

        // 777
        var c = NaiveSum(a, b);
        timer.Stop();
        var time_a = timer.Elapsed;

        timer.Restart();
        a = new(1000000);
        b = new(1000000);

        // 2,000,000
        c = NaiveSum(a, b);
        timer.Stop();
        var time_b = timer.Elapsed;

        // ~5ms
        System.Console.WriteLine(time_a);

        // ~700ms
        System.Console.WriteLine(time_b);

    }
}