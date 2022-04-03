namespace JAL
{
    /// <summary>
    /// Names of value implementations used in Unity, using [System.Flags] attribute, from 0 to 31. 
    /// Values meant to be implemented in IValueType below:
    /// <list>
    /// <item/> None
    /// <item/> Integer
    /// <item/> Decimal - depends on implementation, but float intended
    /// <item/> Range - for from 0 to 1 variables, great for sliders
    /// <item/> String - text variables
    /// <item/> Other - if there is need for custom assets etc
    /// </list>
    /// </summary>
    [System.Flags]
    [System.Serializable]
    public enum ValueType
    {
        None = 0,
        Integer = 1,
        Decimal = 2,
        // Integer, Decimal = 3
        Range = 4,
        // Integer, Range = 5
        // Decimal, Range = 6
        // Integer, Decimal, Range = 7
        String = 8,
        // Integer, String = 9
        // Decimal, String = 10
        // etc...
        Other = 16
    }
}

