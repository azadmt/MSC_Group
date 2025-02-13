using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain
{
    public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot
    {
        protected AggregateRoot()
        { }

        protected AggregateRoot(TId id) : base(id)
        {
        }

        private List<DomainEvent> _changes = new();

        protected void AddChanges(DomainEvent @event)
        {
            _changes.Add(@event);
        }

        public IReadOnlyCollection<DomainEvent> GetChanges()
        {
            return new ReadOnlyCollection<DomainEvent>(_changes);
        }
    }

    public interface IAggregateRoot
    {
        IReadOnlyCollection<DomainEvent> GetChanges();
    }
}
