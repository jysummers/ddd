namespace Nadir.Core
{
    public class AggregateCreated : Affair
    {
        public AggregateCreated(AggregateId id)
        {
            Id = id;
        }



        public AggregateId Id { get; }
    }
}
