using System;

namespace Nadir.Core
{
    [Serializable]
    public class InvalidMutationException : Exception
    {
        public InvalidMutationException()
            : base(BaseMessage)
        {
        }



        public InvalidMutationException(string message)
            : base($"{BaseMessage} {message}")
        {
        }





        private const string BaseMessage = "Aggregate mutation is invalid due to domain logic.";
    }
}