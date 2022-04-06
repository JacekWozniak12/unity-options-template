using UnityEngine;

namespace JAL
{
    public interface ITooltipDisplayer
    {
        string Display(GameTooltipAttribute tooltipAttribute);
    }
}