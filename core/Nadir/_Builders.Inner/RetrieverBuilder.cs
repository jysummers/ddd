using Microsoft.Extensions.DependencyInjection;

namespace Nadir
{
    public class RetrieverBuilder
    {
        public RetrieverBuilder(IServiceCollection services)
        {
            Services = services;
        }





        public IServiceCollection Services { get; private set; }
    }
}
