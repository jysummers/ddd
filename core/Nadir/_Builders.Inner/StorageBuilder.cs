using Microsoft.Extensions.DependencyInjection;

namespace Nadir
{
    public class StorageBuilder
    {
        public StorageBuilder(IServiceCollection services)
        {
            Services = services;
        }





        public IServiceCollection Services { get; private set; }
    }
}
