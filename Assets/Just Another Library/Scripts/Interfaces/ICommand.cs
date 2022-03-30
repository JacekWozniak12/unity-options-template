namespace JAL
{
    /// <summary>
    /// Execute(), Undo()
    /// </summary>
    public interface ICommand 
    {
        void Execute();
        void Undo();
    }
}