using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jazz.NET
{
    public class Scale
    {
        public ChromaSet Chromas { get; }
        public ScaleType Type { get; }
        public Chroma Root { get; }
        public Mode[] Modes { get; set; }

        public Scale(ChromaSet chromas, ScaleType type, Chroma root)
        {
            Chromas = chromas;
            Type = type;
            Root = root;
        }
    }



    public static class ScaleFormatter
    {
        public static IScaleFormatter Default => AmericanNaive;
        public static IScaleFormatter AmericanNaive => new AmericanNaiveScaleFormatter();
    }

    public interface IScaleFormatter
    {
        string Format(Scale pitchClass);
    }

    public class AmericanNaiveScaleFormatter : IScaleFormatter
    {
        public string Format(Scale chroma)
        {
            throw new NotImplementedException();
        }
    }
}
