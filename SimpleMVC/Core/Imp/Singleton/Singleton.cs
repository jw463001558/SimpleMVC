namespace SimpleMVC.Core.Imp.Singleton
{
    public class Singleton<T> where T : new()
    {
        private static T _instance;

        protected Singleton()
        {
        }

        public static T GetInstance()
        {
            if (_instance == null)
            {
                _instance = new T();
            }
            return _instance;
        }
    }
}