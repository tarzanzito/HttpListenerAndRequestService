using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HttpMiniServerService
{
    public partial class FormHttpMiniServer : Form
    {
        #region fields

        private short _port = 8888;
        private HttpListener _listener = null;
        private Task _mainTask = null;
        private bool _keepGoing = true;
        private bool _respVisible = false;
        private char[] charsNewLine = System.Environment.NewLine.ToCharArray();
        System.Collections.Generic.Dictionary<string, string> _statusCodeCollection;

        #endregion

        #region constructors

        public FormHttpMiniServer()
        {
            InitializeComponent();
        }

        #endregion

        #region privates Core

        private async Task MainLoopActionsAsync()
        {
            InvokeTextBoxMsgInfo("Listening at port:" + _port.ToString());

            _listener.Start();

            while (_keepGoing)
            {
                try
                {
                    HttpListenerContext context = await _listener.GetContextAsync(); // wait and receive requests

                    lock (_listener)
                    {
                        if (_keepGoing)
                            Task.Run(() => ProcessRequestActionAsync(context)); // process request in another thread
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
            CheckBoxFocus();

            ProcessRequestAction(context);

            return null;
        }

        private void ProcessRequestAction(HttpListenerContext context)
        {
            ShowParams(context);
            ShowHeaders(context);
            ShowBody(context);
            SendResponse(context);
        }

        private void SendResponse(HttpListenerContext context)
        {
            using (HttpListenerResponse response = context.Response)
            {
                response.StatusCode = System.Convert.ToInt32(this.comboBoxStatusCodeResp.Text);
                response.StatusDescription = this.textBoxStatusDescResp.Text;
                response.ContentType = this.textBoxContentType.Text;
                byte[] buffer = Encoding.UTF8.GetBytes(this.textBoxBodyResp.Text);
                response.ContentLength64 = buffer.Length;
                response.OutputStream.Write(buffer, 0, buffer.Length);

                response.Headers.Clear();
                string[] lines = this.textBoxHeadersResp.Text.Split(charsNewLine);
                foreach (string line in lines)
                {
                    string tmp = line.Trim();

                    if (tmp == "")
                        continue;

                    int pos = line.IndexOf('=');

                    string key = tmp.Substring(0, pos).Trim();
                    string value = tmp.Substring(pos + 1).Trim();

                    //int pos1 = line.IndexOf(',');
                    //int pos2 = line.IndexOf(' ');
                    //int pos = (pos1 > pos2) ? pos2 : pos1;

                    //string tmpKey = tmp.Substring(0, pos);
                    //string tmpValue = tmp.Substring(pos + 1);

                    //string key = tmpKey.Replace("KEY=", "").Replace("Key=", "").Replace("key=", "").Trim();
                    //string value = tmpValue.Replace("VALUE=", "").Replace("Value=", "").Replace("value=", "").Trim();

                    response.Headers.Add(key, value);
                }

                //response.Headers = this.textBoxHeadersResp.Text

                //KEY=SOAPAction, VALUE=\"\"
                //KEY=Cache-Control, VALUE=no-cache
                //KEY=Connection, VALUE=keep-alive
                //KEY=Pragma, VALUE=no-cache
                //KEY=Content-Type, VALUE=text/xml; charset=utf-8
                //KEY=Accept, VALUE=text/xml, text/html, image/gif, image/jpeg, *;q=.2, */*; q=.2
                //KEY=Accept-Encoding, VALUE=gzip
                //KEY=Host, VALUE=localhost:8888
                //KEY=User-Agent, VALUE=Java/1.8.0_211
                //";
            }
        }

        private void ShowParams(HttpListenerContext context)
        {
            InvokeTextBoxTimeStamp(DateTime.Now);

            InvokeTextBoxMsgInfo(context.Request.Url.ToString());

            InvokeTextBoxVerb(context.Request.HttpMethod);
            InvokeTextBoxPath(context.Request.RawUrl);

            string contentType;
            if (context.Request.ContentType != null)
                contentType = context.Request.ContentType;
            else
                contentType = "undefined";

            InvokeTextBoxContentType(contentType);
            InvokeTextBoxDataLength(context.Request.ContentLength64.ToString());
        }

        private void ShowHeaders(HttpListenerContext context)
        {
            string text = "";
            foreach (string item in context.Request.Headers)
                text += item + "=" + context.Request.Headers[item] + Environment.NewLine;

            InvokeTextBoxHeaders(text);
        }

        private void ShowBody(HttpListenerContext context)
        {
            string body = "";
            if (context.Request.HasEntityBody)
            {
                Stream stream = context.Request.InputStream;
                Encoding encoding = context.Request.ContentEncoding;
                StreamReader streamReader = new StreamReader(stream, encoding);
                body = streamReader.ReadToEnd();
                streamReader.Close();
                stream.Close();
            }

            InvokeTextBoxBody(body);
        }

        #endregion

        #region privates

        private void PopulateContentType()
        {
            this.comboBoxContentTypeResp.Items.Clear();

            //this.comboBoxContentType.Items.Add("application/java-archive");
            //this.comboBoxContentType.Items.Add("application/EDI-X12");
            //this.comboBoxContentType.Items.Add("application/EDIFACT");
            //this.comboBoxContentType.Items.Add("application/javascript");
            //this.comboBoxContentType.Items.Add("application/octet-stream");
            //this.comboBoxContentType.Items.Add("application/ogg");
            this.comboBoxContentTypeResp.Items.Add("application/pdf");
            this.comboBoxContentTypeResp.Items.Add("application/xhtml+xml");
            //this.comboBoxContentType.Items.Add("application/x-shockwave-flash");
            this.comboBoxContentTypeResp.Items.Add("application/json");
            this.comboBoxContentTypeResp.Items.Add("application/ld+json");
            this.comboBoxContentTypeResp.Items.Add("application/xml");
            this.comboBoxContentTypeResp.Items.Add("application/zip");
            this.comboBoxContentTypeResp.Items.Add("application/x-www-form-urlencoded");
            this.comboBoxContentTypeResp.Items.Add("Type audio");

            //this.comboBoxContentType.Items.Add("audio/mpeg");
            //this.comboBoxContentType.Items.Add("audio/x-ms-wma");
            //this.comboBoxContentType.Items.Add("audio/vnd.rn-realaudio");
            //this.comboBoxContentType.Items.Add("audio/x-wav");

            //this.comboBoxContentType.Items.Add("image/gif");
            //this.comboBoxContentType.Items.Add("image/jpeg");
            //this.comboBoxContentType.Items.Add("image/png");
            //this.comboBoxContentType.Items.Add("image/tiff");
            //this.comboBoxContentType.Items.Add("image/vnd.microsoft.icon");
            //this.comboBoxContentType.Items.Add("image/x-icon");
            //this.comboBoxContentType.Items.Add("image/vnd.djvu");
            //this.comboBoxContentType.Items.Add("image/svg+xml");
            //this.comboBoxContentType.Items.Add("Type multipart");

            //this.comboBoxContentType.Items.Add("multipart/mixed");
            //this.comboBoxContentType.Items.Add("multipart/alternative");
            //this.comboBoxContentType.Items.Add("multipart/related");
            //this.comboBoxContentType.Items.Add("multipart/form-data");

            this.comboBoxContentTypeResp.Items.Add("text/css");
            this.comboBoxContentTypeResp.Items.Add("text/csv");
            this.comboBoxContentTypeResp.Items.Add("text/html");
            //this.comboBoxContentType.Items.Add("text/javascript");
            this.comboBoxContentTypeResp.Items.Add("text/plain");
            this.comboBoxContentTypeResp.Items.Add("text/xml");
            this.comboBoxContentTypeResp.Items.Add("Type video");

            //this.comboBoxContentType.Items.Add("video/mpeg");
            //this.comboBoxContentType.Items.Add("video/mp4");
            //this.comboBoxContentType.Items.Add("video/quicktime");
            //this.comboBoxContentType.Items.Add("video/x-ms-wmv");
            //this.comboBoxContentType.Items.Add("video/x-msvideo");
            //this.comboBoxContentType.Items.Add("video/x-flv");
            //this.comboBoxContentType.Items.Add("video/webm");
            //this.comboBoxContentType.Items.Add("Type vnd");

            //this.comboBoxContentType.Items.Add("application/vnd.android.package-archive");
            //this.comboBoxContentType.Items.Add("application/vnd.oasis.opendocument.text");
            //this.comboBoxContentType.Items.Add("application/vnd.oasis.opendocument.spreadsheet");
            //this.comboBoxContentType.Items.Add("application/vnd.oasis.opendocument.presentation");
            //this.comboBoxContentType.Items.Add("application/vnd.oasis.opendocument.graphics");
            //this.comboBoxContentType.Items.Add("application/vnd.ms-excel");
            //this.comboBoxContentType.Items.Add("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            //this.comboBoxContentType.Items.Add("application/vnd.ms-powerpoint");
            //this.comboBoxContentType.Items.Add("application/vnd.openxmlformats-officedocument.presentationml.presentation");
            //this.comboBoxContentType.Items.Add("application/msword");
            //this.comboBoxContentType.Items.Add("application/vnd.openxmlformats-officedocument.wordprocessingml.document");
            //this.comboBoxContentType.Items.Add("application/vnd.mozilla.xul+xml");


            //object[] items = null; ;
            //comboBoxContentTypeResp.Items.CopyTo(items, 0);
            //comboBoxContentType.Items.AddRange(items);
        }

        private void PopulateStatusCode()
        {
            _statusCodeCollection = new System.Collections.Generic.Dictionary<string, string>() {
                { "200", "OK" },
                { "2012", "Created" },
                { "202", "Accepted" },
                { "203", "Non - Authoritative Information" },
                { "204", "No Content" },
                { "205", "Reset Content" },
                { "206", "Partial Content" },
                { "207", "Multi - Status(WebDAV)" },
                { "208", "Multi - Status(WebDAV)" },
                { "226", "IM Used(HTTP Delta encoding)" },
                { "300", "Multiple Choice" },
                { "301", "Moved Permanently" },
                { "302", "Found" },
                { "303", "See Other" },
                { "304", "Not Modified" },
                { "305", "Use Proxy" },
                { "306", "unused" },
                { "307", "Temporary Redirect" },
                { "308", "Permanent Redirect" },
                { "400", "Bad Request" },
                { "401", "Unauthorized" },
                { "402", "Payment Required" },
                { "403", "Forbidden" },
                { "404", "Not Found" },
                { "405", "Method Not Allowed" },
                { "406", "Not Acceptable" },
                { "407", "Proxy Authentication Required" },
                { "408", "Request Timeout" },
                { "409", "Conflict" },
                { "410", "Gone" },
                { "411", "Length Required" },
                { "412", "Precondition Failed" },
                { "413", "Payload Too Large" },
                { "414", "URI Too Long" },
                { "415", "Unsupported Media Type" },
                { "416", "Requested Range Not Satisfiable" },
                { "417", "Expectation Failed" },
                { "418", "I'm a teapot" },
                { "421", "Misdirected Request" },
                { "422", "Unprocessable Entity(WebDAV)" },
                { "423", "Locked(WebDAV)" },
                { "424", "Failed Dependency(WebDAV)" },
                { "425", "Too Early" },
                { "426", "Upgrade Required" },
                { "428", "Precondition Required" },
                { "429", "Too Many Requests" },
                { "431", "Request Header Fields Too Large" },
                { "451", "Unavailable For Legal Reasons" },
                { "500", "Internal Server Error" },
                { "501", "Not Implemented" },
                { "502", "Bad Gateway" },
                { "503", "Service Unavailable" },
                { "504", "Gateway Timeout" },
                { "505", "HTTP Version Not Supported" },
                { "506", "Variant Also Negotiates" },
                { "507", "Insufficient Storage" },
                { "508", "Loop Detected(WebDAV)" },
                { "510", "Not Extended" },
                { "511", "Network Authentication Required" }
            };

            string[] keyArray = new string[_statusCodeCollection.Count];
            _statusCodeCollection.Keys.CopyTo(keyArray, 0);

            comboBoxStatusCodeResp.Items.Clear();
            comboBoxStatusCodeResp.Items.AddRange(keyArray);
        }

       
        private string TitleInfo()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            AssemblyTitleAttribute attr1 = (AssemblyTitleAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyTitleAttribute), false);
            string title = attr1.Title;

            AssemblyCompanyAttribute attr2 = (AssemblyCompanyAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyCompanyAttribute), false);
            string company = attr2.Company;

            string version = assembly.GetName().Version.ToString();

            return title + " - Version: " + version + " (By '" + company + "')" ;
        }

        #endregion

        #region Invokes

        private void InvokeTextBoxMsgInfo(string value)
        {
            if (textBoxMsgInfo.InvokeRequired)
            {
                textBoxMsgInfo.Invoke(new Action<string>(InvokeTextBoxMsgInfo), new object[] { value });
                return;
            }

            textBoxMsgInfo.Text = value;
        }

        private void InvokeTextBoxHeaders(string value)
        {
            if (textBoxHeaders.InvokeRequired)
            {
                textBoxHeaders.Invoke(new Action<string>(InvokeTextBoxHeaders), new object[] { value });
                return;
            }

            textBoxHeaders.Text = value;
        }

        private void InvokeTextBoxBody(string value)
        {
            if (textBoxBody.InvokeRequired)
            {
                textBoxBody.Invoke(new Action<string>(InvokeTextBoxBody), new object[] { value });
                return;
            }

            textBoxBody.Text = value;
        }

        private void InvokeTextBoxVerb(string value)
        {
            if (textBoxVerb.InvokeRequired)
            {
                textBoxVerb.Invoke(new Action<string>(InvokeTextBoxVerb), new object[] { value });
                return;
            }

            textBoxVerb.Text = value;
        }

        private void InvokeTextBoxPath(string value)
        {
            if (textBoxResource.InvokeRequired)
            {
                textBoxResource.Invoke(new Action<string>(InvokeTextBoxPath), new object[] { value });
                return;
            }

            textBoxResource.Text = value.Substring(1);
        }

        private void InvokeTextBoxContentType(string value)
        {
            if (textBoxContentType.InvokeRequired)
            {
                textBoxContentType.Invoke(new Action<string>(InvokeTextBoxContentType), new object[] { value });
                return;
            }

            textBoxContentType.Text = value;
        }

        private void InvokeTextBoxDataLength(string value)
        {
            if (textBoxDataLength.InvokeRequired)
            {
                textBoxDataLength.Invoke(new Action<string>(InvokeTextBoxDataLength), new object[] { value });
                return;
            }

            textBoxDataLength.Text = value;
        }

        private void InvokeTextBoxTimeStamp(DateTime value)
        {
            if (textBoxTimeStamp.InvokeRequired)
            {
                textBoxTimeStamp.Invoke(new Action<DateTime>(InvokeTextBoxTimeStamp), new object[] { value });
                return;
            }

            textBoxTimeStamp.Text = value.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        private void CheckBoxFocus()
        {
            if (!checkBoxFocus.Checked)
                return;

            if (checkBoxFocus.InvokeRequired)
            {
                checkBoxFocus.Invoke(new Action(CheckBoxFocus), null);
                return;
            }

            WindowState = FormWindowState.Normal;
            Focus();
        }

        #endregion

        #region events

        private void FormHttpRequestViewer_Load(object sender, EventArgs e)
        {
            this.Width = 516;

            Text = TitleInfo();


            PopulateContentType();
            PopulateStatusCode();

            comboBoxContentTypeResp.Text = "text/plain";
            comboBoxStatusCodeResp.Text = "200";
            textBoxHeadersResp.Text = "";
            textBoxBodyResp.Text = "This is OK";
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            _port = Convert.ToInt16(textBoxPort.Text);
            _listener = new HttpListener { Prefixes = { $"http://localhost:{_port}/" } };

            if (_mainTask != null && !_mainTask.IsCompleted)
                return; //Already started

            _mainTask = Task.Run(() => MainLoopActionsAsync()); //start main loop

            this.textBoxHeaders.Text = "";
            this.textBoxMsgInfo.Text = "";
            this.textBoxResource.Text = "";
            this.textBoxVerb.Text = "";
            this.textBoxBody.Text = "";
            this.textBoxContentType.Text = "";
            this.textBoxDataLength.Text = "";

            buttonStop.Enabled = true;
            buttonStart.Enabled = false;
            textBoxPort.Enabled = false;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (_listener == null)
                return;

            _keepGoing = false;
            lock (_listener)
            {
                //Use a lock so we don't kill a request that's currently being processed
                _listener.Stop();
            }

            buttonStop.Enabled = false;
            buttonStart.Enabled = true;
            textBoxPort.Enabled = true;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            buttonStop_Click(sender, e);
            Close();
        }

        private void buttonVisibleResponse_Click(object sender, EventArgs e)
        {
            if (_respVisible)
            {
                buttonVisibleResponse.Text = ">>";
                this.Width = 516;
                //buttonResponse.Left = 517;
                //buttonClose.Left = 442;
            }
            else
            {
                buttonVisibleResponse.Text = "<<";
                this.Width = 1012;
                // buttonResponse.Left = 1000;
                // buttonClose.Left = 1000;
            }

            _respVisible = !_respVisible;
        }

        private void comboBoxStatusCodeResp_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = _statusCodeCollection[comboBoxStatusCodeResp.Text];
            textBoxStatusDescResp.Text = value;
        }

        #endregion
    }
}
 