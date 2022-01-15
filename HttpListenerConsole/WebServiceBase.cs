using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpListenerConsole
{
    //HTTP STATUS codes.
    //https://developer.mozilla.org/pt-PT/docs/Web/HTTP/Status
    //https://pt.wikipedia.org/wiki/Lista_de_c%C3%B3digos_de_estado_HTTP

    internal abstract class WebServiceBase
    {
        private int _port = 8888;
        private HttpListener _listener = null;

        private bool _keepGoing = true;
        private Task _mainTask = null;

        public void StartWebServer(int port)
        {
            _port = port;
            _listener = new HttpListener { Prefixes = { $"http://localhost:{_port}/" } };

            if (_mainTask != null && !_mainTask.IsCompleted)
                return; //Already started

            _mainTask = Task.Run(() => MainLoopActionsAsync()); //start main loop
            _mainTask.Wait();
        }

        public void StopWebServer()
        {
            _keepGoing = false;
            lock (_listener)
            {
                //Use a lock so we don't kill a request that's currently being processed
                _listener.Stop();
            }
        }

        private async Task MainLoopActionsAsync()
        {
            System.Console.WriteLine("Listening at port:" + _port.ToString());

            _listener.Start();

            while (_keepGoing)
            {
                try
                {
                    HttpListenerContext context = await _listener.GetContextAsync(); // wait and receive requests
                    //or
                    //Task<HttpListenerContext> task  = _listener.GetContextAsync();
                    //task.Wait();
                    //HttpListenerContext context = task.Result;

                    lock (_listener)
                    {
                        if (_keepGoing)
                            Task.Run(() => ProcessRequestActionAsync(context)); // process request in another thread
                        //Task task = ProcessRequestActionAsync(context);
                    }
                }
                catch (Exception ex)
                {
                    if (ex is HttpListenerException)
                        return; //this gets thrown when the listener is stopped
                }
            }

        }

        private Task ProcessRequestActionAsync(HttpListenerContext context)
        {
            ProcessRequestAction(context);
            return null;
        }

        private void ProcessRequestAction(HttpListenerContext context)
        {
            Console.Clear();

            Console.WriteLine("Init...");
            Console.WriteLine("Verb: {0}", context.Request.HttpMethod);
            Console.WriteLine("Path: {0}", context.Request.Url.AbsolutePath);
            Console.WriteLine("RawUrl: {0}", context.Request.RawUrl);
            
            ShowHeaders(context);
            ShowBody(context);

            Console.WriteLine("Process START.");

            using (HttpListenerResponse response = context.Response)
            {
                try
                {
                    byte retValue = ProcessAnyVerbPath(context); //process 

                    if (retValue != 0)
                    {
                        string msg = string.Format("Path or Verb Not Defined. Verb ={0}, Path ={1}", context.Request.HttpMethod, context.Request.Url.AbsolutePath);
                        Console.WriteLine("Process ERROR: {0}", msg);
                        response.StatusCode = 404;
                        response.ContentType = "application/json";
                        byte[] buffer = Encoding.UTF8.GetBytes(msg);
                        response.ContentLength64 = buffer.Length;
                        response.OutputStream.Write(buffer, 0, buffer.Length);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Process ERROR:" + ex.Message);
                    response.StatusCode = 500;
                    response.ContentType = "application/json";
                    byte[] buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(ex));
                    response.ContentLength64 = buffer.Length;
                    response.OutputStream.Write(buffer, 0, buffer.Length);
                }

                Console.WriteLine("Process FINISHED.");
            }
        }

        private void ShowHeaders(HttpListenerContext context)
        {
            Console.WriteLine("Header list Begin:");

            foreach (string item in context.Request.Headers)
                Console.WriteLine("KEY=" + item + ", VALUE=" + context.Request.Headers[item]);

            Console.WriteLine("Header list End:");
        }

        private void ShowBody(HttpListenerContext context)
        {

            if (context.Request.HasEntityBody)
            {
                string contentType;
                if (context.Request.ContentType != null)
                    contentType = context.Request.ContentType;
                else
                    contentType = "undefined";

                Console.WriteLine("body content type: {0}", contentType);
                Console.WriteLine("body data content length: {0}", context.Request.ContentLength64);

                Console.WriteLine("Body list Begin:");

                Stream stream = context.Request.InputStream;
                Encoding encoding = context.Request.ContentEncoding;
                StreamReader streamReader = new StreamReader(stream, encoding);
                string body = streamReader.ReadToEnd();
                Console.WriteLine(body);
                streamReader.Close();
                stream.Close();

                Console.WriteLine("Body list End:");
            }
        }

        protected void SetHeaders(HttpListenerResponse response)
        {
            //response.ContentType = "Content-Type text/xml; charset=utf-8";

            //response.AddHeader("Keep-Alive", "timeout=5");
            //response.AddHeader("Keep-Alive", "max=200");
            //response.AddHeader("Transfer-Encoding", "chunked");
            //response.AddHeader("X-Content-Type-Options", "nosniff");
            //response.AddHeader("Connection", "Keep-Alive");
            ////response.AddHeader("Date", "Fri");
            ////response.AddHeader("Date", "04 Dec 2020 15:02:38 GMT");
            //response.AddHeader("Referrer-Policy", "no-referrer");
            //response.AddHeader("X-Frame-Options", "SAMEORIGIN");
            //response.AddHeader("Cache-Control", "no-cache=\"set-cookie\"");
            //response.AddHeader("Cache-Control", "\"set-cookie2\"");
            //response.AddHeader("Set-Cookie", "JSESSIONID=P8svS1yfhz_Hnrf1k9k2gYR:17oovfg7h;Path=/arsys/");
            ////response.AddHeader("Expires", "Thu");
            ////response.AddHeader("Expires", "01 Dec 1994 16:00:00 GMT");
            //response.AddHeader("X-XSS-Protection", "1;mode=block");
            response.AddHeader("Content-Language", "en-US");
            response.AddHeader("Content-Type", "text/xml; charset=utf-8");
            response.AddHeader("SOAPAction", "");
        }

        protected bool HasHeaderKeepAlive(HttpListenerContext context)
        {
            foreach (string item in context.Request.Headers)
            {
                if ((item == "Connection") && (context.Request.Headers[item] == "keep-alive"))
                {
                    return true;
                }
            }
            return false;
        }

        protected abstract byte ProcessAnyVerbPath(HttpListenerContext context);
    }
}
