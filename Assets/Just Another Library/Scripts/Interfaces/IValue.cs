using System;
using UnityEngine;

namespace JAL
{
    public interface IValue<T1, T2> : IValueType
        where T1 : IManageValues
        where T2 : IValueGroup
    {
        void SetManager(T1 manager);
        void SetGroup(T2 option);
    }

    public interface IValue<T1> : IValueType
        where T1 : IManageValues
    {
        void SetManager(T1 manager);
    }
}