using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Jazz.NET
{
    [DebuggerDisplay("{ToString()}")]
    public struct Chroma : IEquatable<Chroma>
    {
        private static Chroma[] _all = Enumerable.Range(0, 12).Select(i => new Chroma(i)).ToArray();
        public static IEnumerable<Chroma> All => _all.AsEnumerable();


        public int Value { get; }

        internal Chroma(int value)
        {
            if (value < 0 || value >= 12)
                throw new ArgumentOutOfRangeException("Chroma value range from 0 to 11");
            Value = value;
        }

        public Chroma Transpose(Interval interval)
        {
            return new Chroma((Value + interval.Value) % 12);
        }

        public bool Equals(Chroma other)
        {
            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }

        public override string ToString()
        {
            return ToString(null);
        }

        public string ToString(IChromaFormatter formatter = null)
        {
            formatter ??= ChromaFormatter.Default;
            return formatter.Format(this);
        }
    }
}
