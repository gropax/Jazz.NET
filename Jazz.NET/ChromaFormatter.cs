using System;
using System.Collections.Generic;
using System.Text;

namespace Jazz.NET
{
    public static class ChromaFormatter
    {
        public static IChromaFormatter Default => AmericanNaive;
        public static IChromaFormatter AmericanNaive => new AmericanNaiveChromaFormatter();
    }

    public interface IChromaFormatter
    {
        string Format(Chroma pitchClass);
    }

    public class AmericanNaiveChromaFormatter : IChromaFormatter
    {
        static Dictionary<int, string> _notations = new Dictionary<int, string>
        {
            { 0, "C" }, { 1, "C#/Db" }, { 2, "D" }, { 3, "D#/Eb" }, { 4, "E" }, { 5, "F" },
            { 6, "F#/Gb" }, { 7, "G" }, { 8, "G#/Ab" }, { 9, "A" }, { 10, "A#/Bb" }, { 11, "B" },
        };

        public string Format(Chroma chroma)
        {
            return _notations[chroma.Value];
        }
    }
}
