using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jazz.NET
{
    public enum ScaleType
    {
        Chromatic,
        Major,
        HarmonicMinor,
        AscMelodicMinor,
        WholeTone,
        WholeHalfDiminished,
        HalfWholeDiminished,
        //MelodicMinor,
    }

    public class Scales
    {
        public Scale[] Generate()
        {
            return GetScaleGenerators().SelectMany(g =>
                Chroma.All.Select(c => g.Generate(c)))
                .ToArray();
        }

        public ScaleGenerator[] GetScaleGenerators()
        {
            var generators = new List<ScaleGenerator>();

            generators.Add(ScaleGenerator.Create(ScaleType.Chromatic,
                new [] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }));

            generators.Add(ScaleGenerator.Create(ScaleType.Major,
                new [] { 0, 2, 2, 1, 2, 2, 2 }));

            generators.Add(ScaleGenerator.Create(ScaleType.HarmonicMinor,
                new [] { 0, 2, 1, 2, 2, 1, 3 }));

            generators.Add(ScaleGenerator.Create(ScaleType.AscMelodicMinor,
                new [] { 0, 2, 1, 2, 2, 2, 2 }));

            generators.Add(ScaleGenerator.Create(ScaleType.WholeTone,
                new [] { 0, 2, 2, 2, 2, 2 }));

            generators.Add(ScaleGenerator.Create(ScaleType.WholeHalfDiminished,
                new [] { 0, 2, 1, 2, 1, 2, 1, 2, }));

            generators.Add(ScaleGenerator.Create(ScaleType.HalfWholeDiminished,
                new [] { 0, 1, 2, 1, 2, 1, 2, 1, }));

            return generators.ToArray();
        }
    }
}
