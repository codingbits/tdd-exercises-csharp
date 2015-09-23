using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace roulette
{
    public class Field
    {
        public String FieldName{ get; private set;}
        public static Field ForNumber(int number)
        {
            return new Field{ FieldName=number.ToString()};
        }
        public static Field ODD = new Field { FieldName = "ODD" };

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Field)) return false;
            return Equals((Field)obj);
        }
        public bool Equals(Field obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.FieldName == this.FieldName;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return ((FieldName != null ? FieldName.GetHashCode() : 0));
            }
        }

    }

}
