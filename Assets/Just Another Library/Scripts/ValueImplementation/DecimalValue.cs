namespace JAL
{
    [System.Serializable]
    public class DecimalValue : AbstractValue<float>
    {
        public DecimalValue(float variable,
                            string name = null,
                            System.Action<float>[] events = null,
                            string group = null,
                            string subGroup = null) : base(variable, name, events, group, subGroup)
        {
        }

        public override ValueType GetValueType() => ValueType.Decimal;
        public override float ValueConversion(float variable) => variable;
    }
}

