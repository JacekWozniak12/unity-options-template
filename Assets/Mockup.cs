using JAL;
using UnityEngine;

[ValueClassSubscriber(typeof(OptionsManager))]
public class Mockup : MonoBehaviour, IAbstractValueImplementator
{
    [SerializeField]
    [GameTooltip("this is range value")]
    RangeValue r3232131ange = new RangeValue(0, events: new System.Action<float>[] { (x) => Debug.Log(x) });

}
