using JAL;
using JAL.UI;
using UnityEngine;

public class Mockup : MonoBehaviour
{

    [SerializeField]
    DecimalValue optionDecimal;

    [SerializeField]
    IntegerValue optionInteger;

    [SerializeField]
    StringValue optionString;

    [SerializeField]
    RangeValue optionRange;

    private void Start()
    {
        OptionsManager.Instance.CreateUIOption(optionDecimal = new DecimalValue(nameof(optionDecimal), 10.23f));
        OptionsManager.Instance.CreateUIOption(optionInteger = new IntegerValue(nameof(optionInteger), 10));
        OptionsManager.Instance.CreateUIOption(optionString = new StringValue(nameof(optionString), "3124"));
        OptionsManager.Instance.CreateUIOption(optionRange = new RangeValue(nameof(optionRange), 1));
    
        for(int i = 0; i < 50; i++)
        {
            OptionsManager.Instance.CreateUIOption(new RangeValue("Range", (float)Random.Range(0, 10f)/10));
        }
    }
}
