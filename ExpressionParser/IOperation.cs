using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser
{
    public interface IOperation
    {
        public int Priority { get; }
        public int Execute();
    }
}
