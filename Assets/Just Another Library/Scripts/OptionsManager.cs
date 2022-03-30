using JAL.UI;
using UnityEngine;
namespace JAL
{
    public class OptionsManager : MonoBehaviourSingleton<OptionsManager>
    {
        [SerializeField] OptionsView optionsView;

        public void CreateUIOption(IValueType value)
        {
            GameObject temp = null;

            switch (value.GetValueType())
            {
                case ValueType.None:
                    return;
                case ValueType.Integer:
                    temp = IntegerOptionCreator.Instance.Produce(value as IntegerValue);
                    break;
                case ValueType.Decimal:
                    temp = DecimalOptionCreator.Instance.Produce(value as DecimalValue);
                    break;
                case ValueType.Range:
                    temp = RangeOptionCreator.Instance.Produce(value as RangeValue);
                    break;
                case ValueType.String:
                    temp = StringOptionCreator.Instance.Produce(value as StringValue);
                    break;
                case ValueType.Other:
                    temp = ImplementOtherValueType(value);
                    break;
            }

            if (temp != null)
            {
                temp.transform.SetParent(optionsView.optionList, false);
            }
        }

        private GameObject ImplementOtherValueType(IValueType value)
        {
            if (value is IImplementUIOfOtherValueType otherImplementator)
                return otherImplementator.GetUIImplementation();

            else
                return null;
        }
    }
}

