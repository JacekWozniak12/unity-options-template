using UnityEngine;

namespace JAL
{
    public interface IManageValueUICreation<T0> where T0 : IValueType
    {
        GameObject Produce(T0 value);
    }
}