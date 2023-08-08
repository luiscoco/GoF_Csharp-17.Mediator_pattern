# GoF_Csharp-17.Mediator_pattern

The Mediator pattern is a behavioral design pattern that promotes loose coupling between objects by centralizing communication between them through a mediator object. This pattern is often used to reduce direct communication between individual components, making the system easier to maintain and extend.

Here's a simple explanation of the Mediator pattern followed by a C# code sample:

Mediator: This is an interface that defines the communication contract between various components. It usually has methods for components to send messages to other components through the mediator.

Concrete Mediator: This is a class that implements the Mediator interface. It knows and maintains references to individual components and coordinates their communication.

Colleague Components: These are individual components that interact with each other. They don't communicate directly with each other but instead use the mediator to send and receive messages.

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        ConcreteMediator mediator = new ConcreteMediator();
        ColleagueA colleagueA = new ColleagueA(mediator);
        ColleagueB colleagueB = new ColleagueB(mediator);

        mediator.ColleagueA = colleagueA;
        mediator.ColleagueB = colleagueB;

        colleagueA.SendMessage("Hello from Colleague A!");
        colleagueB.SendMessage("Hi from Colleague B!");
    }
}

// Mediator interface
interface IMediator
{
    void SendMessage(string message, Colleague colleague);
}

// Concrete Mediator
class ConcreteMediator : IMediator
{
    private ColleagueA _colleagueA;
    private ColleagueB _colleagueB;

    public ColleagueA ColleagueA
    {
        set { _colleagueA = value; }
    }

    public ColleagueB ColleagueB
    {
        set { _colleagueB = value; }
    }

    public void SendMessage(string message, Colleague colleague)
    {
        if (colleague == _colleagueA)
        {
            _colleagueB.ReceiveMessage(message);
        }
        else if (colleague == _colleagueB)
        {
            _colleagueA.ReceiveMessage(message);
        }
    }
}

// Colleague components
abstract class Colleague
{
    protected IMediator Mediator;

    public Colleague(IMediator mediator)
    {
        Mediator = mediator;
    }

    public abstract void SendMessage(string message);
    public abstract void ReceiveMessage(string message);
}

class ColleagueA : Colleague
{
    public ColleagueA(IMediator mediator) : base(mediator) { }

    public override void SendMessage(string message)
    {
        Mediator.SendMessage(message, this);
    }

    public override void ReceiveMessage(string message)
    {
        Console.WriteLine("Colleague A received message: " + message);
    }
}

class ColleagueB : Colleague
{
    public ColleagueB(IMediator mediator) : base(mediator) { }

    public override void SendMessage(string message)
    {
        Mediator.SendMessage(message, this);
    }

    public override void ReceiveMessage(string message)
    {
        Console.WriteLine("Colleague B received message: " + message);
    }
}
```


















