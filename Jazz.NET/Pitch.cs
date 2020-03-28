using System;

namespace Jazz.NET
{
    public class Pitch
    {
        public int MidiValue { get; }
        public Chroma Chroma { get; }

        public Pitch(int midiValue)
        {
            MidiValue = midiValue;
            Chroma = new Chroma(midiValue % 12);
        }
    }
}
