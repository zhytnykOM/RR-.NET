public class Multiton
{
    private static readonly Dictionary<string, Multiton> instances = new Dictionary<string, Multiton>();
    private static readonly object lockObject = new object();

    public string Name { get; private set; }

    private Multiton(string name)
    {
        Name = name;
    }

    public static Multiton GetInstance(string key)
    {
        lock (lockObject)
        {
            if (!instances.ContainsKey(key))
            {
                instances[key] = new Multiton(key);
            }
            return instances[key];
        }
    }

    public static void ShowAllInstances()
    {
        foreach (var instance in instances)
        {
            Console.WriteLine($"Key: {instance.Key}, Instance Name: {instance.Value.Name}");
        }
    }
}

class Program
{
    static void Main()
    {
        var instance1 = Multiton.GetInstance("A");
        var instance2 = Multiton.GetInstance("B");
        var instance3 = Multiton.GetInstance("A");

        Console.WriteLine(instance1.Name);
        Console.WriteLine(instance2.Name);
        Console.WriteLine(instance3.Name);

        Multiton.ShowAllInstances();
    }
}