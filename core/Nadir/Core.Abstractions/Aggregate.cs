using Nadir.Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.IO;

namespace Nadir.Core
{
    public abstract class Aggregate : Entity
    {
        protected Aggregate(AggregateId id)
        {
            Id = id;
        }





        public void CreateAggregate(Guid guid)
        {
            if (!(Id is null))
                throw new InvalidMutationException("Id is already set and cannot be changed.");

            var id = new AggregateId(classification: GetType(), identification: guid);

            Raise(new AggregateCreated(id), OnAggregateCreated);
        }



        private void OnAggregateCreated(AggregateCreated affair)
        {
            Id = affair.Id;
        }



        protected internal void Raise<T>(T affair, Apply<T> mutator)
            where T : Affair
        {
            if (mutator == null)
                throw new NullMutatorException();

            Changes.Add(affair);
            mutator(affair);
        }



        public static byte[] Pack<T>(T aggregate)
            where T : Aggregate
        {
            using (var stream = new MemoryStream())
            using (var writer = new BsonDataWriter(stream))
            {
                var serializer = JsonSerializer.CreateDefault(new AggregateJsonSerializerSettings());

                serializer.Serialize(writer, aggregate);

                return stream.ToArray();
            }
        }



        public static T Unpack<T>(byte[] package)
            where T : Aggregate
        {
            using (var stream = new MemoryStream(package))
            using (var reader = new BsonDataReader(stream))
            {
                var serializer = JsonSerializer.CreateDefault(new AggregateJsonSerializerSettings());

                return serializer.Deserialize<T>(reader);
            }
        }





        public AggregateId Id { get; private set; }



        public readonly IList<Affair> Changes = new List<Affair>();
    }
}
