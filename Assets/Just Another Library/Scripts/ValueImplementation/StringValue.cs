namespace JAL
{
    [System.Serializable]
    public class StringValue : AbstractValue<string>
    {
        public StringValue(string name, string variable, System.Action<string>[] events = null, string group = null, string subGroup = null) 
        : base(name, variable, events, group, subGroup)
        {
        }

        public override ValueType GetValueType() => ValueType.String;
        public override string ValueConversion(string variable) => variable.Trim();
    }
}

