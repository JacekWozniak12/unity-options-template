using JAL.UI;
using UnityEngine;
namespace JAL
{
    public class OptionsManager : MonoBehaviourSingleton<OptionsManager>, IManageValues
    {
        [SerializeField] OptionsView optionsView;

        private void Start() => optionsView.SelectGroup();

        public void CreateValueHandler(IValueType value)
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
            if (value is ICreateUIForOtherValueType otherImplementator)
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
            if (value.GroupName != null)
            {
                group = optionsView.ListOfGroups.Find(
                    x => x.name == value.GroupName);

                if (group == null)
                {
                    temp = new GameObject(value.GroupName);
                    group = temp.AddComponent<OptionGroup>();
                    optionsView.ListOfGroups.Add(group);
                    group.Setup(optionsView.optionGroupButtons, () => optionsView.SelectGroup(group));
                    group.transform.SetParent(optionsView.optionList.transform, false);
                }
            }
            else group = optionsView.MainGroup;

            if (value.SubGroupName != null)
            {
                subGroup = group.ListOfSubGroups.Find(
                    x => x.name == value.SubGroupName);
                if (subGroup == null)
                {
                    temp = new GameObject(value.SubGroupName);
                    subGroup = temp.AddComponent<OptionSubGroup>();
                    group.ListOfSubGroups.Add(subGroup);
                    subGroup.transform.SetParent(group.transform, false);
                    subGroup.CreateSubGroupHeader(value.SubGroupName);
                }
            }
            else subGroup = group.Main;

            subGroup.AddItem(item.GetComponent<OptionItem>());
        }
    }
}

