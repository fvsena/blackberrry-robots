using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackberry.Robots.Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new Blackberry.Robots.Ifood.Interface
                .BlackberryIfoodInterfaceLogin()
                .Login();
        }
    }
}
