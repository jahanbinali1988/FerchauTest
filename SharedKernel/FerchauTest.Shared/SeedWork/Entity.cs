using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerchauTest.Shared.SeedWork
{
	/// <summary>
	/// Base class for entities.
	/// </summary>
	[Serializable]
	public abstract class Entity<TKey>
	{
		private List<IDomainEvent> _domainEvents;

		/// <summary>
		/// Domain events occurred.
		/// </summary>
		public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

		/// <summary>
		/// Add domain event.
		/// </summary>
		/// <param name="domainEvent"></param>
		protected void AddDomainEvent(IDomainEvent domainEvent)
		{
			_domainEvents ??= new List<IDomainEvent>();
			_domainEvents.Add(domainEvent);
		}

		/// <summary>
		/// Clear domain events.
		/// </summary>
		public void ClearDomainEvents()
		{
			_domainEvents?.Clear();
		}

		public void MarkAsUpdated()
		{
			ModifiedAt = DateTimeOffset.Now;
		}

		public void MarkAsDeleted()
		{
			ModifiedAt = DateTimeOffset.Now;
			IsDeleted = true;
		}

		public TKey Id { get; protected set; }

		public bool IsDeleted { get; private set; }

		/// <summary>
		/// Row version
		/// </summary>
		public byte[] Version { get; protected set; }

		/// <summary>
		/// Modification date and time of this entity
		/// </summary>
		public DateTimeOffset? ModifiedAt { get; protected set; }


		public DateTimeOffset CreatedAt { get; protected set; }

	}

	public abstract class Entity : Entity<long>
	{

	}
}
