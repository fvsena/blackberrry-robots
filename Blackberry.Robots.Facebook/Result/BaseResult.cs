using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackberry.Robots.Facebook.Result
{
    public class BaseResult
    {
        public bool ProcessOk { get; set; }
        public string MsgError { get; set; }
        public string MsgCatch { get; set; }
    }
}
