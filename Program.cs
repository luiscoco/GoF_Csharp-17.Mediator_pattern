﻿using System;

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
