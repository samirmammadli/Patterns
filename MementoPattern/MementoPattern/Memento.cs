using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoPattern
{
    class Memento
    {
        public string Buffer { get; set; }
        public Memento(string buffer)
        {
            Buffer = buffer.Clone() as string;
        }
    }

    class TextBoxHistory
    {
        private Stack<Memento> History { get; set; }
        private Stack<Memento> AfterCurrent { get; set; }
        public TextBoxHistory()
        {
            History = new Stack<Memento>();
            AfterCurrent = new Stack<Memento>();
        }

        public void Add(Memento buffer)
        {
            History.Push(buffer);
            AfterCurrent.Clear();
        }

        public Memento Back()
        {
            if (History.Count < 2) throw new ArgumentException("No Elements in buffer!");
            AfterCurrent.Push(History.Pop());
            return History.Peek();
        }

        public Memento Forward()
        {
            if (AfterCurrent.Count < 1) throw new ArgumentException("No Elements in buffer!");
            History.Push(History.Pop());
            return History.Peek();
        }
    }
}
