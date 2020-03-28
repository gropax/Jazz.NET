using System;
using System.Collections.Generic;
using System.Text;

namespace Jazz.NET
{
    public class Mode
    {
        public RootedChromaSet Chromas { get; }
        public Scale Scale { get; }
        public int Degree { get; }

        public Mode(RootedChromaSet chromas, Scale scale, int degree)
        {
            Chromas = chromas;
            Scale = scale;
            Degree = degree;
        }
    }
}
