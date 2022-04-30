using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public interface IExecutable
    {
        string Name { get; set; }
        string Surname { get; set; }
        string Sex { get; set; }
        int Age { get; set; }
        void Show();
    }
}
