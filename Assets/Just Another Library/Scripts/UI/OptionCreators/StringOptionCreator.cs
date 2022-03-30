using UnityEngine;
using TMPro;
using DC = TMPro.TMP_DefaultControls;

namespace JAL.UI
{
    public class StringOptionCreator : AbstractOptionCreator<StringValue, TMP_InputField>
    {
        public override GameObject Produce(StringValue value)
        {
            throw new System.NotImplementedException();
        }

        protected override OptionTemplate CreateTemplate()
        {
            throw new System.NotImplementedException();
        }
    }
}
