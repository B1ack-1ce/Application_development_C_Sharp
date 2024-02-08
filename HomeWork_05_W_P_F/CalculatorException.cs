using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HomeWork_05_W_P_F
{
    internal class CalculatorException : BaseCalculator
    {
        public override bool Add(double value)
        {
            return base.Add(value);
        }
        public override bool Sub(double value)
        {
            return base.Sub(value);
        }
        public override bool Multi(double value)
        {
            return base.Multi(value);
        }
        public override bool Div(double value)
        {
            if(value == 0)
            {
                MessageBox.Show("На ноль делить нельзя!");
                return false;
            }
            return base.Div(value);
        }
    }
}
