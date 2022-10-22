using Shouldly;

namespace CSharpInDepthStudy.Chapter2;

public class MyNullableTests
{
    [Fact]
    public void Test_should_be_success()
    {
        Assert.True(true);
    }

    [Fact]
    public void Nullable_Int_should_be_false()
    {
        var nullable = new MyNullable<int>();
        Assert.False(nullable.HasValue);
        // Assert.Throws<InvalidOperationException>(() => nullable.Value);
        
        var nullable2 = new MyNullable<int>(3);
        Assert.True(nullable2.HasValue);
    }
    
    [Fact]
    public void Boxing_nullable_value_type_should_be_null_reference()
    {
        var x = 123;
        object o = x;
        Assert.True(o.GetType() == typeof(int));
        
        var noValue = new Nullable<int>();
        object noValueBoxed = noValue;
        Assert.Null(noValueBoxed);
        Assert.False(noValue.HasValue);
        Assert.Throws<NullReferenceException>(() => noValueBoxed.GetType());
        
        var someValue = new Nullable<int>(5);
        object someValueBoxed = someValue;
        Assert.True(o.GetType() == typeof(int));
    }

    [Fact]
    public void null_literal()
    {
        int? x = new int?();
        int? y = null;
        Assert.Throws<NullReferenceException>(() => x.GetType());
    }
    
    [Fact]
    public void null_listed_operator()
    {
        int bread = 5;
        int? cheese = new int?();

        if (cheese.HasValue)
        {
            var total = bread + 1 + cheese.xxx;    
        }
        
        var total = bread + 1 + cheese?.xxx;
    }
}