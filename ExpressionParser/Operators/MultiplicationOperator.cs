﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser.Operators
{
    public class MultiplicationOperator : IOperator
    {
        public int Priority => 2;

        public Operand Execute(Operand operand1, Operand operand2)
        {
            return new Operand(operand1.Value * operand2.Value);
        }
    }
}