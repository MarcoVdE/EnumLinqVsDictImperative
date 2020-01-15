using System.Collections.Generic;

namespace EnumLinqVsDictImperative
{
    public class DictionaryTest
    {
        public enum Enums
        {
            Item1 = 0,
            Item2 = 1,
            Item3 = 2,
            Item4 = 15,
        }
        
        public static readonly Dictionary<string, int> MyList = new Dictionary<string, int>
        {
            {"Item1", 1},
            {"Item2", 5},
            {"Item3", 10},
            {"Item4", 15},
        };

        public Enums currentEnum { get; set; }

        public DictionaryTest()
        {
            currentEnum = 0;
        }
        
    }
}