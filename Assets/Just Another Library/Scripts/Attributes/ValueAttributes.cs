using System;

namespace JAL
{
    [System.AttributeUsage(System.AttributeTargets.Field | System.AttributeTargets.Property)]
    public sealed class UI_Game_TooltipAttribute : System.Attribute
    {
        public readonly string Tooltip;

        public UI_Game_TooltipAttribute(string tooltip)
        {
            Tooltip = tooltip;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Class)]
    public sealed class ValueClassSubscriber : System.Attribute
    {
        public readonly Type Manager;

        public ValueClassSubscriber(Type manager)
        {
            Manager = manager;
        }
    }
}

