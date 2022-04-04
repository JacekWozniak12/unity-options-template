using UnityEngine;
namespace JAL
{
    [System.Serializable]
    public abstract class AbstractValue<T> : IValueType<T>
    {
        [SerializeField] protected string _name = "";
        [SerializeField] protected T _variable = default;
        [SerializeField] public event System.Action<T> ValueChanged;

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
            get;
            private set;
        }

        public string SubGroupName
        {
            get;
            private set;
        }

        #region Constructors
        public AbstractValue(string name, T variable)
        {
            Name = name;
            Variable = variable;
        }
        public AbstractValue(string name, T variable, string group)
        {
            Name = name;
            Variable = variable;
            GroupName = group;
        }
        public AbstractValue(string name, T variable, string group, string subGroup)
        {
            Name = name;
            Variable = variable;
            GroupName = group;
            SubGroupName = subGroup;
        }
        #endregion

        /// <summary>
        /// Defines the type of Variable that is observed
        /// </summary>
        public abstract ValueType GetValueType();

        /// <summary>
        /// Defines additional operation on Variable before it is saved in member;
        /// </summary>
        public abstract T ValueConversion(T variable);
    }
}