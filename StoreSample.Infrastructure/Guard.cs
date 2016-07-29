namespace StoreSample.Infrastructure
{
    using System;

    public static class Guard
    {
        public static void NotNull<T>(T item)
        {
            NotNull<T>(item, "The passed object is null and cannot be used in the operation.");
        }

        public static void NotNull<T>(T item, string message)
        {
            if(item == null)
            {
                throw new NullReferenceException(message);
            }
        }

        public static void NotNullOrEmpty(string item)
        {
            NotNullOrEmpty(item, "Invalid input the passed string was null or empty.");
        }

        public static void NotNullOrEmpty(string item, string message)
        {
            if(string.IsNullOrEmpty(item))
            {
                throw new ArgumentNullException(message);
            }
        }
    }
}
