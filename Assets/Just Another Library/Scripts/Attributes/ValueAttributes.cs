using System;

namespace JAL
{
    /// <summary>
    /// Handles UI tooltip attribute. For attribute implementation
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field | System.AttributeTargets.Property)]
    public sealed class UI_TooltipAttribute : System.Attribute
    {
        public string Name;
        public string Field;

        public UI_TooltipAttribute(string name, string field = "")
        {
            Name = name;
            Field = field;
        }
    }

    /// <summary>
    /// Connects entire class with IManageValues Manager.
    /// </summary>
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

