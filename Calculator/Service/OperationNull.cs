using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Service
{
    public class OperationNull : Operation
    {
        public override double GetResult()
        {
            return NumberB;
        }
    }
}
