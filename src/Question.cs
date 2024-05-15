using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ahif_academy
{
    public abstract class Question
    {
        public abstract string Text { get; set; }
        public abstract string Subject { get; set; }
        public abstract void Draw(Grid grid);
        public abstract bool CheckAnswer(string  answer);
        


    }
}
