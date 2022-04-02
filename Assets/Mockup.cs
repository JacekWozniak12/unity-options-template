using JAL;
using JAL.UI;
using UnityEngine;

public class Mockup : MonoBehaviour
{

    [SerializeField]
    DecimalValue optionDecimal;

    private void Start()
    {
        OptionsManager.Instance.CreateUIOption(optionDecimal = new DecimalValue(nameof(optionDecimal), 10));
    }
}
