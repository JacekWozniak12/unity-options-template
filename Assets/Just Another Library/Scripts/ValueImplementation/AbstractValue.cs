using UnityEngine;
namespace JAL.UI
{
    [System.Serializable]
    public abstract class AbstractValue<T> : IValueType<T>
    {
        [SerializeField] protected string _name;
        [SerializeField] protected T _variable;
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
                if (!_variable.Equals(value))
                {
                    _variable = ValueConversion(value);
                    ValueChanged?.Invoke(_variable);
                }
            }
        }

        public AbstractValue(string name, T variable)
        {
            Name = name;
            Variable = variable;
        }

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