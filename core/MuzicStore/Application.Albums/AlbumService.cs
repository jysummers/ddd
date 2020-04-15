using MuzicStore.Domain.Albums;
using Nadir;
using Nadir.Storage;
using Nadir.Transit;
using System;

namespace MuzicStore.Application.Albums
{
    public class AlbumService
    {
        public AlbumService(IFactory factory, IBus bus, IStorage storage)
        {
            Factory = factory;
            Bus = bus;
            Storage = storage;
        }





        public Album GetAlbum(string id)
        {
            var album = Storage.Load<Album>(Guid.Parse(id));

            return album;
        }



        public void CreateNewAlbum(string name, string title)
        {
            var album = Factory.Create<Album>(Guid.NewGuid());

            album.UpdateName(name);
            album.UpdateTitle(title);

            Bus.Dispatch(album);
        }



        public void UpdateTitle(string id, string title)
        {
            var album = Storage.Load<Album>(Guid.Parse(id));

            album.UpdateTitle(title);

            Bus.Dispatch(album);
        }



        public void UpdateName(string id, string name)
        {
            var album = Storage.Load<Album>(Guid.Parse(id));

            album.UpdateName(name);

            Bus.Dispatch(album);
        }





        private readonly IFactory Factory;

        private readonly IBus Bus;

        private readonly IStorage Storage;
    }
}
