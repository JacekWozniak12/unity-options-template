using JAL.Extenders;
using UnityEngine;
namespace JAL
{
    public abstract class AbstractValue
    {
        [SerializeField] protected string _name = "";

        public string Name
        {
            get => _name;
            protected set => _name = value;
        }

        public string GroupName
        {
            get; protected set;
        }

        public string SubGroupName
        {
            get; protected set;
        }
    }

    [System.Serializable]
    public abstract class AbstractValue<T> : AbstractValue, IValueType<T>
    {
        [SerializeField] protected T _variable = default;
        [SerializeField] public System.Action<T> ValueChanged;


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

        public void EventAdd(System.Action<T> evt) => ValueChanged += evt;
        public void EventDelete(System.Action<T> evt) => ValueChanged -= evt;
        public void EventsClearUp() => ValueChanged = null;

    }
}