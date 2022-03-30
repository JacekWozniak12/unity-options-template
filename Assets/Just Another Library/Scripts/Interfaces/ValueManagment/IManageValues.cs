using System.Collections.Generic;
namespace JAL
{
    public interface IManageValues<T> where T : IValueType
    {
        List<T> ValueList
        {
            get;
        }
    }
}

