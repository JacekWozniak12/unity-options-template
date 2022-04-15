using System;

namespace JAL
{
    /// <summary>
    /// Handles UI tooltip attribute. 
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field | System.AttributeTargets.Property)]
    public sealed class UI_TooltipAttribute : System.Attribute
    {
        public string Description;

        public UI_TooltipAttribute(string description)
        {
            Description = description;
        }
    }

    /// <summary>
    /// Connects entire class with IManageValues Manager.
    /// Requires IAbstractValueImplementator on class
    /// to be processed with AbstractValueCollector
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

