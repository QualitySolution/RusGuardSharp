namespace rglib.wftest
{
    partial class ProfilesEditDialog
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
            this.profileNameBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.profileBlockBox = new System.Windows.Forms.NumericUpDown();
            this.cryptoOneType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.hexBox1 = new Be.Windows.Forms.HexBox();
            this.mifareGroup = new System.Windows.Forms.GroupBox();
            this.hexBox2 = new Be.Windows.Forms.HexBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.aesKeyType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.payGroup = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.genKeyCheckBox = new System.Windows.Forms.CheckBox();
            this.presentKeyCheckBox = new System.Windows.Forms.CheckBox();
            this.emitKeyCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.profileBlockBox)).BeginInit();
            this.mifareGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.payGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // profileNameBox
            // 
            this.profileNameBox.Location = new System.Drawing.Point(104, 19);
            this.profileNameBox.Name = "profileNameBox";
            this.profileNameBox.Size = new System.Drawing.Size(342, 20);
            this.profileNameBox.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "Название:";
            // 
            // profileBlockBox
            // 
            this.profileBlockBox.Location = new System.Drawing.Point(120, 19);
            this.profileBlockBox.Name = "profileBlockBox";
            this.profileBlockBox.Size = new System.Drawing.Size(80, 20);
            this.profileBlockBox.TabIndex = 2;
            // 
            // cryptoOneType
            // 
            this.cryptoOneType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cryptoOneType.FormattingEnabled = true;
            this.cryptoOneType.Items.AddRange(new object[] {
            "Ключ А",
            "Ключ B"});
            this.cryptoOneType.Location = new System.Drawing.Point(110, 21);
            this.cryptoOneType.Name = "cryptoOneType";
            this.cryptoOneType.Size = new System.Drawing.Size(80, 21);
            this.cryptoOneType.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Номер блока:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Тип ключа:";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(406, 457);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(325, 457);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Данные ключа:";
            // 
            // hexBox1
            // 
            this.hexBox1.BytesPerLine = 8;
            this.hexBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.hexBox1.Location = new System.Drawing.Point(110, 48);
            this.hexBox1.Name = "hexBox1";
            this.hexBox1.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBox1.Size = new System.Drawing.Size(326, 23);
            this.hexBox1.StringViewVisible = true;
            this.hexBox1.TabIndex = 5;
            this.hexBox1.UseFixedBytesPerLine = true;
            // 
            // mifareGroup
            // 
            this.mifareGroup.Controls.Add(this.groupBox3);
            this.mifareGroup.Controls.Add(this.groupBox1);
            this.mifareGroup.Controls.Add(this.label3);
            this.mifareGroup.Controls.Add(this.profileBlockBox);
            this.mifareGroup.Location = new System.Drawing.Point(13, 93);
            this.mifareGroup.Name = "mifareGroup";
            this.mifareGroup.Size = new System.Drawing.Size(468, 256);
            this.mifareGroup.TabIndex = 0;
            this.mifareGroup.TabStop = false;
            this.mifareGroup.Text = "Mifare";
            // 
            // hexBox2
            // 
            this.hexBox2.BytesPerLine = 8;
            this.hexBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.hexBox2.Location = new System.Drawing.Point(111, 47);
            this.hexBox2.Name = "hexBox2";
            this.hexBox2.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBox2.Size = new System.Drawing.Size(325, 51);
            this.hexBox2.StringViewVisible = true;
            this.hexBox2.TabIndex = 8;
            this.hexBox2.UseFixedBytesPerLine = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Тип ключа:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Данные ключа:";
            // 
            // aesKeyType
            // 
            this.aesKeyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aesKeyType.FormattingEnabled = true;
            this.aesKeyType.Items.AddRange(new object[] {
            "Ключ А",
            "Ключ B"});
            this.aesKeyType.Location = new System.Drawing.Point(111, 20);
            this.aesKeyType.Name = "aesKeyType";
            this.aesKeyType.Size = new System.Drawing.Size(80, 21);
            this.aesKeyType.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.hexBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cryptoOneType);
            this.groupBox1.Location = new System.Drawing.Point(10, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 86);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CLASSIC";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.hexBox2);
            this.groupBox3.Controls.Add(this.aesKeyType);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(10, 138);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(448, 109);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PLUS";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.profileNameBox);
            this.groupBox2.Location = new System.Drawing.Point(13, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(468, 78);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Общие";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "Тип профиля:";
            // 
            // payGroup
            // 
            this.payGroup.Controls.Add(this.emitKeyCheckBox);
            this.payGroup.Controls.Add(this.presentKeyCheckBox);
            this.payGroup.Controls.Add(this.genKeyCheckBox);
            this.payGroup.Controls.Add(this.label8);
            this.payGroup.Location = new System.Drawing.Point(13, 355);
            this.payGroup.Name = "payGroup";
            this.payGroup.Size = new System.Drawing.Size(468, 96);
            this.payGroup.TabIndex = 53;
            this.payGroup.TabStop = false;
            this.payGroup.Text = "Apple/Google Pay и Мобильное приложение";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 51;
            this.label8.Text = "Типы ключей:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Mifare",
            "Apple/Google Pay",
            "Мобильное приложение"});
            this.comboBox1.Location = new System.Drawing.Point(104, 45);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(342, 21);
            this.comboBox1.TabIndex = 52;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ProfileTypeIndexChanged);
            // 
            // genKeyCheckBox
            // 
            this.genKeyCheckBox.AutoSize = true;
            this.genKeyCheckBox.Location = new System.Drawing.Point(120, 26);
            this.genKeyCheckBox.Name = "genKeyCheckBox";
            this.genKeyCheckBox.Size = new System.Drawing.Size(146, 17);
            this.genKeyCheckBox.TabIndex = 52;
            this.genKeyCheckBox.Text = "Сгенерированный ключ";
            this.genKeyCheckBox.UseVisualStyleBackColor = true;
            // 
            // presentKeyCheckBox
            // 
            this.presentKeyCheckBox.AutoSize = true;
            this.presentKeyCheckBox.Location = new System.Drawing.Point(120, 49);
            this.presentKeyCheckBox.Name = "presentKeyCheckBox";
            this.presentKeyCheckBox.Size = new System.Drawing.Size(105, 17);
            this.presentKeyCheckBox.TabIndex = 52;
            this.presentKeyCheckBox.Text = "Заданный ключ";
            this.presentKeyCheckBox.UseVisualStyleBackColor = true;
            // 
            // emitKeyCheckBox
            // 
            this.emitKeyCheckBox.AutoSize = true;
            this.emitKeyCheckBox.Location = new System.Drawing.Point(120, 72);
            this.emitKeyCheckBox.Name = "emitKeyCheckBox";
            this.emitKeyCheckBox.Size = new System.Drawing.Size(136, 17);
            this.emitKeyCheckBox.TabIndex = 52;
            this.emitKeyCheckBox.Text = "Эмитированный ключ";
            this.emitKeyCheckBox.UseVisualStyleBackColor = true;
            // 
            // ProfilesEditDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 490);
            this.Controls.Add(this.payGroup);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.mifareGroup);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProfilesEditDialog";
            this.Text = "ProfilesEditForm";
            this.Load += new System.EventHandler(this.ProfilesEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.profileBlockBox)).EndInit();
            this.mifareGroup.ResumeLayout(false);
            this.mifareGroup.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.payGroup.ResumeLayout(false);
            this.payGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cryptoOneType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown profileBlockBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox profileNameBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox mifareGroup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox aesKeyType;
        private Be.Windows.Forms.HexBox hexBox1;
        private Be.Windows.Forms.HexBox hexBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox payGroup;
        private System.Windows.Forms.CheckBox emitKeyCheckBox;
        private System.Windows.Forms.CheckBox presentKeyCheckBox;
        private System.Windows.Forms.CheckBox genKeyCheckBox;
        private System.Windows.Forms.Label label8;
    }
}