using System;

namespace JAL
{
    [System.Serializable]
    public class IntegerValue : AbstractValue<int>
    {
        public IntegerValue(int variable,
                            string name = null,
                            Action<int>[] events = null,
                            string group = null,
                            string subGroup = null) : base(variable, name, events, group, subGroup)
        {
        }

        public override ValueType GetValueType() => ValueType.Integer;
        public override int ValueConversion(int variable) => variable;
    }
}
