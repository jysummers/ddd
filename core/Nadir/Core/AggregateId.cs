using System;

namespace Nadir.Core
{
    public class AggregateId : Identity
    {
        public AggregateId(Type classification, Guid identification)
        {
            Classification = classification;
            Identification = identification;
        }



        public override string ToString()
        {
            return $"{Classification.FullName}-{Identification:N}".ToUpper();
        }





        public Type Classification { get; }

        public Guid Identification { get; }
    }
}
