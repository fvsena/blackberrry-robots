using Blackberry.Robots.Ifood.Result;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Blackberry.Robots.Ifood.Request
{
    internal class LoginRequest : BaseRequest
    {
        internal LoginResult Login()
        {
            LoginResult result = new LoginResult();
            if (Request_HomePage(out responseBase))
            {
                responseBase.Close();
                if (Request_Login(out responseBase))
                {

                }
            }
            return result;
        }

        private bool Request_HomePage(out HttpWebResponse response)
        {
            response = null;

            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://portal.ifood.com.br/");
                request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                request.KeepAlive = true;
                request.Headers.Add("Upgrade-Insecure-Requests", @"1");
                request.UserAgent = "Chrome/80.0.3987.149";
                request.Headers.Add("Sec-Fetch-Dest", @"document");
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
                request.Headers.Add("Sec-Fetch-Site", @"none");
                request.Headers.Add("Sec-Fetch-Mode", @"navigate");
                request.Headers.Add("Sec-Fetch-User", @"?1");
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7");

                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
                else return false;
            }
            catch (Exception)
            {
                if (response != null) response.Close();
                return false;
            }

            return true;
        }

        private bool Request_Login(out HttpWebResponse response)
        {
            response = null;

            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://portal-api.ifood.com.br/next-web-bff/access_token");
                request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                request.KeepAlive = true;
                request.Accept = "application/json, text/plain, */*";
                request.Headers.Add("Sec-Fetch-Dest", @"empty");
                request.Headers.Set(HttpRequestHeader.Authorization, "Basic ZmVsaXBlLnNlbmFAYmxhY2tiZXJyeWJldmVyYWdlcy5jb20uYnI6RnZzZW5AMTk5Mg==");
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.149 Safari/537.36";
                request.ContentType = "application/json;charset=UTF-8";
                request.Headers.Add("Origin", @"https://portal.ifood.com.br");
                request.Headers.Add("Sec-Fetch-Site", @"same-site");
                request.Headers.Add("Sec-Fetch-Mode", @"cors");
                request.Referer = "https://portal.ifood.com.br/login";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7");

                request.Method = "POST";
                request.ServicePoint.Expect100Continue = false;

                string body = @"{""recaptchaToken"":""03AHaCkAZ38pTp0nYgNcHL--tOKX2sAJ72N8g7VjXYgryVOPtNbGOyIqM2uZsng_yknghlkt78pztU7XpSzVf0pxIfhaiAnlCMx5E6ZatRoPiDTuIrRb5aO77GbdvI_E1U-nz3Hk4t50iUv7V_lPbOo9iUUzTFnQSvbrozEfg_0GzGyQsTYYXDdITBhFzGsdWFuk_uhmQwq1vobVJzAgqmlkqYmVn1gVDOY6_f67Tt-j8z1LrdD26GgYXw2oQlV449b-BekHbNe_1w5LllI_b33SMSK-4OpRaP3IjlBjWNHPATItv1dZcbjTD_c6g0MB76_1GWQ9Obmz8fgeAVLvyDBuqAkvlBf7OU0QQjhv0uytmJQq5O6e379lwCfBrib0G2G4PdwKEKECk2Xoyd6KwcrchYTkcUHaZBRw""}";
                byte[] postBytes = System.Text.Encoding.UTF8.GetBytes(body);
                request.ContentLength = postBytes.Length;
                Stream stream = request.GetRequestStream();
                stream.Write(postBytes, 0, postBytes.Length);
                stream.Close();

                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
                else return false;
            }
            catch (Exception)
            {
                if (response != null) response.Close();
                return false;
            }

            return true;
        }
    }
}
