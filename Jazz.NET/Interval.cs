using System;
using System.Collections.Generic;
using System.Text;

namespace Jazz.NET
{
    public class Interval
    {
        public int Value { get; }

        public Interval(int value)
        {
            Value = value;
        }
    }


    //public interface IIntervalFormatter
    //{
    //    string Format(Interval interval);
    //}

    //public class EnglishIntervalFormatter : IIntervalFormatter
    //{
    //    public string Format(Interval interval)
    //    {
    //        switch (interval.Value)
    //    }
    //}
}
