namespace ObserverPattern
{
    public interface IObserver
    {
        void Update(ISubject subject);
    }

    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }

    public class ConcreteSubject : ISubject
    {
        public int State { get; private set; } = 0;

        private List<IObserver> _observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        public void ChangeState(int state)
        {
            State = state;
            Notify();
        }
    }

    public class ConcreteObserver : IObserver
    {
        private string _name;

        public ConcreteObserver(string name)
        {
            _name = name;
        }

        public void Update(ISubject subject)
        {
            if (subject is ConcreteSubject concreteSubject)
            {
                Console.WriteLine($"Observer {_name}: Reacted to the state change to {concreteSubject.State}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ConcreteSubject subject = new ConcreteSubject();

            ConcreteObserver observer1 = new ConcreteObserver("A");
            ConcreteObserver observer2 = new ConcreteObserver("B");

            subject.Attach(observer1);
            subject.Attach(observer2);

            subject.ChangeState(1);
            subject.ChangeState(2);

            subject.Detach(observer1);

            subject.ChangeState(3);
        }
    }
}
