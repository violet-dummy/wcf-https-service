using System;
using System.IO;

namespace MyMathServiceLib
{
    public class MathService : IMathService
    {
        public int Add(int a, int b)
        {
            return (a + b);
        }

        public int Subtract(int a, int b)
        {
            return (a - b);
        }

        public int Multiply(int a, int b)
        {
            return (a * b);
        }

        public int Divide(int a, int b)
        {
            return ((b == 0) ? 0 : (a / b));
        }
    }
}
