using Fasterflect;
using Nadir.Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Nadir.Core
{
    public abstract class Aggregate : Entity
    {
        protected Aggregate(AggregateId id)
        {
            Id = id;

            RegisterMutatorsInternal();
        }





        public void CreateAggregate(Guid guid)
        {
            if (!(Id is null))
                throw new InvalidMutationException("Id is already set and cannot be changed.");

            var id = new AggregateId(classification: GetType(), identification: guid);

            Raise(new AggregateCreated(id));
        }



        private void OnAggregateCreated(AggregateCreated affair)
        {
            Id = affair.Id;
        }



        protected internal void Raise<T>(T affair)
            where T : Affair
        {
            Changes.Add(affair);
            Mutate(affair);
        }



        public void Mutate<T>(T affair)
            where T : Affair
        {
            var methodName = Mutators.Single(m => m.Key == typeof(T)).Value;

            if (methodName is null)
                throw new InvalidMutationException($"No registered method found for {nameof(T)}.");

            var method = GetType().Method(methodName, new[] { typeof(T) }, Flags.InstancePrivate);

            method.Invoke(this, new[] { affair });
        }



        private void RegisterMutatorsInternal()
        {
            Mutators.Add(typeof(AggregateCreated), nameof(OnAggregateCreated));
            RegisterMutators(Mutators);
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





        protected abstract void RegisterMutators(IDictionary<Type, string> mutators);





        public AggregateId Id { get; private set; }



        public readonly IList<Affair> Changes = new List<Affair>();

        private readonly IDictionary<Type, string> Mutators = new Dictionary<Type, string>();
    }
}
