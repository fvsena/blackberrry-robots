using Blackberry.Robots.Facebook.Browsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackberry.Robots.Facebook.Process
{
    public abstract class BaseProcess
    {
        public int Step { get; set; }
        public GoogleChrome Chrome { get; set; }
        public string BaseUrl { get; set; }
    }
}
