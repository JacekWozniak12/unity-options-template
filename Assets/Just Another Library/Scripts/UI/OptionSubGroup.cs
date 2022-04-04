using System.Collections.Generic;
using UnityEngine;

namespace JAL.UI
{
    public class OptionSubGroup : MonoBehaviour, IValueSubGroup
    {
        [SerializeField]
        OptionSubGroupHeader header;

        [SerializeField]
        List<OptionItem> OptionItems = new List<OptionItem>();
        
        IValueGroup parent;

        public IValueGroup GetGroup() => parent;

        public string GetSubGroupName() 
            => header.gameObject != null ? header.gameObject.name : "default";

        private void Start()
        {
            if (header != null)
            {
                header.transform.SetParent(this.transform, false);
            }

            foreach (OptionItem item in OptionItems)
            {
                item.transform.SetParent(this.transform, false);
            }
        }

        public void CreateSubGroupHeader()
        {
            GameObject headerHolder = new GameObject($"Header - {GetSubGroupName()}");
            header = headerHolder.AddComponent<OptionSubGroupHeader>();
        }
    }
}
