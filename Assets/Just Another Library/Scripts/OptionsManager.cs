using JAL.UI;
using UnityEngine;
namespace JAL
{
    public class OptionsManager : MonoBehaviourSingleton<OptionsManager>
    {
        [SerializeField] OptionsView optionsView;

        internal void CreateUIOption(IValueType value)
        {
            switch (value.GetValueType())
            {
                case ValueType.None:
                    break;
                case ValueType.Integer:
                    IntegerOptionCreator.Instance.Produce(value as IntegerValue);
                    break;
                case ValueType.Decimal:
                    DecimalOptionCreator.Instance.Produce(value as DecimalValue);
                    break;
                case ValueType.Range:
                    RangeOptionCreator.Instance.Produce(value as RangeValue);
                    break;
                case ValueType.String:
                    StringOptionCreator.Instance.Produce(value as StringValue);
                    break;
                case ValueType.Other:
                    ImplementOtherValueType(value);
                    break;
            }
        }

        private void ImplementOtherValueType(IValueType value)
        {
            if (value is IImplementUIOfOtherValueType otherImplementator)
                otherImplementator.GetUIImplementation();
        }
    }
}

