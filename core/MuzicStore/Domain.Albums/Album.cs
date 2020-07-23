using Nadir.Core;
using System;
using System.Collections.Generic;

namespace MuzicStore.Domain.Albums
{
    public class Album : Aggregate
    {
        public Album(AggregateId id)
            : base(id)
        {
        }





        public void UpdateName(string name)
        {
            if (!string.IsNullOrWhiteSpace(Name))
                throw new InvalidMutationException("Name is already set.");

            Raise(new NameUpdated(name: name));
        }



        public void UpdateTitle(string title)
        {
            Raise(new TitleUpdated(title: title));
        }





        private void OnNameCreated(NameUpdated affair)
        {
            Name = affair.Name;
        }



        private void OnTitleUpdated(TitleUpdated affair)
        {
            Title = affair.Title;
        }





        protected override void RegisterMutators(IDictionary<Type, string> mutators)
        {
            mutators.Add(typeof(NameUpdated), nameof(OnNameCreated));
            mutators.Add(typeof(TitleUpdated), nameof(OnTitleUpdated));
        }





        public string Name { get; private set; }

        public string Title { get; private set; }
    }
}
