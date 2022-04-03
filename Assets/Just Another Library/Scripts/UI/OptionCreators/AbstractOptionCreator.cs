using TMPro;
using UnityEngine;

namespace JAL.UI
{
    /// <summary>Uses and seals Awake() message.</summary>
    /// <typeparam name="T">Value type</typeparam>
    /// <typeparam name="T1">Component used to present value type</typeparam>
    public abstract class AbstractOptionCreator<T, T1, T2> :
        MonoBehaviourSingleton<AbstractOptionCreator<T, T1, T2>>,
        IManageValueUICreation<T>
        where T : IValueType<T2>
        where T1 : Component
    {
        [SerializeField] protected OptionTemplate template;

        protected override sealed void Awake()
        {
            base.Awake();
            template = CreateTemplate();
            SetGameObjectTemplate();
        }

        protected abstract void SetProduct(OptionTemplate option, T value);
        protected abstract void SetVariableComponent(OptionTemplate option);

        public virtual GameObject Produce(T value)
        {
            OptionTemplate option = Instantiate(template, transform);
            SetLabel(option, value.Name);
            SetVariableComponent(option);
            SetProduct(option, value);
            SetGameObject(option, value);
            return option.gameObject;
        }

        protected virtual OptionTemplate CreateTemplate()
        {
            GameObject group = new GameObject(typeof(T).ToString());
            OptionTemplate template = group.AddComponent<OptionTemplate>();
            template.Setup();
            return template;
        }

        protected virtual void SetGameObject(OptionTemplate option, T value)
        {
            option.gameObject.name = $"Object - {value.Name}";
        }

        protected virtual void SetLabel(OptionTemplate template, string name)
        {
            template.LabelHolder.GetComponent<TextMeshProUGUI>().text = name;
        }

        private void SetGameObjectTemplate()
        {
            template.transform.SetParent(this.transform, false);
        }
    }
}