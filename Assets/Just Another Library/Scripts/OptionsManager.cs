using JAL.UI;
using UnityEngine;

namespace JAL
{
    public class OptionsManager : MonoBehaviourSingleton<OptionsManager>, IManageValues
    {

        [SerializeField] OptionsView optionsView;
        
        internal void CreateUIOption(IValue<OptionsManager> value)
        {
            switch (value.GetValueType())
            {
                case ValueType.None:
                    return;
                case ValueType.Integer:
                    IntegerOptionCreator.Instance.CreateUIRepresentationOfValue(value as IntegerValue);
                    break;
                case ValueType.Decimal:
                    DecimalOptionCreator.Instance.CreateUIRepresentationOfValue(value as DecimalValue);
                    break;
                case ValueType.Range:
                    RangeOptionCreator.Instance.CreateUIRepresentationOfValue(value as RangeValue);
                    break;
                case ValueType.String:
                    StringOptionCreator.Instance.CreateUIRepresentationOfValue(value as StringValue);
                    break;
                case ValueType.Other:
                    ImplementOtherValueType(value);
                    break;
            }
        }

        private void ImplementOtherValueType(IValue<OptionsManager> value)
        {
            if (value is IImplementUIOfOtherValueType otherImplementator)
                otherImplementator.GetUIImplementation();
        }
    }
}

