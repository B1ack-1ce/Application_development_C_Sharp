﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace HomeWork_05_W_P_F
{
    public class CalculatorArgs : EventArgs
    {
        public double Answer { get; set; }
        public CalculatorArgs()
        {
            
        }
    }
    internal class BaseCalculator
    {
        public double Result { get; private set; } = 0;
        public EventHandler<CalculatorArgs>? EventResult;

        private Stack<double> stackOfResults = new Stack<double>();
        public BaseCalculator() { }
        private void Calculation()
        {
            EventResult?.Invoke(this, new CalculatorArgs { Answer = Result });
        }
        public virtual bool Add(double value)
        {
            stackOfResults.Push(Result);
            Result += value;
            Calculation();
            return true;
        }
        public virtual bool Sub(double value)
        {
            stackOfResults.Push(Result);
            Result -= value;
            Calculation();
            return true;
        }
        public virtual bool Multi(double value)
        {
            stackOfResults.Push(Result);
            Result *= value;
            Calculation();
            return true;
        }
        public virtual bool Div(double value)
        {
            stackOfResults.Push(Result);
            Result /= value;
            Calculation();
            return true;
        }
        public bool Cancel()
        {
            if(stackOfResults.Count > 0)
            {
                Result = stackOfResults.Pop();
                Calculation();
                return true;
            }
            return false;
        }
        public bool Reset()
        {
            Result = 0;
            if (stackOfResults.Count == 0)
                return false;
            else
                stackOfResults = new Stack<double>();
            Calculation();
            return true;
        }
    }
}
