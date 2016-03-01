using Calculator.Command;
using Calculator.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModel
{
    public class MainPageViewModel:ViewModelBase
    {
        private string operationResult;//每一次运算后的结果

        public string OperationResult
        {
            get { return operationResult; }
            set
            { this.SetProperty(ref this.operationResult, value); }
        }

        private string inputInformation;//输出中间过程信息

        public string InputInformation
        {
            get { return inputInformation; }
            set
            { this.SetProperty(ref this.inputInformation, value); }
        }

        private string operationLabel;//操作符

        public string OperationLabel
        {
            get { return operationLabel; }
            set
            { this.SetProperty(ref this.operationLabel, value); }
        }



        private double number;//运算结果

        public double Number
        {
            get { return number; }
            set
            { this.SetProperty(ref this.number, value); }
        }

        public DelegateCommand KeyCommand { get; set; }//数字按键命令
        public DelegateCommand CalculationCommand { get; set; }//执行运算命令
        public DelegateCommand ResultCommand { get; set; }//等于,计算最终结果命令
        public DelegateCommand DeleteCommand { get; set; }//清空结果命令

        public MainPageViewModel()//初始化
        {
            Number=0;
            OperationLabel =" ";
            OperationResult="0";
            KeyCommand = new DelegateCommand(key);
            CalculationCommand = new DelegateCommand(Calculation);
            ResultCommand = new DelegateCommand(Result);
            DeleteCommand = new DelegateCommand(Delete);

        }

        private void key(Object paramater)//数字按键
        {
            string s = paramater as string;
            if (OperationLabel == "=" || OperationResult=="0")
            {
                OperationResult = s;
                InputInformation = s;
                OperationLabel =" ";
            }
            else
            {
                OperationResult = OperationResult + s;
                InputInformation = InputInformation + s;
            }
         }

        private void Calculation(Object paramater)//执行运算
        {
            string s = paramater as string;
            if (OperationLabel != "=")
            {
                OperationNum(OperationLabel);
            }
            InputInformation = Number.ToString() + s;
            OperationResult = " ";
            OperationLabel = s;
          

        }



        private void Result()//等于,计算最终结果
        {
            
            OperationNum(OperationLabel);
            OperationResult = Number.ToString();
            InputInformation=" ";
            OperationLabel ="=";
           
        }

        private void Delete()//清空结果
        {
            OperationResult="0";
            InputInformation="";
            OperationLabel = " ";
            Number= 0; 

        }

        private void OperationNum(string s)
        {
            Operation oper;
            oper = OperationFactory.CreateOperate(s);
            oper.NumberA = Number;
            oper.NumberB =  double.Parse(OperationResult);
            Number = oper.GetResult();

        }
    }
}
