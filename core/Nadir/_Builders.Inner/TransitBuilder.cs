using Microsoft.Extensions.DependencyInjection;

namespace Nadir
{
    public class TransitBuilder
    {
        public TransitBuilder(IServiceCollection services)
        {
            Services = services;
        }





        public IServiceCollection Services { get; private set; }
    }
}
