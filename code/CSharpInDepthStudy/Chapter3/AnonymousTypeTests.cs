using Shouldly;

namespace CSharpInDepthStudy.Chapter3;

public class AnonymousTypeTests
{
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