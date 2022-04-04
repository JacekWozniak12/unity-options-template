namespace JAL
{
    public interface IValueType<T> : IValueType
    {
        string Name { get; }
        T Variable { get; }
        IValueGroup Group { get; }
        IValueSubGroup SubGroup { get; }
    }

    public interface IValueType
    {
        ValueType GetValueType();
    }
}