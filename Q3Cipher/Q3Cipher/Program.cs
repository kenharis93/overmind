using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q3Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            CodeBookCipher cipher = new CodeBookCipher();
            Console.WriteLine(cipher.encrypt("This is a test message"));
            Console.WriteLine(cipher.decrypt("155 408 141 821 286 692 821 559 286 692 692 141 117 286"));
            Console.ReadLine();

        }
    }
}
