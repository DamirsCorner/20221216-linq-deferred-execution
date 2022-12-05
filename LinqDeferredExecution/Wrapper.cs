namespace LinqDeferredExecution;

public class Wrapper<T>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public T Value { get; set; }

    public Wrapper(T value)
    {
        Value = value;
    }
}
