using JAL;
using JAL.UI;
using UnityEngine;

public class Mockup : MonoBehaviour
{
    [SerializeField]
    RangeValue rangeValue = new RangeValue(
        "Range Value",
        0,
        new System.Action<float>[] { (x) => Debug.Log(x) }
        );

    private void Start()
    {
        rangeValue.SubscribeTo(OptionsManager.Instance);
    }
}
