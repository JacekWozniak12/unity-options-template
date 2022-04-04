using JAL.UI;
using UnityEngine;
namespace JAL
{
    public class OptionsManager : MonoBehaviourSingleton<OptionsManager>
    {
        [SerializeField] OptionsView optionsView;

        public void CreateUIOption(IValueType value)
        {
            GameObject product = null;

            switch (value.GetValueType())
            {
                case ValueType.None:
                    return;
                case ValueType.Integer:
                    product = IntegerOptionCreator.Instance.Produce(value as IntegerValue);
                    break;
                case ValueType.Decimal:
                    product = DecimalOptionCreator.Instance.Produce(value as DecimalValue);
                    break;
                case ValueType.Range:
                    product = RangeOptionCreator.Instance.Produce(value as RangeValue);
                    break;
                case ValueType.String:
                    product = StringOptionCreator.Instance.Produce(value as StringValue);
                    break;
                case ValueType.Other:
                    product = ImplementOtherValueType(value);
                    break;
            }

            if (product != null)
            {
                FindOrCreateGroupFor(value, product);
            }
        }

        private GameObject ImplementOtherValueType(IValueType value)
        {
            if (value is IImplementOtherValueType otherImplementator)
                return otherImplementator.GetUIImplementation();
            else
                return null;
        }

        private void FindOrCreateGroupFor(IValueType value, GameObject item)
        {
            GameObject temp;
            OptionGroup group;
            OptionSubGroup subGroup;

            // Setting the group and subgroup tabs;
            if (value.Group != null)
            {
                group = optionsView.Groups.Find(x => x.name == value.Group.GetName());
                
                if (group == null)
                {
                    temp = new GameObject(value.Group.GetName());
                    var g = gameObject.AddComponent<OptionGroup>();
                    optionsView.Groups.Add(g);
                }
            }
            else group = optionsView.MainGroup;

            if (value.SubGroup != null)
            {
                subGroup = group.SubGroups.Find(x => x.name == value.SubGroup.GetName());
                if (subGroup == null)
                {
                    temp = new GameObject(value.SubGroup.GetName());
                    var g = gameObject.AddComponent<OptionSubGroup>();
                    group.SubGroups.Add(g);
                }
            }
            else
            {
                subGroup = group.Main;
            }

            subGroup.OptionItems.Add(item.GetComponent<OptionItem>());
        }
    }
}

