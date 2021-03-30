using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }

        public override bool Equals(object obj)
        {
            var other = obj as Entity;
            if (ReferenceEquals(other, null) || ReferenceEquals(this, other)
                || GetType() != obj.GetType()
                || Id == Guid.Empty || other.Id == Guid.Empty)
                return false;

            return true;
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return false;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return true;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
    }
}
