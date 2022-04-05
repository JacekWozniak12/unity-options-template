using JAL;
using JAL.UI;
using UnityEngine;

[ValueClassSubscriber(typeof(OptionsManager))]
public class Mockup : MonoBehaviour, IAbstractValueImplementator
{
    [SerializeField]
    [UI_Game_Tooltip("this is range value")]
    RangeValue rangeValue = new RangeValue("Range Value", 0, new System.Action<float>[] { (x) => Debug.Log(x) });
}
