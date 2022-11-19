using Shouldly;
using Xunit.Abstractions;

namespace CSharpInDepthStudy.Chapter3;

public class AnonymousTypeTests
{
    private readonly ITestOutputHelper output;

    public AnonymousTypeTests(ITestOutputHelper output)
    {
        this.output = output;
    }
    
    [Fact]
    public void AnonymousType_WhenPropertiesAreSame_ShouldEqual()
    {
        var a = new { x = 10, y = 20 };
        var b = new { x = 10, y = 20 };
        
        a.ShouldBe(b);
    }

    [Fact]
    public void Poco_WhenPropertiesAreSame_TheyAreNotSame()
    {
        // Are objects equal?
        var a = new Location { X = 10, Y = 20 };
        var b = new Location { X = 10, Y = 20 };
        
        a.ShouldNotBe(b);
        //(a == b).ShouldBeTrue();
    }

    [Fact]
    public void TheTypeIsGeneric()
    {
        var a = new { age = "23", male = "1" };
        var b = new { age = 23, male = 1 };
        
        // a.ShouldBe(b);

        // a = b;
    }

    [Fact]
    public void AssignAnonymousType()
    {
        var a = new { age = 23, male = true };
        var b = new { age = 23, male = true };
        
        a.ShouldBe(b);

        a = b;
    }

    [Fact]
    public void RunDemo()
    {
        var demo = new CapturedVariableDemo(this.output);
        Action<string> action = demo.CreateAction("method argument");
        action("lambda argument");
    }
    
    [Fact]
    public void RunDemo2()
    {
        var demo = new CapturedVariableDemo(this.output);
        List<Action> actions = demo.CreateActions();
        foreach (Action action in actions)
        {
            action();
        }
    }
}

public class Location
{
    public int X { get; set; }
    public int Y { get; set; }

    // public override bool Equals(object? obj)
    // {
    //     var compareTo = (Location)obj;
    //
    //     return X == compareTo.X && Y == compareTo.Y;
    // }
}

class CapturedVariableDemo
{
    private string instanceField = "instance field";
    private readonly ITestOutputHelper output;

    public CapturedVariableDemo(ITestOutputHelper output)
    {
        this.output = output;
    }
    public Action<string> CreateAction(string methodParameter)
    {
        string methodLocal = "method local";
        string uncaptured = "uncaptured local";
        Action<string> action = lambdaParameter =>
        {
            string lambdaLocal = "lambda local";
            this.output.WriteLine("Instance field: {0}", instanceField);
            this.output.WriteLine("Method parameter: {0}", methodParameter);
            this.output.WriteLine("Method local: {0}", methodLocal);
            this.output.WriteLine("Lambda parameter: {0}", lambdaParameter);
            this.output.WriteLine("Lambda local: {0}", lambdaLocal);
        };
        methodLocal = "modified method local"; // caution!!!
        return action;
    }

    public List<Action> CreateActions()
    {
        List<Action> actions = new List<Action>();
        for (int i = 0; i < 5; i++)
        {
            string text = string.Format("message {0}", i);
            actions.Add(() => output.WriteLine(text));
        }
        
        return actions;
    }
}

