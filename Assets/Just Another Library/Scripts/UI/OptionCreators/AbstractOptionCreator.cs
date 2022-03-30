using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DC = TMPro.TMP_DefaultControls;

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
        [SerializeField]
        protected GameObject prefab;
        protected GameObject template;

        public abstract GameObject CreateUIRepresentationOfValue(T value);

        protected override sealed void Awake()
        {
            base.Awake();

            if (prefab != null && GetRequiredComponent() != null)
            {
                template = Instantiate(prefab, transform);
            }
            else
            {
                template = CreateTemplate();
            }
            template.SetActive(false);
        }

        protected abstract GameObject CreateTemplate();
        protected T1 GetRequiredComponent() => prefab.GetComponentInChildren<T1>();
    }
}