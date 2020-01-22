using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dependency_life_cycle
{
    public interface Icounter
    {
      int Value { get; }
    }
    public class RandomCounter : Icounter
    {
        int value;
        static Random rnd = new Random();
        public RandomCounter()
        {
            value = rnd.Next(0, 1000000);
        }
        public int Value { get { return value; } }
    }
    public class CounterService
    {
        public Icounter Counter { get; }
        public CounterService(Icounter counter)
        {
            Counter = counter;
        }
    }
}
