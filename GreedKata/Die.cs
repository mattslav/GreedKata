using System;

namespace GreedKata
{
    public class Die : IEquatable<Die>
    {
        public int Value { get; private set; }

        public Die(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static bool operator ==(Die left, Die right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Die left, Die right)
        {
            return !left.Equals(right);
        }

        public bool Equals(Die other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return other.Value == Value;
        }
        
        public override bool Equals(Object other)
        {
            if (other == null)
            {
                return false;
            }

            var otherDie = other as Die;
            if ((Object)otherDie == null)
            {
                return false;
            }

            return Value == otherDie.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

    }
}
