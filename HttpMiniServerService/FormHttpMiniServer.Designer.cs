namespace HttpMiniServerService
{
    partial class FormHttpMiniServer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHttpMiniServer));
            this.buttonStart = new System.Windows.Forms.Button();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxBody = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.textBoxMsgInfo = new System.Windows.Forms.TextBox();
            this.checkBoxFocus = new System.Windows.Forms.CheckBox();
            this.textBoxHeaders = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxVerb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxResource = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxDataLength = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxContentType = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxTimeStamp = new System.Windows.Forms.TextBox();
            this.buttonVisibleResponse = new System.Windows.Forms.Button();
            this.textBoxHeadersResp = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxBodyResp = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxStatusDescResp = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBoxContentTypeResp = new System.Windows.Forms.ComboBox();
            this.comboBoxStatusCodeResp = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(145, 9);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(72, 25);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(67, 12);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(56, 20);
            this.textBoxPort.TabIndex = 0;
            this.textBoxPort.Text = "8888";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Port:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Request Headers:";
            // 
            // textBoxBody
            // 
            this.textBoxBody.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxBody.Location = new System.Drawing.Point(10, 248);
            this.textBoxBody.Multiline = true;
            this.textBoxBody.Name = "textBoxBody";
            this.textBoxBody.ReadOnly = true;
            this.textBoxBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxBody.Size = new System.Drawing.Size(481, 172);
            this.textBoxBody.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Request Body:";
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(223, 9);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(72, 25);
            this.buttonStop.TabIndex = 2;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(916, 423);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(72, 25);
            this.buttonClose.TabIndex = 31;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // textBoxMsgInfo
            // 
            this.textBoxMsgInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMsgInfo.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxMsgInfo.Location = new System.Drawing.Point(507, 426);
            this.textBoxMsgInfo.Name = "textBoxMsgInfo";
            this.textBoxMsgInfo.ReadOnly = true;
            this.textBoxMsgInfo.Size = new System.Drawing.Size(403, 20);
            this.textBoxMsgInfo.TabIndex = 30;
            // 
            // checkBoxFocus
            // 
            this.checkBoxFocus.AutoSize = true;
            this.checkBoxFocus.Location = new System.Drawing.Point(328, 14);
            this.checkBoxFocus.Name = "checkBoxFocus";
            this.checkBoxFocus.Size = new System.Drawing.Size(134, 17);
            this.checkBoxFocus.TabIndex = 3;
            this.checkBoxFocus.Text = "On incoming set focus ";
            this.checkBoxFocus.UseVisualStyleBackColor = true;
            // 
            // textBoxHeaders
            // 
            this.textBoxHeaders.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxHeaders.Location = new System.Drawing.Point(10, 132);
            this.textBoxHeaders.Multiline = true;
            this.textBoxHeaders.Name = "textBoxHeaders";
            this.textBoxHeaders.ReadOnly = true;
            this.textBoxHeaders.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxHeaders.Size = new System.Drawing.Size(481, 97);
            this.textBoxHeaders.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Verb:";
            // 
            // textBoxVerb
            // 
            this.textBoxVerb.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxVerb.Location = new System.Drawing.Point(67, 44);
            this.textBoxVerb.Name = "textBoxVerb";
            this.textBoxVerb.ReadOnly = true;
            this.textBoxVerb.Size = new System.Drawing.Size(109, 20);
            this.textBoxVerb.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Resource:";
            // 
            // textBoxResource
            // 
            this.textBoxResource.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxResource.Location = new System.Drawing.Point(67, 68);
            this.textBoxResource.Name = "textBoxResource";
            this.textBoxResource.ReadOnly = true;
            this.textBoxResource.Size = new System.Drawing.Size(424, 20);
            this.textBoxResource.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(201, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Length:";
            // 
            // textBoxDataLength
            // 
            this.textBoxDataLength.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxDataLength.Location = new System.Drawing.Point(244, 92);
            this.textBoxDataLength.Name = "textBoxDataLength";
            this.textBoxDataLength.ReadOnly = true;
            this.textBoxDataLength.Size = new System.Drawing.Size(63, 20);
            this.textBoxDataLength.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Cont.Type:";
            // 
            // textBoxContentType
            // 
            this.textBoxContentType.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxContentType.Location = new System.Drawing.Point(67, 92);
            this.textBoxContentType.Name = "textBoxContentType";
            this.textBoxContentType.ReadOnly = true;
            this.textBoxContentType.Size = new System.Drawing.Size(131, 20);
            this.textBoxContentType.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(307, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "TimeStamp:";
            // 
            // textBoxTimeStamp
            // 
            this.textBoxTimeStamp.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxTimeStamp.Location = new System.Drawing.Point(370, 92);
            this.textBoxTimeStamp.Name = "textBoxTimeStamp";
            this.textBoxTimeStamp.ReadOnly = true;
            this.textBoxTimeStamp.Size = new System.Drawing.Size(121, 20);
            this.textBoxTimeStamp.TabIndex = 9;
            // 
            // buttonVisibleResponse
            // 
            this.buttonVisibleResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonVisibleResponse.Location = new System.Drawing.Point(960, 7);
            this.buttonVisibleResponse.Name = "buttonVisibleResponse";
            this.buttonVisibleResponse.Size = new System.Drawing.Size(29, 25);
            this.buttonVisibleResponse.TabIndex = 4;
            this.buttonVisibleResponse.Text = ">>";
            this.buttonVisibleResponse.UseVisualStyleBackColor = true;
            this.buttonVisibleResponse.Click += new System.EventHandler(this.buttonVisibleResponse_Click);
            // 
            // textBoxHeadersResp
            // 
            this.textBoxHeadersResp.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxHeadersResp.Location = new System.Drawing.Point(507, 132);
            this.textBoxHeadersResp.Multiline = true;
            this.textBoxHeadersResp.Name = "textBoxHeadersResp";
            this.textBoxHeadersResp.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxHeadersResp.Size = new System.Drawing.Size(481, 97);
            this.textBoxHeadersResp.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(504, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Response Headers:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(504, 232);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Response Body:";
            // 
            // textBoxBodyResp
            // 
            this.textBoxBodyResp.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxBodyResp.Location = new System.Drawing.Point(507, 248);
            this.textBoxBodyResp.Multiline = true;
            this.textBoxBodyResp.Name = "textBoxBodyResp";
            this.textBoxBodyResp.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxBodyResp.Size = new System.Drawing.Size(481, 172);
            this.textBoxBodyResp.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(509, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "Content Type:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(506, 93);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 13);
            this.label13.TabIndex = 35;
            this.label13.Text = "Status Code:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(644, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Status Desc:";
            // 
            // textBoxStatusDescResp
            // 
            this.textBoxStatusDescResp.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxStatusDescResp.Location = new System.Drawing.Point(718, 92);
            this.textBoxStatusDescResp.Name = "textBoxStatusDescResp";
            this.textBoxStatusDescResp.ReadOnly = true;
            this.textBoxStatusDescResp.Size = new System.Drawing.Size(266, 20);
            this.textBoxStatusDescResp.TabIndex = 22;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(508, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(123, 20);
            this.label14.TabIndex = 38;
            this.label14.Text = "Set Response...";
            // 
            // comboBoxContentTypeResp
            // 
            this.comboBoxContentTypeResp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxContentTypeResp.FormattingEnabled = true;
            this.comboBoxContentTypeResp.Location = new System.Drawing.Point(580, 63);
            this.comboBoxContentTypeResp.Name = "comboBoxContentTypeResp";
            this.comboBoxContentTypeResp.Size = new System.Drawing.Size(132, 21);
            this.comboBoxContentTypeResp.TabIndex = 40;
            // 
            // comboBoxStatusCodeResp
            // 
            this.comboBoxStatusCodeResp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatusCodeResp.FormattingEnabled = true;
            this.comboBoxStatusCodeResp.Location = new System.Drawing.Point(580, 90);
            this.comboBoxStatusCodeResp.Name = "comboBoxStatusCodeResp";
            this.comboBoxStatusCodeResp.Size = new System.Drawing.Size(47, 21);
            this.comboBoxStatusCodeResp.TabIndex = 41;
            this.comboBoxStatusCodeResp.SelectedIndexChanged += new System.EventHandler(this.comboBoxStatusCodeResp_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Location = new System.Drawing.Point(497, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(6, 386);
            this.panel1.TabIndex = 42;
            // 
            // FormHttpMiniServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 458);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comboBoxStatusCodeResp);
            this.Controls.Add(this.comboBoxContentTypeResp);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxStatusDescResp);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxBodyResp);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxHeadersResp);
            this.Controls.Add(this.buttonVisibleResponse);
            this.Controls.Add(this.textBoxTimeStamp);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxDataLength);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxContentType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxResource);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxVerb);
            this.Controls.Add(this.checkBoxFocus);
            this.Controls.Add(this.textBoxMsgInfo);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxBody);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxHeaders);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.buttonStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormHttpMiniServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HTTP Mini Server";
            this.Load += new System.EventHandler(this.FormHttpRequestViewer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxBody;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox textBoxMsgInfo;
        private System.Windows.Forms.CheckBox checkBoxFocus;
        private System.Windows.Forms.TextBox textBoxHeaders;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxVerb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxResource;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxDataLength;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxContentType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxTimeStamp;
        private System.Windows.Forms.Button buttonVisibleResponse;
        private System.Windows.Forms.TextBox textBoxHeadersResp;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxBodyResp;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxStatusDescResp;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBoxContentTypeResp;
        private System.Windows.Forms.ComboBox comboBoxStatusCodeResp;
        private System.Windows.Forms.Panel panel1;
    }
}

