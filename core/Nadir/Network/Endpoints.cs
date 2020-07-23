namespace Nadir.Network
{
    public class Endpoints
    {
        public Endpoints(ITransitEndpoint transitEndpoint, IPersistorEndpoint perosistorEndpoint, IRetrieverEndpoint retrieverEndpoint)
        {
            TransitEndpoint = transitEndpoint;
            PersistorEndpoint = perosistorEndpoint;
            RetrieverEndpoint = retrieverEndpoint;
        }





        public ITransitEndpoint TransitEndpoint { get; set; }

        public IPersistorEndpoint PersistorEndpoint { get; set; }

        public IRetrieverEndpoint RetrieverEndpoint { get; set; }
    }
}
