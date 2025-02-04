using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    internal abstract class MyComplex : IDiffProd
    {
        protected abstract void GetInput();
        public abstract void Calculate(OperationType operationName, out string finalResult);
        public abstract void NotifyDifference();
        public abstract void NotifyProduct();
    }
}