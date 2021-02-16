namespace rglib.wftest
{
    partial class FindPortsForm
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
            this.findUsbHid = new System.Windows.Forms.CheckBox();
            this.findSerial = new System.Windows.Forms.CheckBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.devicesList = new System.Windows.Forms.ListBox();
            this.connectionsBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // findUsbHid
            // 
            this.findUsbHid.AutoSize = true;
            this.findUsbHid.Checked = true;
            this.findUsbHid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.findUsbHid.Location = new System.Drawing.Point(6, 19);
            this.findUsbHid.Name = "findUsbHid";
            this.findUsbHid.Size = new System.Drawing.Size(70, 17);
            this.findUsbHid.TabIndex = 0;
            this.findUsbHid.Text = "USB HID";
            this.findUsbHid.UseVisualStyleBackColor = true;
            this.findUsbHid.CheckStateChanged += new System.EventHandler(this.CheckBoxCheckedStateChanged);
            // 
            // findSerial
            // 
            this.findSerial.AutoSize = true;
            this.findSerial.Checked = true;
            this.findSerial.CheckState = System.Windows.Forms.CheckState.Checked;
            this.findSerial.Location = new System.Drawing.Point(82, 19);
            this.findSerial.Name = "findSerial";
            this.findSerial.Size = new System.Drawing.Size(64, 17);
            this.findSerial.TabIndex = 0;
            this.findSerial.Text = "SERIAL";
            this.findSerial.UseVisualStyleBackColor = true;
            this.findSerial.CheckStateChanged += new System.EventHandler(this.CheckBoxCheckedStateChanged);
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(109, 335);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(85, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "Ок";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(201, 335);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(85, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.devicesList);
            this.groupBox1.Controls.Add(this.connectionsBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.findUsbHid);
            this.groupBox1.Controls.Add(this.findSerial);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 317);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поиск";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Доступные устройства";
            // 
            // devicesList
            // 
            this.devicesList.FormattingEnabled = true;
            this.devicesList.Location = new System.Drawing.Point(9, 98);
            this.devicesList.Name = "devicesList";
            this.devicesList.Size = new System.Drawing.Size(265, 212);
            this.devicesList.TabIndex = 0;
            // 
            // connectionsBox
            // 
            this.connectionsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.connectionsBox.FormattingEnabled = true;
            this.connectionsBox.Location = new System.Drawing.Point(9, 58);
            this.connectionsBox.Name = "connectionsBox";
            this.connectionsBox.Size = new System.Drawing.Size(265, 21);
            this.connectionsBox.TabIndex = 1;
            this.connectionsBox.SelectedIndexChanged += new System.EventHandler(this.PortListIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Доступные соединения";
            // 
            // FindPortsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 366);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FindPortsForm";
            this.Text = "Ports find";
            this.Load += new System.EventHandler(this.OnLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox findUsbHid;
        private System.Windows.Forms.CheckBox findSerial;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox devicesList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox connectionsBox;
        private System.Windows.Forms.Label label2;
    }
}