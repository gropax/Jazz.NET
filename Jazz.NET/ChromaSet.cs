using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Jazz.NET
{
    public class ChromaSet : IEquatable<ChromaSet>
    {
        public HashSet<Chroma> Chromas { get; }
        protected int HashCode { get; }

        public ChromaSet(IEnumerable<Chroma> chromas)
            : this(new HashSet<Chroma>(chromas))
        { }

        public ChromaSet(HashSet<Chroma> chromas)
            : this(chromas, ComputeHashCode(chromas))
        { }

        protected internal ChromaSet(HashSet<Chroma> chromas, int hashCode)
        {
            Chromas = chromas;
            HashCode = hashCode;
        }

        public RootedChromaSet Rooted(Chroma root)
        {
            if (!Chromas.Contains(root))
                throw new ArgumentException("Root should belong to chromas.");

            return new RootedChromaSet(root, Chromas);
        }

        public bool Subsume(ChromaSet other)
        {
            return Chromas.All(c => other.Chromas.Contains(c));
        }

        public bool Equals(ChromaSet other)
        {
            return HashCode == other.HashCode;
        }

        public override int GetHashCode()
        {
            return HashCode;
        }

        public static int ComputeHashCode(HashSet<Chroma> chromas)
        {
            var hashCode = new HashCode();
            foreach (var chroma in chromas)
                hashCode.Add(chroma);
            return hashCode.ToHashCode();
        }
    }


    public class RootedChromaSet : ChromaSet, IEquatable<RootedChromaSet>
    {
        public Chroma Root { get; }

        public RootedChromaSet(Chroma root, IEnumerable<Chroma> chromas)
            : this(root, new HashSet<Chroma>(chromas))
        { }

        public RootedChromaSet(Chroma root, HashSet<Chroma> chromas)
            : this(root, chromas, ComputeHashCode(root, chromas))
        { }

        RootedChromaSet(Chroma root, HashSet<Chroma> chromas, int hashCode)
            : base(chromas, hashCode)
        {
            if (!Chromas.Contains(root))
                throw new ArgumentException("Root should belong to chromas.");

            Root = root;
        }

        public ChromaSet Unrooted()
        {
            return new ChromaSet(Chromas);
        }

        public bool Subsume(RootedChromaSet other)
        {
            return Root.Equals(other.Root) && Chromas.All(c => other.Chromas.Contains(c));
        }

        public bool Equals(RootedChromaSet other)
        {
            return HashCode == other.HashCode;
        }

        public override int GetHashCode()
        {
            return HashCode;
        }

        public static int ComputeHashCode(Chroma root, HashSet<Chroma> chromas)
        {
            var hashCode = new HashCode();
            hashCode.Add(root.Value + 12);
            foreach (var chroma in chromas)
                hashCode.Add(chroma);
            return hashCode.ToHashCode();
        }
    }
}
