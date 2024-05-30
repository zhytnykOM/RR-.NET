public sealed class Singleton
{
    private static Singleton _instance = null;
    private static readonly object _lock = new object();

    private Singleton()
    {
    }

    public static Singleton Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                }
            }
            return _instance;
        }
    }

    public void DoSomething()
    {
        Console.WriteLine("Singleton instance is doing something!");
    }
}

class Program
{
    static void Main()
    {
        Singleton singleton1 = Singleton.Instance;
        Singleton singleton2 = Singleton.Instance;

        if (singleton1 == singleton2)
        {
            Console.WriteLine("Both instances are the same.");
        }

        singleton1.DoSomething();
    }
}