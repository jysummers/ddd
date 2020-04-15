using Microsoft.Extensions.DependencyInjection;
using MuzicStore.Application.Albums;
using MuzicStore.Domain.Albums;

namespace Nadir
{
    public static class AppExtension
    {
        public static void ConfigureMuzicStore(this CoreBuilder builder)
        {
            var services = builder.Services;



            builder.OnDaemonCreated((daemon, consumer, persistor) =>
            {
                daemon.AddWorker(new Worker<Album>(consumer, persistor));
            });



            services.AddScoped<AlbumService>();
        }
    }
}
