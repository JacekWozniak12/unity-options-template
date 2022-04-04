using System.Linq;
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
        [SerializeField] protected OptionItem template;

        protected abstract void SetProduct(OptionItem option, T value);
        protected abstract void SetVariableComponent(OptionItem option);

        protected override sealed void Awake()
        {
            base.Awake();
            template = CreateTemplate();
            SetGameObjectTemplate();
        }

        public virtual GameObject Produce(T value)
        {
            OptionItem option = Instantiate(template, transform);
            SetLabel(option, value.Name);
            SetVariableComponent(option);
            SetProduct(option, value);
            SetGameObject(option, value);
            StandarizeSettings(option);
            return option.gameObject;
        }

        private void StandarizeSettings(OptionItem option)
        {
            StandarizeFontSettings(option);
        }

        private void StandarizeFontSettings(OptionItem option)
        {
            TextMeshProUGUI[] textComponents = option.VariableHolder.GetComponentsInChildren<TextMeshProUGUI>().
                Union(option.LabelHolder.GetComponentsInChildren<TextMeshProUGUI>()).ToArray();
            
            if (textComponents.Length > 0)
            {
                foreach (var component in textComponents)
                {
                    component.fontSize = 32;
                    component.alignment = TextAlignmentOptions.Left;
                }
            }
        }

        protected virtual OptionItem CreateTemplate()
        {
            GameObject group = new GameObject(typeof(T).ToString());
            OptionItem template = group.AddComponent<OptionItem>();
            template.Setup();
            return template;
        }

        protected virtual void SetGameObject(OptionItem option, T value)
        {
            option.gameObject.name = $"Object - {value.Name}";
        }

        protected virtual void SetLabel(OptionItem template, string name)
        {
            template.LabelHolder.GetComponent<TextMeshProUGUI>().text = name;
        }

        private void SetGameObjectTemplate()
        {
            template.transform.SetParent(this.transform, false);
        }
    }
}