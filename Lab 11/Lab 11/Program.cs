using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Lib;

namespace Lab_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestCollections collections = null;
            //collections.Show();
            //Console.Read();

            Options options = new Options();
            options.Menu(ref collections);
           
            
        }
    }
}
