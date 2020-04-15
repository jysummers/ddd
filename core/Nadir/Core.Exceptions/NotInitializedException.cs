using System;

namespace Nadir.Core
{
    [Serializable]
    public class NotInitializedException : Exception
    {
        public NotInitializedException()
            : base(BaseMessage)
        {
        }



        public NotInitializedException(string message)
            : base($"{BaseMessage} {message}")
        {
        }





        private const string BaseMessage = "Object is not initialized.";
    }
}
