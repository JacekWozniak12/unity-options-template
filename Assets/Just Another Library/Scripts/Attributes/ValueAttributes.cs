using System;

namespace JAL
{
    [System.AttributeUsage(System.AttributeTargets.Field | System.AttributeTargets.Property)]
    public sealed class GameTooltipAttribute : System.Attribute
    {
        public readonly string Tooltip;

        public GameTooltipAttribute(string tooltip)
        {
            Tooltip = tooltip;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Class)]
    public sealed class ValueClassSubscriberAttribute : System.Attribute
    {
        public readonly Type Manager;

        public ValueClassSubscriberAttribute(Type manager)
        {
            Manager = manager;
        }
    }
}

