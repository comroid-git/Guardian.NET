using System;
using Guardian.Numerics;

namespace CustomTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Vector3f(0, 0, 0) + new Vector2<float>(1, 2);
            Console.WriteLine("First Result: " + result);
            //double[] resf = result.CastTuple<double>();
            //Console.WriteLine("Second Result: " + resf);
            var res2 = new QuaternionF(0, 0, 0, 1) + new QuaternionF(0, 1, 0, 30);
            Console.WriteLine("Third Result: " + res2);
        }
    }
}