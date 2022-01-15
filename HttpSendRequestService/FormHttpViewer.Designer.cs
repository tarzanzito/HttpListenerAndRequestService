namespace HttpSendRequestService
{
    partial class FormHttpViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHttpViewer));
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxHost = new System.Windows.Forms.TextBox();
            this.textBoxResource = new System.Windows.Forms.TextBox();
            this.textBoxBody = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxBodyResp = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxHeaders = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxHeadersResp = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxStatusDescResp = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxStatusCodeResp = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxContentTypeResp = new System.Windows.Forms.TextBox();
            this.textBoxMsgInfo = new System.Windows.Forms.TextBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBoxContentType = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxVerbs = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(365, 9);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(72, 25);
            this.buttonSend.TabIndex = 0;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxHost
            // 
            this.textBoxHost.Location = new System.Drawing.Point(70, 12);
            this.textBoxHost.Name = "textBoxHost";
            this.textBoxHost.Size = new System.Drawing.Size(279, 20);
            this.textBoxHost.TabIndex = 2;
            this.textBoxHost.Text = "http://localhost:8888";
            this.textBoxHost.TextChanged += new System.EventHandler(this.textBoxHost_TextChanged);
            // 
            // textBoxResource
            // 
            this.textBoxResource.Location = new System.Drawing.Point(70, 38);
            this.textBoxResource.Name = "textBoxResource";
            this.textBoxResource.Size = new System.Drawing.Size(367, 20);
            this.textBoxResource.TabIndex = 3;
            this.textBoxResource.TextChanged += new System.EventHandler(this.textBoxResource_TextChanged);
            // 
            // textBoxBody
            // 
            this.textBoxBody.Location = new System.Drawing.Point(15, 241);
            this.textBoxBody.Multiline = true;
            this.textBoxBody.Name = "textBoxBody";
            this.textBoxBody.Size = new System.Drawing.Size(422, 230);
            this.textBoxBody.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Host:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Resource:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Verb:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Request Body:";
            // 
            // textBoxBodyResp
            // 
            this.textBoxBodyResp.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxBodyResp.Location = new System.Drawing.Point(463, 243);
            this.textBoxBodyResp.Multiline = true;
            this.textBoxBodyResp.Name = "textBoxBodyResp";
            this.textBoxBodyResp.ReadOnly = true;
            this.textBoxBodyResp.Size = new System.Drawing.Size(417, 228);
            this.textBoxBodyResp.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(460, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Response Body:";
            // 
            // textBoxHeaders
            // 
            this.textBoxHeaders.Location = new System.Drawing.Point(15, 106);
            this.textBoxHeaders.Multiline = true;
            this.textBoxHeaders.Name = "textBoxHeaders";
            this.textBoxHeaders.Size = new System.Drawing.Size(422, 118);
            this.textBoxHeaders.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Request Headers:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(460, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Response Headers:";
            // 
            // textBoxHeadersResp
            // 
            this.textBoxHeadersResp.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxHeadersResp.Location = new System.Drawing.Point(463, 106);
            this.textBoxHeadersResp.Multiline = true;
            this.textBoxHeadersResp.Name = "textBoxHeadersResp";
            this.textBoxHeadersResp.ReadOnly = true;
            this.textBoxHeadersResp.Size = new System.Drawing.Size(417, 118);
            this.textBoxHeadersResp.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(584, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "Status Descr:";
            // 
            // textBoxStatusDescResp
            // 
            this.textBoxStatusDescResp.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxStatusDescResp.Location = new System.Drawing.Point(661, 38);
            this.textBoxStatusDescResp.Name = "textBoxStatusDescResp";
            this.textBoxStatusDescResp.ReadOnly = true;
            this.textBoxStatusDescResp.Size = new System.Drawing.Size(110, 20);
            this.textBoxStatusDescResp.TabIndex = 40;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(460, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 13);
            this.label13.TabIndex = 42;
            this.label13.Text = "Status Code:";
            // 
            // textBoxStatusCodeResp
            // 
            this.textBoxStatusCodeResp.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxStatusCodeResp.Location = new System.Drawing.Point(535, 38);
            this.textBoxStatusCodeResp.Name = "textBoxStatusCodeResp";
            this.textBoxStatusCodeResp.ReadOnly = true;
            this.textBoxStatusCodeResp.Size = new System.Drawing.Size(36, 20);
            this.textBoxStatusCodeResp.TabIndex = 39;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(171, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 41;
            this.label12.Text = "Content Type:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(460, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 45;
            this.label9.Text = "Content Type:";
            // 
            // textBoxContentTypeResp
            // 
            this.textBoxContentTypeResp.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxContentTypeResp.Location = new System.Drawing.Point(535, 65);
            this.textBoxContentTypeResp.Name = "textBoxContentTypeResp";
            this.textBoxContentTypeResp.ReadOnly = true;
            this.textBoxContentTypeResp.Size = new System.Drawing.Size(169, 20);
            this.textBoxContentTypeResp.TabIndex = 44;
            // 
            // textBoxMsgInfo
            // 
            this.textBoxMsgInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxMsgInfo.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxMsgInfo.Location = new System.Drawing.Point(15, 479);
            this.textBoxMsgInfo.Name = "textBoxMsgInfo";
            this.textBoxMsgInfo.ReadOnly = true;
            this.textBoxMsgInfo.Size = new System.Drawing.Size(539, 20);
            this.textBoxMsgInfo.TabIndex = 46;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(809, 476);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(71, 25);
            this.buttonClose.TabIndex = 47;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(459, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 20);
            this.label14.TabIndex = 48;
            this.label14.Text = "Response...";
            // 
            // comboBoxContentType
            // 
            this.comboBoxContentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxContentType.FormattingEnabled = true;
            this.comboBoxContentType.Location = new System.Drawing.Point(251, 68);
            this.comboBoxContentType.Name = "comboBoxContentType";
            this.comboBoxContentType.Size = new System.Drawing.Size(186, 21);
            this.comboBoxContentType.Sorted = true;
            this.comboBoxContentType.TabIndex = 49;
            this.comboBoxContentType.TextChanged += new System.EventHandler(this.comboBoxContentType_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Location = new System.Drawing.Point(446, 9);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(6, 462);
            this.panel1.TabIndex = 50;
            // 
            // comboBoxVerbs
            // 
            this.comboBoxVerbs.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxVerbs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVerbs.FormattingEnabled = true;
            this.comboBoxVerbs.Location = new System.Drawing.Point(70, 68);
            this.comboBoxVerbs.Name = "comboBoxVerbs";
            this.comboBoxVerbs.Size = new System.Drawing.Size(95, 21);
            this.comboBoxVerbs.Sorted = true;
            this.comboBoxVerbs.TabIndex = 51;
            this.comboBoxVerbs.TextChanged += new System.EventHandler(this.comboBoxVerbs_TextChanged);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // FormHttpViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 509);
            this.Controls.Add(this.comboBoxVerbs);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comboBoxContentType);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBoxMsgInfo);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxContentTypeResp);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxStatusDescResp);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBoxStatusCodeResp);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxHeadersResp);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxHeaders);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxBodyResp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxBody);
            this.Controls.Add(this.textBoxResource);
            this.Controls.Add(this.textBoxHost);
            this.Controls.Add(this.buttonSend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormHttpViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Send HTTP Request";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxHost;
        private System.Windows.Forms.TextBox textBoxResource;
        private System.Windows.Forms.TextBox textBoxBody;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxBodyResp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxHeaders;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxHeadersResp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxStatusDescResp;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxStatusCodeResp;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxContentTypeResp;
        private System.Windows.Forms.TextBox textBoxMsgInfo;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBoxContentType;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxVerbs;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

