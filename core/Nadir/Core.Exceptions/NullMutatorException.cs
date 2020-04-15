using System;

namespace Nadir.Core
{
    [Serializable]
    public class NullMutatorException : Exception
    {
        public NullMutatorException()
            : base(BaseMessage)
        {
        }





        private const string BaseMessage = "Aggregate must be mutated after raising an event.";
    }
}
