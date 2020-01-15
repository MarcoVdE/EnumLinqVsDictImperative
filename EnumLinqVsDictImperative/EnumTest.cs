using System;
using System.Linq;

namespace EnumLinqVsDictImperative
{
    public class EnumTest
    {
        public enum Enums
        {
            Item1 = 1,
            Item2 = 5,
            Item3 = 10,
            Item4 = 15,
        }
        
        public Enums currentEnum { get; set; }

        public EnumTest()
        {
            this.currentEnum = Enums.Item1;
        }

        public EnumTest incrementEnum()
        {
            this.currentEnum = Enum.GetValues(typeof(Enums))
                .Cast<Enums>()
                .Where(x => x > this.currentEnum)
                .DefaultIfEmpty(this.currentEnum) //if empty, it must be max. 
                .Min();
            return this;
        }
        
        public EnumTest incrementEnumParallel()
        {
            this.currentEnum = Enum.GetValues(typeof(Enums))
                .Cast<Enums>()
                .AsParallel()
                .Where(x => x > this.currentEnum)
                .DefaultIfEmpty(this.currentEnum) //if empty, it must be max. 
                .Min();
            return this;
        }
        
    }
}