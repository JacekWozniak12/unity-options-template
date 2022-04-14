using UnityEngine;

namespace JAL
{
    public interface ITooltipDisplayer
    {
        string Display(UI_TooltipAttribute tooltipAttribute);
    }
}