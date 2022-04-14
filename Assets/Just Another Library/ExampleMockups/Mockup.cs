using JAL;
using UnityEngine;

[ValueClassSubscriber(typeof(OptionsManager))]
public class Mockup : MonoBehaviour, IAbstractValueImplementator
{
    [SerializeField]
    [UI_Tooltip("This is range value")]
    RangeValue Range = new RangeValue(
        1,
        events: new System.Action<float>[] {
            (x) =>
            {
                Debug.Log(x);
            }
        });

}
