namespace JAL
{
    public interface IValueType<T> : IValueType
    {
        string Name { get; }
        T Variable { get; }
    }

    public interface IValueType
    {
        ValueType GetValueType();
    }
}