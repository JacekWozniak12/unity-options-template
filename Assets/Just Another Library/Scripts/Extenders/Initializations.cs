namespace JAL.Extenders
{
    public static class Initializations
    {
        public static void Initialize<T>(this T obj) where T : IInitialize
        {
            if (obj.GetType() == typeof(T))
                obj.OnInitialize();
        }
    }
}