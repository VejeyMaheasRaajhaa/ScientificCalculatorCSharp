using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public static class DisplayComplexNumber
    {
        public static string DisplayComplex(this Complex x)
        {
            var operation = x.Imaginary > 0 ? "+" : "";
            String final = $"({x.Real} {operation}{x.Imaginary}j)";
            return final;
        }
    }
}