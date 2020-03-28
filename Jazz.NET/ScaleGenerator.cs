using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jazz.NET
{
    public class ScaleGenerator
    {
        public ScaleType Type { get; }
        public Interval[] Intervals { get; }

        public static ScaleGenerator Create(ScaleType type, int[] intervals)
        {
            return new ScaleGenerator(type, intervals.Select(v => new Interval(v)).ToArray());
        }

        public ScaleGenerator(ScaleType type, Interval[] intervals)
        {
            Type = type;
            Intervals = intervals;
        }

        public Scale Generate(Chroma chroma)
        {
            var chromas = Intervals.Select(i => chroma.Transpose(i)).ToArray();
            var chromaSet = new ChromaSet(chromas);
            var scale = new Scale(chromaSet, Type, chroma);
            var modes = chromas.Select((c, i) => new Mode(chromaSet.Rooted(c), scale, i + 1)).ToArray();
            scale.Modes = modes.ToArray();
            return scale;
        }
    }
}
