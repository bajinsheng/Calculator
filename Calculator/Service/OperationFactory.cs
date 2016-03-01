using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Service
{
    public class OperationFactory
    {
        public static Operation CreateOperate(string operate)
        {
            Operation oper = null;
            switch(operate)
            {
                case " ":
                    oper = new OperationNull();
                    break;
                case "+":
                    oper=new OperationAdd();
                    break;
                case "-":
                    oper=new OperationSub();
                    break;
                case "*":
                    oper=new OperationMul();
                    break;
                case "/":
                    oper=new OperationDiv();
                    break;
            }
            return oper;
        }
    }
}
