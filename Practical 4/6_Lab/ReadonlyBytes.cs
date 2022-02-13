using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static hashes.ReadonlyBytesTests;

namespace hashes
{
    public class ReadonlyBytes : IEnumerable<byte>
    {
        private readonly byte[] Collection;
        private int hash = -1;

        public ReadonlyBytes(params byte[] list)
        {
            if (list == null) throw new ArgumentNullException();
            Collection = list;
        }

        public byte this[int index]
        {
            get
            {
                if (index < 0 || index >= Collection.Length) throw new IndexOutOfRangeException();
                return Collection[index];
            }
        }

        public override bool Equals(object obj)
        {
            if ((obj is DerivedFromReadonlyBytes)) return false;

            if (!(obj is ReadonlyBytes)) return false;
            var array = obj as ReadonlyBytes;
            if (array.GetHashCode() != this.GetHashCode() || this.Length != array.Length) return false;
            for (var i = 0; i < this.Length; i++)
                if (array[i] != this[i]) return false;
            return true;

        }


        public override int GetHashCode()
        {
            unchecked
            {
                if (hash != -1) return hash;
                var prime = 514229;
                hash = 1;
                for (int i = 0; i < Collection.Length; i++)
                {
                    hash *= prime;
                    hash ^= Collection[i];
                }
                return hash;
            }
        }

        protected bool Equals(ReadonlyBytes other)
        {
            return Equals(Collection, other.Collection);
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            str.Append('[' + string.Join(", ", Collection) + ']');
            return str.ToString();
        }

        public int Length { get { return Collection.Length; } }

        public IEnumerator<byte> GetEnumerator()
        {
            for (int i = 0; i < Collection.Length; i++)
                yield return Collection[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}