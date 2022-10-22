namespace CSharpInDepthStudy.Chapter2;

public readonly struct MyNullable<T> where T : struct
{
    private readonly T _value;
    public bool HasValue { get; }
    
    public MyNullable(T value)
    {
        _value = value;
        HasValue = true;
    }

    public T Value
    {
        get
        {
            if (!HasValue)
            {
                throw new InvalidOperationException();
            }

            return _value;
        }
    }
}
