namespace JAL
{
    public interface IValueGroup
    {
        IValueSubGroup Default { get; }
        string GetGroupName();
    }
}