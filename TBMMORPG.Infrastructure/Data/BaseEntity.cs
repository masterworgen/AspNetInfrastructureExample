using System;

namespace TBMMORPG.Infrastructure.Data
{
    public abstract class BaseEntity : BaseDomain
    {
        public int Id { get; set; }

        public override bool Equals(object other)
        {
            return Equals(other as BaseEntity);
        }

        public virtual bool Equals(BaseEntity other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (!IsTransient(this) &&
                !IsTransient(other) &&
                Equals(Id, other.Id))
            {
                var otherType = other.GetUnproxiedType();
                var thisType = GetUnproxiedType();
                return thisType.IsAssignableFrom(otherType) ||
                       otherType.IsAssignableFrom(thisType);
            }

            return false;
        }

        public Type GetUnproxiedType()
            => GetType();

        public override int GetHashCode()
            => Equals(Id, default(int)) ? base.GetHashCode() : Id.GetHashCode();

        private static bool IsTransient(BaseEntity obj)
            => obj != null && Equals(obj.Id, default(int));
    }
}
