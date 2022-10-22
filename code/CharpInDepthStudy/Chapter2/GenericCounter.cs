using Xunit.Abstractions;

namespace CSharpInDepthStudy.Chapter2;

public class GenericCounter
{
    
    private readonly ITestOutputHelper output;

    public GenericCounter(ITestOutputHelper output)
    {
        this.output = output;
        // this.output.WriteLine("this is constructor");
    }

    [Fact]
    public void RunCounter()
    {
        GenericCounter<string>.Increment();
        GenericCounter<string>.Increment();
        output.WriteLine(GenericCounter<string>.Display());
        
        GenericCounter<int>.Increment();
        output.WriteLine(GenericCounter<int>.Display());
    }
    
}

class GenericCounter<T>
{
    private static int value;

    public static void Increment() => value++;

    public static string Display() => $"Counter for {typeof(T)}: {value}";
}