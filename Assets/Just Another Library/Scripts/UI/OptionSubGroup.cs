using System.Collections.Generic;
using UnityEngine;

namespace JAL.UI
{
    public class OptionSubGroup : MonoBehaviour, IValueSubGroup
    {
        [SerializeField]
        OptionSubGroupHeader header;
        IValueGroup parent;

        public List<OptionItem> OptionItems = new List<OptionItem>();
        public IValueGroup GetGroup() => parent;

        public string GetName() 
            => header.gameObject != null ? header.gameObject.name : "default";

        private void Start()
        {
            if (header != null)
                header.transform.SetParent(this.transform, false);

            foreach (OptionItem item in OptionItems)
                item.transform.SetParent(this.transform, false);
        }

        public void CreateSubGroupHeader()
        {
            GameObject headerHolder = new GameObject($"Header - {GetName()}");
            header = headerHolder.AddComponent<OptionSubGroupHeader>();
        }
    }
}
