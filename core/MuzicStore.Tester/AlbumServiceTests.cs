using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MuzicStore.Application.Albums;
using System;

namespace MuzicStore.Tester
{
    [TestClass]
    public class AlbumServiceTests
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Console.WriteLine("ClassInitialize");
        }



        [ClassCleanup]
        public static void ClassCleanup()
        {
            Console.WriteLine("ClassCleanup");
        }





        [TestMethod]
        [Priority(10)]
        public void should_generate_album()
        {
            Initializer.Provider.GetService<AlbumService>().CreateAlbum("Adele", "Adele (Deulxe Edition)");
        }



        [TestMethod]
        [Priority(20)]
        public void should_retrieve_album()
        {
            var album = Initializer.Provider.GetService<AlbumService>().ReadAlbum(Guid.Empty.ToString());
        }



        [TestMethod]
        [Priority(20)]
        public void should_not_update_name_more_than_once()
        {
            //var id = Guid.NewGuid();

            //var album = Factory.Create<Album>(id);
            //album.UpdateName("Mark");
            //Assert.ThrowsException<InvalidMutationException>(() => album.UpdateName("John"));

            throw new NotImplementedException();
        }
    }
}