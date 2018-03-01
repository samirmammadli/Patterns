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
        private List<Memento> Storage { get; set; }
        private int currenIndex;
        public TextBoxHistory()
        {
            Storage = new List<Memento>();
            currenIndex = -1;
        }
        public void Add(Memento buffer)
        {
            if (currenIndex == Storage.Count - 1)
                Storage.Add(buffer);
            else
            {
                Storage.RemoveRange(currenIndex + 1, Storage.Count - currenIndex - 1);
                Storage.Add(buffer);
            }
            currenIndex++;
        }

        public Memento Undo()
        {
            if (currenIndex == 0) return Storage[currenIndex];
            else
                return Storage[--currenIndex];
        }

        public Memento Redo()
        {
            if (currenIndex == Storage.Count - 1) return Storage[currenIndex];
            else return Storage[++currenIndex];
        }
    }
}
