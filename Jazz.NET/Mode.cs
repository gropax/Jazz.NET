using System;
using System.Collections.Generic;
using System.Text;

namespace Jazz.NET
{
    public class Mode
    {
        public ChromaSet Chromas { get; }
        public Scale Scale { get; }
        public int Degree { get; }
        public Chroma Root { get; }

        public Mode(ChromaSet chromas, Scale scale, int degree, Chroma root)
        {
            Chromas = chromas;
            Scale = scale;
            Degree = degree;
            Root = root;
        }
    }
}
