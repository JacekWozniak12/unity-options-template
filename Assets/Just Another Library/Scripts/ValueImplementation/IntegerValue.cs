using System;

namespace JAL
{
    [System.Serializable]
    public class IntegerValue : AbstractValue<int>
    {
        public IntegerValue(string name, int variable, Action<int>[] evt, string group = null, string subGroup = null) 
        : base(name, variable, evt, group, subGroup)
        {
        }

        public override ValueType GetValueType() => ValueType.Integer;
        public override int ValueConversion(int variable) => variable;
    }
}
