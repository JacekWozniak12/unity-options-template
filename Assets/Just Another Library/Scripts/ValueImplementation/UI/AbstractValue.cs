using UnityEngine;
namespace JAL.UI
{
    public abstract class AbstractValue<T> : IValue<OptionsManager>
    {
        [SerializeField]
        protected string _name;

        [SerializeField]
        protected T _value;

        [SerializeField]
        public event System.Action<T> ValueChanged;

        private OptionsManager optionsManager;

        public AbstractValue(string name, T value, OptionsManager manager)
        {
            _name = name;
            _value = value;
            SetManager(manager);
        }

        public abstract ValueType GetValueType();
        public void SetManager(OptionsManager manager)
        {
            optionsManager = manager;
            manager.CreateUIOption(this);
        }
    }
}