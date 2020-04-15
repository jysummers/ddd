namespace Nadir.Network
{
    public class Endpoints
    {
        public Endpoints(ITransitEndpoint transitEndpoint, IStorageEndpoint storageEndpoint)
        {
            TransitEndpoint = transitEndpoint;
            StorageEndpoint = storageEndpoint;
        }





        public ITransitEndpoint TransitEndpoint { get; set; }

        public IStorageEndpoint StorageEndpoint { get; set; }
    }
}
