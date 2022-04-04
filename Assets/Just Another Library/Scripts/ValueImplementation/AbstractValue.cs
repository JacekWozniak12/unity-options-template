using UnityEngine;
namespace JAL
{
    [System.Serializable]
    public abstract class AbstractValue<T> : IValueType<T>
    {
        [SerializeField] protected string _name = "";
        [SerializeField] protected T _variable = default;
        [SerializeField] public System.Action<T> ValueChanged;

        public string Name
        {
            get => _name;
            protected set => _name = value;
        }

        public T Variable
        {
            get => _variable;
            set
            {
                // Hack -> if _variable is class object then 
                // using .Equals throws null reference. 
                if (_variable == null || !_variable.Equals(value))
                {
                    _variable = ValueConversion(value);
                    ValueChanged?.Invoke(_variable);
                }
            }
        }

        public string GroupName
        {
            get; private set;
        }

        public string SubGroupName
        {
            get; private set;
        }

        public AbstractValue(
            string name,
            T variable,
            System.Action<T>[] events = null,
            string group = null,
            string subGroup = null)
        {
            Name = name;
            Variable = variable;
            foreach (var evt in events) ValueChanged += evt;
            GroupName = group;
            SubGroupName = subGroup;
        }

        /// <summary>
        /// Defines the type of Variable that is observed
        /// </summary>
        public abstract ValueType GetValueType();

        /// <summary>
        /// Defines additional operation on Variable before it is saved in member;
        /// </summary>
        public abstract T ValueConversion(T variable);

        public AbstractValue<T> SubscribeTo(IManageValues creator)
        {
            creator.CreateValueHandler(this);
            return this;
        }

        public void EventAdd(System.Action<T> evt) => ValueChanged += evt;
        public void EventDelete(System.Action<T> evt) => ValueChanged -= evt;
        public void EventsClearUp() => ValueChanged = null;
    }
}