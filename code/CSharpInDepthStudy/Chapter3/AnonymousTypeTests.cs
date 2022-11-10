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