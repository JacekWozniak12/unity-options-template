using UnityEngine;
using TDC = TMPro.TMP_DefaultControls;

namespace JAL.UI
{
    /// <summary>
    /// Uses and seals Awake() message.
    /// </summary>
    /// <typeparam name="T">Value type</typeparam>
    /// <typeparam name="T1">Component used to present value type</typeparam>
    public abstract class AbstractOptionCreator<T, T1> :
        MonoBehaviourSingleton<AbstractOptionCreator<T, T1>>,
        IManageValueUICreation<T>
        where T : IValueType
        where T1 : Component
    {
        [SerializeField] protected OptionTemplate prefab;
        [SerializeField] protected OptionTemplate template;

        protected override sealed void Awake()
        {
            base.Awake();

            if (prefab != null && GetRequiredComponent() != null)
                template = Instantiate(prefab, transform);
            else
                template = CreateTemplate();

            template.transform.SetParent(this.transform, false);
            template.gameObject.SetActive(false);
        }

        public abstract GameObject Produce(T value);
        protected const string NAME_LABEL = "label";
        protected const string NAME_VARIABLE = "variable";
        protected abstract OptionTemplate CreateTemplate();
        protected T1 GetRequiredComponent() => prefab.GetComponentInChildren<T1>();
    }
}