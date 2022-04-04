namespace JAL
{
    [System.Serializable]
    public class DecimalValue : AbstractValue<float>
    {
        public DecimalValue(string name, float variable, System.Action<float>[] events = null, string group = null, string subGroup = null) 
        : base(name, variable, events, group, subGroup)
        {
        }

        public override ValueType GetValueType() => ValueType.Decimal;
        public override float ValueConversion(float variable) => variable;
    }
}

