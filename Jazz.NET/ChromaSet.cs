using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Jazz.NET
{
    public struct ChromaSet : IEquatable<ChromaSet>
    {
        HashSet<Chroma> Chromas { get; }
        int HashCode { get; }

        public ChromaSet(IEnumerable<Chroma> chromas)
        {
            Chromas = new HashSet<Chroma>(chromas);

            var hashCode = new HashCode();
            foreach (var chroma in Chromas)
                hashCode.Add(chroma);

            HashCode = hashCode.ToHashCode();
        }

        public bool Equals(ChromaSet other)
        {
            return HashCode == other.HashCode;
        }

        public override int GetHashCode()
        {
            return HashCode;
        }
    }
}
