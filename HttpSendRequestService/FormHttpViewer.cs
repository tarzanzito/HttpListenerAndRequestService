using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HttpSendRequestService
{
    public partial class FormHttpViewer : Form
    {
        #region fields

        private char[] _charsNewLine = System.Environment.NewLine.ToCharArray();
        private string _userName = null;
        private string _userPassword = null;
        private string _userDomain = null;
        private string _proxyAddress = null;
        private int _proxyPort = 0;

        #endregion

        #region constructors

        public FormHttpViewer()
        {
            InitializeComponent();

            //_userName = "user
            //_userPassword = "pass
            //_userDomain = "CENTRO";
            //_proxyAddress = "http://proxy.tatto.gs.corp/tatto.pac";
            //_proxyPort = 8080;
        }

        #endregion

        #region backgroundWorker1

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            ProcessAsync();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
        }

        private void ProcessAsync()
        {
            //System.Net.WebRequest request = null;
            System.Net.HttpWebRequest request = null;

            try
            {
                string url = ConcatHostAndResource();

                //request = System.Net.WebRequest.Create(url);
                request = System.Net.WebRequest.CreateHttp(url);

                request.Proxy = AddProxy();

                request.Method = InvokeComboBoxVerbs();
                request.ContentType = InvokeComboBoxContentType();
                    
                //add Body
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(InvokeTextBoxBody());
                if (byteArray.Length > 0)
                {
                    request.ContentLength = byteArray.Length;
                    using (System.IO.Stream stream = request.GetRequestStream())
                    {
                        stream.Write(byteArray, 0, byteArray.Length);
                        stream.Close();
                    }
                }

                //Add Headers
                //request.Headers.Clear();
                string[] lines = InvokeTextBoxHeaders().Split(_charsNewLine);
                foreach (string line in lines)
                {
                    string tmp = line.Trim();

                    if (tmp == "")
                        continue;

                    int pos = line.IndexOf('=');

                    string key = tmp.Substring(0, pos).Trim();
                    string value = tmp.Substring(pos + 1).Trim();

                    request.Headers.Add(key, value);
                }
                
                //request.UserAgent= @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36";
                request.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64)";

            }
            catch (System.Exception ex)
            {
                InvokeTextBoxMsgInfo( "Send Error -> " + ex.Message);
                return;
            }

            //send and wait response
            try
            {
                //System.Net.WebResponse response = request.GetResponse();
                System.Net.HttpWebResponse httpWebResponse = (System.Net.HttpWebResponse)request.GetResponse();

                InvokeTextBoxStatusCodeResp((int)httpWebResponse.StatusCode);
                InvokeTextBoxStatusDescResp(httpWebResponse.StatusDescription);
                InvokeTextBoxContentTypeResp(httpWebResponse.ContentType);

                //body
                string dataResp;
                using (System.IO.Stream dataStream = httpWebResponse.GetResponseStream())
                {
                    System.IO.StreamReader reader = new System.IO.StreamReader(dataStream);
                    dataResp = reader.ReadToEnd();
                    dataStream.Close();
                }
                InvokeTextBoxBodyResp(dataResp);

                //headers
                System.Net.WebHeaderCollection headersList = httpWebResponse.Headers;
                string headerData = "";
                foreach (string key in headersList.Keys)
                {
                    string[] values = headersList.GetValues(key);
                    string value = "";
                    foreach (string item in values)
                        value += ";" + item;

                    if (value.Length > 0)
                        value = value.Substring(1);

                    headerData = key + "=" + value + System.Environment.NewLine;
                }
                InvokeTextBoxHeadersResp(headerData);

            }
            catch (System.Exception ex)
            {
                InvokeTextBoxMsgInfo("Receive ERROR -> " + ex.Message);
                return;
            }

            InvokeTextBoxMsgInfo("Poperation succefully...");
        }

        #endregion

        #region Invoke

        private void InvokeTextBoxStatusCodeResp(int value)
        {
            if (textBoxStatusCodeResp.InvokeRequired)
            {
                textBoxStatusCodeResp.Invoke(new Action<int>(InvokeTextBoxStatusCodeResp), new object[] { value });
                return;
            }

            textBoxStatusCodeResp.Text = value.ToString();
        }

        private void InvokeTextBoxStatusDescResp(string value)
        {
            if (textBoxStatusDescResp.InvokeRequired)
            {
                textBoxStatusDescResp.Invoke(new Action<string>(InvokeTextBoxStatusDescResp), new object[] { value });
                return;
            }

            textBoxStatusDescResp.Text = value;
        }
        
        private void InvokeTextBoxContentTypeResp(string value)
        {
            if (textBoxContentTypeResp.InvokeRequired)
            {
                textBoxContentTypeResp.Invoke(new Action<string>(InvokeTextBoxContentTypeResp), new object[] { value });
                return;
            }

            textBoxContentTypeResp.Text = value;
        }

        private void InvokeTextBoxHeadersResp(string value)
        {
            if (textBoxHeadersResp.InvokeRequired)
            {
                textBoxHeadersResp.Invoke(new Action<string>(InvokeTextBoxHeadersResp), new object[] { value });
                return;
            }

            textBoxHeadersResp.Text = value;
        }

        private void InvokeTextBoxBodyResp(string value)
        {
            if (textBoxBodyResp.InvokeRequired)
            {
                textBoxBodyResp.Invoke(new Action<string>(InvokeTextBoxBodyResp), new object[] { value });
                return;
            }

            textBoxBodyResp.Text = value;
        }

        private void InvokeTextBoxMsgInfo(string value)
        {
            if (textBoxMsgInfo.InvokeRequired)
            {
                textBoxMsgInfo.Invoke(new Action<string>(InvokeTextBoxMsgInfo), new object[] { value });
                return;
            }

            textBoxMsgInfo.Text = value;
        }

        private string InvokeTextBoxHost()
        {
            if (textBoxHost.InvokeRequired)
            {
                object retValue = textBoxHost.Invoke(new Func<string>(InvokeTextBoxHost));
                return (string)retValue;
            }

            return textBoxHost.Text;
        }

        private string InvokeTextBoxResource()
        {
            if (textBoxResource.InvokeRequired)
            {
                object retValue = textBoxResource.Invoke(new Func<string>(InvokeTextBoxResource));
                return (string)retValue;
            }

            return textBoxResource.Text;
        }

        private string InvokeComboBoxVerbs()
        {
            if (comboBoxVerbs.InvokeRequired)
            {
                object retValue = comboBoxVerbs.Invoke(new Func<string>(InvokeComboBoxVerbs));
                return (string)retValue;
            }

            return comboBoxVerbs.Text;
        }

        private string InvokeComboBoxContentType()
        {
            if (comboBoxContentType.InvokeRequired)
            {
                object retValue = comboBoxContentType.Invoke(new Func<string>(InvokeComboBoxContentType));
                return (string)retValue;
            }

            return comboBoxContentType.Text;
        }

        private string InvokeTextBoxHeaders()
        {
            if (textBoxHeaders.InvokeRequired)
            {
                object retValue = textBoxHeaders.Invoke(new Func<string>(InvokeTextBoxHeaders));
                return (string)retValue;
            }

            return textBoxHeaders.Text;
        }

        private string InvokeTextBoxBody()
        {
            if (textBoxBody.InvokeRequired)
            {
                object retValue = textBoxBody.Invoke(new Func<string>(InvokeTextBoxBody));
                return (string)retValue;
            }

            return textBoxBody.Text;
        }

        #endregion

        #region private

        private string ConcatHostAndResource()
        {
            string host = InvokeTextBoxHost().Trim();
            string resource = InvokeTextBoxResource().Trim();

            if (resource.Substring(0, 1) == "/")
                resource = resource.Substring(1);

            if (resource.Substring(resource.Length - 1, 1) == "/")
                return host + resource;
            else
                return host + "/" + resource;
        }

        private System.Net.WebProxy AddProxy()
        {
            if ((_userName == null))
                return null;

            //PROXYTOTTA = "PROXY proxy.totta.gs.corp:8080";
            //System.Net.WebProxy proxyObject = new System.Net.WebProxy("http://webproxy:80/");

            System.Net.NetworkCredential networkCredential = null;
            System.Net.WebProxy webProxy = null;

            networkCredential = new System.Net.NetworkCredential(_userName, _userPassword, _userDomain);

            string address = _proxyAddress + ":" + _proxyPort.ToString();
            webProxy = new System.Net.WebProxy(address);
            webProxy.Credentials = networkCredential;

            //_webClient.Proxy.Credentials = networkCredential;
            //_webClient.Credentials = networkCredential;

            return webProxy;
        }

        private void PopulateVerbs()
        {
            this.comboBoxVerbs.Items.Clear();

            this.comboBoxVerbs.Items.Add("GET");
            this.comboBoxVerbs.Items.Add("HEAD");
            this.comboBoxVerbs.Items.Add("POST");
            this.comboBoxVerbs.Items.Add("PUT");
            this.comboBoxVerbs.Items.Add("DELETE");
            this.comboBoxVerbs.Items.Add("CONNECT");
            this.comboBoxVerbs.Items.Add("OPTIONS");
            this.comboBoxVerbs.Items.Add("TRACE");
            this.comboBoxVerbs.Items.Add("PATCH");
        }

        private void PopulateContentTypes()
        {
            this.comboBoxContentType.Items.Clear();

            //this.comboBoxContentType.Items.Add("application/java-archive");
            //this.comboBoxContentType.Items.Add("application/EDI-X12");
            //this.comboBoxContentType.Items.Add("application/EDIFACT");
            //this.comboBoxContentType.Items.Add("application/javascript");
            //this.comboBoxContentType.Items.Add("application/octet-stream");
            //this.comboBoxContentType.Items.Add("application/ogg");
            this.comboBoxContentType.Items.Add("application/pdf");
            this.comboBoxContentType.Items.Add("application/xhtml+xml");
            //this.comboBoxContentType.Items.Add("application/x-shockwave-flash");
            this.comboBoxContentType.Items.Add("application/json");
            this.comboBoxContentType.Items.Add("application/ld+json");
            this.comboBoxContentType.Items.Add("application/xml");
            this.comboBoxContentType.Items.Add("application/zip");
            this.comboBoxContentType.Items.Add("application/x-www-form-urlencoded");
            this.comboBoxContentType.Items.Add("Type audio");

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

            this.comboBoxContentType.Items.Add("text/css");
            this.comboBoxContentType.Items.Add("text/csv");
            this.comboBoxContentType.Items.Add("text/html");
            //this.comboBoxContentType.Items.Add("text/javascript");
            this.comboBoxContentType.Items.Add("text/plain");
            this.comboBoxContentType.Items.Add("text/xml");
            this.comboBoxContentType.Items.Add("Type video");

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

        private string TitleInfo()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            AssemblyTitleAttribute attr1 = (AssemblyTitleAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyTitleAttribute), false);
            string title = attr1.Title;

            AssemblyCompanyAttribute attr2 = (AssemblyCompanyAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyCompanyAttribute), false);
            string company = attr2.Company;

            string version = assembly.GetName().Version.ToString();

            return title + " - Version: " + version + " - (By '" + company + "')";
        }

        #endregion

        #region events UI

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = TitleInfo();

            PopulateVerbs();
            PopulateContentTypes();

            comboBoxVerbs.Text = "GET";
            comboBoxContentType.Text = "text/plain";
            textBoxBody.Text = "";
            //comboBoxContentType.Enabled = false;
            textBoxBody.Enabled = false;
        }

        private void comboBoxVerbs_TextChanged(object sender, EventArgs e)
        {
            comboBoxVerbs.Text = comboBoxVerbs.Text.ToUpper().Trim();

            if (comboBoxVerbs.Text == "GET")
            {
                textBoxBody.Text = "";
                textBoxBody.Enabled = false;
                comboBoxContentType.Text = "text/plain";
                //comboBoxContentType.Enabled = false;
            }
            else
            {
                textBoxBody.Enabled = true;
                //comboBoxContentType.Enabled = true;
                 comboBoxContentType.SelectedIndex = 2;
            }
        }

        private void textBoxHost_TextChanged(object sender, EventArgs e)
        {
            textBoxHost.Text = textBoxHost.Text.Trim();
        }

        private void comboBoxContentType_TextChanged(object sender, EventArgs e)
        {
            comboBoxContentType.Text = comboBoxContentType.Text.Trim();
        }

        private void textBoxResource_TextChanged(object sender, EventArgs e)
        {
            textBoxResource.Text = textBoxResource.Text.Trim();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            textBoxStatusCodeResp.Text = "";
            textBoxStatusDescResp.Text = "";
            textBoxContentTypeResp.Text = "";
            textBoxHeadersResp.Text = "";
            textBoxBodyResp.Text = "";
            textBoxMsgInfo.Text = "";

            if (backgroundWorker1.IsBusy != true)
            {
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync();
                // Task.Run(() => ProcessAsync());
            }
        }

         private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
 