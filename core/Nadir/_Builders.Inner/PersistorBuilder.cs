using Microsoft.Extensions.DependencyInjection;

namespace Nadir
{
    public class PersistorBuilder
    {
        public PersistorBuilder(IServiceCollection services)
        {
            Services = services;
        }





        public IServiceCollection Services { get; private set; }
    }
}
