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
        public void should_create_new_album()
        {
            DatabaseConnections.Provider.GetService<AlbumService>().CreateNewAlbum("Adele", "Adele (Deulxe Edition)");
        }



        [TestMethod]
        [Priority(20)]
        public void should_load_aggregate()
        {
            var album = DatabaseConnections.Provider.GetService<AlbumService>().GetAlbum(Guid.Empty.ToString());
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