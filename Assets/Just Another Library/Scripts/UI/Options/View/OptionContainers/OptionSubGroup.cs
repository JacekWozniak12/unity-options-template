using System.Collections.Generic;
using JAL.Extenders;
using UnityEngine;

namespace JAL.UI
{
    public class OptionSubGroup : MonoBehaviour, IValueSubGroup
    {
        [SerializeField]
        OptionSubGroupHeader header;
        IValueGroup parent;
        List<OptionItem> OptionItems = new List<OptionItem>();

        public void AddItem(OptionItem item)
        {
            OptionItems.Add(item);
            item.transform.SetParent(this.transform, false);
        }

        public IValueGroup GetGroup() => parent;
        public string GetName() => header.gameObject != null ? header.gameObject.name : "default";

        private void Awake()
        {
            gameObject.AddComponent<RectTransform>().SetAnchorsStretched();
            SetLayoutGroup();

            if (header != null)
                header.transform.SetParent(this.transform, false);

            foreach (OptionItem item in OptionItems)
                item.transform.SetParent(this.transform, false);
        }

        public void CreateSubGroupHeader(string name)
        {
            GameObject headerHolder = new GameObject($"{name}");
            header = headerHolder.AddComponent<OptionSubGroupHeader>();
            header.transform.SetParent(this.transform, false);
        }

        public void SetLayoutGroup()
        {
            gameObject.UI_CreateVerticalLayoutGroup(childControlWidth: true, childControlHeight: true);
            gameObject.UI_CreateLayoutElement();
        }
    }
}
