using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class EventHolder
    {
        public delegate void OperationCompletedEventHandler();
        public event OperationCompletedEventHandler OperationCompleted;
        public void OnOperationCompleted()
        {
            OperationCompleted?.Invoke();
        }
    }
}