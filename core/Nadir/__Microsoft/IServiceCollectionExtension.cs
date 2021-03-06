﻿using Nadir;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtension
    {
        public static AppBuilder ConfigureCore(this IServiceCollection services, Action<CoreBuilder> configure)
        {
            var builder = new AppBuilder(services, configure)
                .PreBuild();

            return builder;
        }
    }
}
