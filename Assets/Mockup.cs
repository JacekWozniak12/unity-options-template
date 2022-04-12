using JAL;
using UnityEngine;

[ValueClassSubscriber(typeof(OptionsManager))]
public class Mockup : MonoBehaviour, IAbstractValueImplementator
{
    [SerializeField]
    [GameTooltip("this is range value")]
    RangeValue rangeValue = new RangeValue("Test", 0, new System.Action<float>[] { (x) => Debug.Log(x) });
}
