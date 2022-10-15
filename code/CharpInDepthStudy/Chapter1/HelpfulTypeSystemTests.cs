using System.Collections;
using Shouldly;

namespace CSharpInDepthStudy.Chapter1;

public class HelpfulTypeSystemTests
{
    [Fact]
    public void Casting_happens_when_IEnumerable_holds_object()
    {
        var objects = new List<object> { new Book("CsharpInDepth")};
        var book = (Book)objects.First();
        
        book.ShouldBeOfType<Book>();
    }

    [Fact]
    public void Tuple_can_replace_multiple_and_comparison()
    {
        var a = 10;
        var b = 20;
        var x = 10;
        var y = 20;
        
        ((a, b) == (x, y)).ShouldBeTrue();
    }
}