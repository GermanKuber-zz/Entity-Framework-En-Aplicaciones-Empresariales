using System;

namespace Market.Core
{

    public abstract class Entity
    {
        protected Entity()
        {
        }

        protected Entity(Guid id)
        {
            if (Equals(id, default(Guid)))
            {
                throw new ArgumentException("The ID cannot be the type's default value.", "id");
            }

            Id = id;
        }

        public Guid Id { get; set; }
    }
}