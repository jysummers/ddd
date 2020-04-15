using Nadir;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class LibraryExtension
    {
        public static AppBuilder ConfigureCore(this IServiceCollection services, Action<CoreBuilder> configure)
        {
            var builder = new AppBuilder(services, configure)
                .PreBuild();

            return builder;
        }
    }
}
