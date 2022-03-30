using UnityEngine;

namespace JAL
{
    public interface IManageValueUICreation<T0> where T0 : IValueType
    {
        GameObject CreateUIRepresentationOfValue(T0 value);
    }
}