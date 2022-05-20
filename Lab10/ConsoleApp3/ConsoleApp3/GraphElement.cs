using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class GraphElement
    {
        public int Number { get; set; }
        public bool Check { get; set; }

        public GraphElement NextElement;
        public GraphElement(int number, bool check, GraphElement next)
        {
            Number = number;
            Check = check;
            NextElement = next;
        }
    }
}
