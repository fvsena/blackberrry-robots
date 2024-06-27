using Blackberry.Robots.Facebook.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackberry.Robots.Interface
{
    class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string caminho = $"{System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6)}\\config.txt";
                new FacebookShare(caminho).SharePosts();
            }
            
        }
    }
}
