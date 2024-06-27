using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Blackberry.Robots.Ifood.Request
{
    internal abstract class BaseRequest
    {
        public CookieContainer cookieContainer = new CookieContainer();
        public HttpWebRequest requestBase;
        public HttpWebResponse responseBase;

        protected void AddPostData(string content)
        {
            byte[] data = Encoding.ASCII.GetBytes(content);
            requestBase.ContentLength = data.Length;
            using (Stream stream = requestBase.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
        }

        protected string GetResponseBody()
        {
            string content = null;
            if (responseBase != null)
            {
                Stream stream = responseBase.GetResponseStream();
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    content = reader.ReadToEnd();
                }
            }
            return content;
        }
    }
}
