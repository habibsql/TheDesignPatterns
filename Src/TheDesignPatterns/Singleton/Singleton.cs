using System;

namespace TheDesignPatterns.Singleton
{
    /// <summary>
    /// Singleton object (Application lifetime only onetime instance will be created)
    /// </summary>
    public class ApplicationObject
    {
        public Guid ApplicationId { get; private set; }
        private static ApplicationObject singleInstance = null;
        private static readonly object v = new object();
        private static readonly object lockObject = v;


        private ApplicationObject()
        {
        }

        public static ApplicationObject GetInstance()
        {
            if (null == singleInstance)
            {
                lock (lockObject)
                {
                    if (null == singleInstance)
                    {
                        singleInstance = new ApplicationObject
                        {
                            ApplicationId = Guid.NewGuid()
                        };
                    }
                }
            }

            return singleInstance;
        }
    }
}
