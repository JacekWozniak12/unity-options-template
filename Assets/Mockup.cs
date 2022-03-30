using JAL;
using JAL.UI;
using UnityEngine;

public class Mockup : MonoBehaviour
{
    [SerializeField] int optionInt;
    [SerializeField] float optionDecimal;
    [SerializeField] float optionRange;
    [SerializeField] string optionText;
    [SerializeField] Sprite optionOther;

    private void Start()
    {
        OptionsManager.Instance.CreateUIOption(new DecimalValue(nameof(optionDecimal), optionDecimal));
    }
}
