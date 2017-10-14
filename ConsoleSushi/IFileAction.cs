using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSushi
{
    public interface IFileActions 
    {
        void ReadData(string source);
        void WriteData(string destination);
    }
}
