namespace AdapterPattern
{
    public interface ITarget
    {
        string GetRequest();
    }

    public class Adaptee
    {
        public string GetSpecificRequest()
        {
            return "Specific request.";
        }
    }

    public class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;

        public Adapter(Adaptee adaptee)
        {
            this._adaptee = adaptee;
        }

        public string GetRequest()
        {
            return $"This is '{this._adaptee.GetSpecificRequest()}'";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);

            Console.WriteLine("Adaptee interface is incompatible with the client.");
            Console.WriteLine("But with adapter, the client can call its method.");

            Console.WriteLine(target.GetRequest());
        }
    }
}