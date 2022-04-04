using JAL;
using JAL.UI;
using UnityEngine;

public class Mockup : MonoBehaviour
{
    [SerializeField]
    RangeValue rangeValue = new RangeValue("t", 0, (x) => Debug.Log(x));

    private void Start()
    {
        rangeValue.SubscribeTo(OptionsManager.Instance);
    }
}
