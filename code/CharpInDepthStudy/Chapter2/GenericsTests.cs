using System.Collections;
using System.Collections.Specialized;
using System.Globalization;
using Shouldly;
using Xunit.Abstractions;

namespace CSharpInDepthStudy.Chapter2;

public class GenericsTests
{
    private readonly ITestOutputHelper output;

    public GenericsTests(ITestOutputHelper output)
    {
        this.output = output;
        // this.output.WriteLine("this is constructor");
    }

    [Fact]
    public void ArrayList_WithMixedTypes_ShouldThrowException()
    {
        ArrayList list = new ArrayList();
        list.Add("Jake");
        list.Add("Ryu");
        list.Add(123); // ArrayList can add different types

        Should.Throw<InvalidCastException>(() =>
        {
            foreach (var item in list)
            {
                output.WriteLine((string)item);
            }
        });
    }

    [Fact]
    public void StringCollection_ShouldBeTypeSafe()
    {
        StringCollection names = new StringCollection();
        names.Add("Jake");
        names.Add("Andrew");
        names.Add("Rich");

        // names.Add(123); // compiler error

        foreach (var name in names)
        {
            output.WriteLine(name);
        }
    }

    [Fact]
    public void ReferenceTypeArray_WhenStoringValues_ShouldBeSafe()
    {
        string[] names = new[] { "Jake", "Ryu" };

        Object[] objects = names; // covariance  <> contravariance
    }


    [Fact]
    public void DefaultValue()
    {
        var defaultInt = default(int);
        defaultInt.ShouldBe(0);

        var defaultList = default(List<int>);
        defaultList.ShouldBeNull();
    }

    [Fact]
    public void Debug()
    {
        var defString = default(string);
        
        var x = new List<int>();

        var typeX = x.GetType();

        var y = new Dictionary<int, string>();

        var typeY = y.GetType();
        
        var typeY2 = typeof(Dictionary<int, string>);

        var typeY3 = typeof(Dictionary<,>);
    }
}

public class ValidatingList<TItem>
{
    private readonly List<TItem> items = new List<TItem>();

    // Compile error
    // private readonly List<T> wrong = new List<T>();

    // Generic method is valid
    public void GenericMethod<T>(T input)
    {
    }
    
    // Conversion error. List<MyFormat> to List<IFormattable>
    // static void PrintItems(List<IFormattable> items)
    // {
    // }

    void PrintItems<T>(List<T> items) where T : IFormattable
    {
        CultureInfo culture = CultureInfo.InvariantCulture;
        foreach (T item in items)
        {
            Console.WriteLine(item.ToString(null, culture));
        }
    }

    void TestPrintItems()
    {
        List<MyFormat> x = new List<MyFormat>();

        //var x = new MyFormat();
        PrintItems(x);
    }
}


public class MyFormat : IFormattable
{
    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        throw new NotImplementedException();
    }
}