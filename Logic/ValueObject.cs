using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {

        public override bool Equals(object obj)
        {
            var other = obj as T;
            if (ReferenceEquals(other, null))
                return false;

            return EqualsCore(other);
        }
        
        public abstract bool EqualsCore(T obj);
        public abstract int GetHashCodeCore();

        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return false;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return true;

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }
    }
}
