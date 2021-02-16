namespace rglib.wftest
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripLibVersionText = new System.Windows.Forms.ToolStripStatusLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.connectionStringTextBox = new System.Windows.Forms.TextBox();
            this.addressUpDown = new System.Windows.Forms.NumericUpDown();
            this.readerDataGroup = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toPullUp = new System.Windows.Forms.RadioButton();
            this.toGround = new System.Windows.Forms.RadioButton();
            this.enableBlue = new System.Windows.Forms.CheckBox();
            this.enableSound = new System.Windows.Forms.CheckBox();
            this.controlOutTime = new System.Windows.Forms.NumericUpDown();
            this.enableRed = new System.Windows.Forms.CheckBox();
            this.enableGreen = new System.Windows.Forms.CheckBox();
            this.blueBox = new System.Windows.Forms.ComboBox();
            this.priotiryBox = new System.Windows.Forms.ComboBox();
            this.redBox = new System.Windows.Forms.ComboBox();
            this.greenBox = new System.Windows.Forms.ComboBox();
            this.codogrammsComboBox = new System.Windows.Forms.ComboBox();
            this.soundBox = new System.Windows.Forms.ComboBox();
            this.cardMemoryTextBox = new System.Windows.Forms.TextBox();
            this.cardUidTextBox = new System.Windows.Forms.TextBox();
            this.cardCodeTextBox = new System.Windows.Forms.TextBox();
            this.cardTypeTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.profilesListBox = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.button7 = new System.Windows.Forms.Button();
            this.controlOutSet = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.clearAllProfiles = new System.Windows.Forms.Button();
            this.writeAllProfiles = new System.Windows.Forms.Button();
            this.writeSelectedProfiles = new System.Windows.Forms.Button();
            this.editSelectedProfile = new System.Windows.Forms.Button();
            this.editCodogramm = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.setMaskResetButton = new System.Windows.Forms.Button();
            this.setMaskAllButton = new System.Windows.Forms.Button();
            this.setMaskSelectedButton = new System.Windows.Forms.Button();
            this.profileNumBox = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addressUpDown)).BeginInit();
            this.readerDataGroup.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlOutTime)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLibVersionText});
            this.statusStrip1.Location = new System.Drawing.Point(0, 810);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(434, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripLibVersionText
            // 
            this.toolStripLibVersionText.Name = "toolStripLibVersionText";
            this.toolStripLibVersionText.Size = new System.Drawing.Size(0, 17);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 21);
            this.button1.TabIndex = 2;
            this.button1.Text = "Поиск портов и утройств...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.RefreshPortsButtonClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.connectionStringTextBox);
            this.groupBox1.Controls.Add(this.addressUpDown);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 87);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Данные подключения";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Адрес";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Строка подключения";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(305, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 21);
            this.button2.TabIndex = 2;
            this.button2.Text = "Подключиться...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ConnectButtonClick);
            // 
            // connectionStringTextBox
            // 
            this.connectionStringTextBox.Enabled = false;
            this.connectionStringTextBox.Location = new System.Drawing.Point(6, 32);
            this.connectionStringTextBox.Name = "connectionStringTextBox";
            this.connectionStringTextBox.Size = new System.Drawing.Size(293, 20);
            this.connectionStringTextBox.TabIndex = 3;
            // 
            // addressUpDown
            // 
            this.addressUpDown.Enabled = false;
            this.addressUpDown.Location = new System.Drawing.Point(305, 32);
            this.addressUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.addressUpDown.Name = "addressUpDown";
            this.addressUpDown.Size = new System.Drawing.Size(96, 20);
            this.addressUpDown.TabIndex = 4;
            // 
            // readerDataGroup
            // 
            this.readerDataGroup.Controls.Add(this.label11);
            this.readerDataGroup.Controls.Add(this.label10);
            this.readerDataGroup.Controls.Add(this.panel1);
            this.readerDataGroup.Controls.Add(this.enableBlue);
            this.readerDataGroup.Controls.Add(this.enableSound);
            this.readerDataGroup.Controls.Add(this.controlOutTime);
            this.readerDataGroup.Controls.Add(this.enableRed);
            this.readerDataGroup.Controls.Add(this.enableGreen);
            this.readerDataGroup.Controls.Add(this.blueBox);
            this.readerDataGroup.Controls.Add(this.priotiryBox);
            this.readerDataGroup.Controls.Add(this.redBox);
            this.readerDataGroup.Controls.Add(this.greenBox);
            this.readerDataGroup.Controls.Add(this.codogrammsComboBox);
            this.readerDataGroup.Controls.Add(this.soundBox);
            this.readerDataGroup.Controls.Add(this.cardMemoryTextBox);
            this.readerDataGroup.Controls.Add(this.cardUidTextBox);
            this.readerDataGroup.Controls.Add(this.profileNumBox);
            this.readerDataGroup.Controls.Add(this.cardCodeTextBox);
            this.readerDataGroup.Controls.Add(this.cardTypeTextBox);
            this.readerDataGroup.Controls.Add(this.label5);
            this.readerDataGroup.Controls.Add(this.label8);
            this.readerDataGroup.Controls.Add(this.label9);
            this.readerDataGroup.Controls.Add(this.label7);
            this.readerDataGroup.Controls.Add(this.label12);
            this.readerDataGroup.Controls.Add(this.label6);
            this.readerDataGroup.Controls.Add(this.label4);
            this.readerDataGroup.Controls.Add(this.label3);
            this.readerDataGroup.Controls.Add(this.profilesListBox);
            this.readerDataGroup.Controls.Add(this.checkedListBox1);
            this.readerDataGroup.Controls.Add(this.button7);
            this.readerDataGroup.Controls.Add(this.controlOutSet);
            this.readerDataGroup.Controls.Add(this.button3);
            this.readerDataGroup.Controls.Add(this.clearAllProfiles);
            this.readerDataGroup.Controls.Add(this.writeAllProfiles);
            this.readerDataGroup.Controls.Add(this.writeSelectedProfiles);
            this.readerDataGroup.Controls.Add(this.editSelectedProfile);
            this.readerDataGroup.Controls.Add(this.editCodogramm);
            this.readerDataGroup.Controls.Add(this.button6);
            this.readerDataGroup.Controls.Add(this.setMaskResetButton);
            this.readerDataGroup.Controls.Add(this.setMaskAllButton);
            this.readerDataGroup.Controls.Add(this.setMaskSelectedButton);
            this.readerDataGroup.Location = new System.Drawing.Point(12, 105);
            this.readerDataGroup.Name = "readerDataGroup";
            this.readerDataGroup.Size = new System.Drawing.Size(410, 694);
            this.readerDataGroup.TabIndex = 4;
            this.readerDataGroup.TabStop = false;
            this.readerDataGroup.Text = "Данные считывателя";
            this.readerDataGroup.Enter += new System.EventHandler(this.readerDataGroup_Enter);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 637);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Направление";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 608);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Время переключения";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toPullUp);
            this.panel1.Controls.Add(this.toGround);
            this.panel1.Location = new System.Drawing.Point(195, 633);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(107, 48);
            this.panel1.TabIndex = 14;
            // 
            // toPullUp
            // 
            this.toPullUp.AutoSize = true;
            this.toPullUp.Location = new System.Drawing.Point(11, 26);
            this.toPullUp.Name = "toPullUp";
            this.toPullUp.Size = new System.Drawing.Size(83, 17);
            this.toPullUp.TabIndex = 15;
            this.toPullUp.TabStop = true;
            this.toPullUp.Text = "к подтяжке";
            this.toPullUp.UseVisualStyleBackColor = true;
            // 
            // toGround
            // 
            this.toGround.AutoSize = true;
            this.toGround.Checked = true;
            this.toGround.Location = new System.Drawing.Point(11, 3);
            this.toGround.Name = "toGround";
            this.toGround.Size = new System.Drawing.Size(66, 17);
            this.toGround.TabIndex = 15;
            this.toGround.TabStop = true;
            this.toGround.Text = "к земле";
            this.toGround.UseVisualStyleBackColor = true;
            // 
            // enableBlue
            // 
            this.enableBlue.AutoSize = true;
            this.enableBlue.Checked = true;
            this.enableBlue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableBlue.Location = new System.Drawing.Point(6, 553);
            this.enableBlue.Name = "enableBlue";
            this.enableBlue.Size = new System.Drawing.Size(57, 17);
            this.enableBlue.TabIndex = 13;
            this.enableBlue.Text = "Синий";
            this.enableBlue.UseVisualStyleBackColor = true;
            // 
            // enableSound
            // 
            this.enableSound.AutoSize = true;
            this.enableSound.Location = new System.Drawing.Point(6, 471);
            this.enableSound.Name = "enableSound";
            this.enableSound.Size = new System.Drawing.Size(50, 17);
            this.enableSound.TabIndex = 13;
            this.enableSound.Text = "Звук";
            this.enableSound.UseVisualStyleBackColor = true;
            // 
            // controlOutTime
            // 
            this.controlOutTime.Location = new System.Drawing.Point(206, 607);
            this.controlOutTime.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.controlOutTime.Name = "controlOutTime";
            this.controlOutTime.Size = new System.Drawing.Size(96, 20);
            this.controlOutTime.TabIndex = 4;
            this.controlOutTime.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // enableRed
            // 
            this.enableRed.AutoSize = true;
            this.enableRed.Checked = true;
            this.enableRed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableRed.Location = new System.Drawing.Point(6, 499);
            this.enableRed.Name = "enableRed";
            this.enableRed.Size = new System.Drawing.Size(71, 17);
            this.enableRed.TabIndex = 13;
            this.enableRed.Text = "Красный";
            this.enableRed.UseVisualStyleBackColor = true;
            // 
            // enableGreen
            // 
            this.enableGreen.AutoSize = true;
            this.enableGreen.Checked = true;
            this.enableGreen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableGreen.Location = new System.Drawing.Point(6, 526);
            this.enableGreen.Name = "enableGreen";
            this.enableGreen.Size = new System.Drawing.Size(71, 17);
            this.enableGreen.TabIndex = 13;
            this.enableGreen.Text = "Зеленый";
            this.enableGreen.UseVisualStyleBackColor = true;
            // 
            // blueBox
            // 
            this.blueBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.blueBox.FormattingEnabled = true;
            this.blueBox.Location = new System.Drawing.Point(78, 551);
            this.blueBox.Name = "blueBox";
            this.blueBox.Size = new System.Drawing.Size(224, 21);
            this.blueBox.TabIndex = 11;
            // 
            // priotiryBox
            // 
            this.priotiryBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.priotiryBox.FormattingEnabled = true;
            this.priotiryBox.Items.AddRange(new object[] {
            "[0]   Фоновое выполнение",
            "[1]   Циличное выполнение",
            "[2]   Циличное приоритетное",
            "[3]   Разовое",
            "[4]   Разовое приоритетное"});
            this.priotiryBox.Location = new System.Drawing.Point(78, 442);
            this.priotiryBox.Name = "priotiryBox";
            this.priotiryBox.Size = new System.Drawing.Size(224, 21);
            this.priotiryBox.TabIndex = 11;
            // 
            // redBox
            // 
            this.redBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.redBox.FormattingEnabled = true;
            this.redBox.Location = new System.Drawing.Point(78, 497);
            this.redBox.Name = "redBox";
            this.redBox.Size = new System.Drawing.Size(224, 21);
            this.redBox.TabIndex = 11;
            // 
            // greenBox
            // 
            this.greenBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.greenBox.FormattingEnabled = true;
            this.greenBox.Location = new System.Drawing.Point(78, 524);
            this.greenBox.Name = "greenBox";
            this.greenBox.Size = new System.Drawing.Size(224, 21);
            this.greenBox.TabIndex = 11;
            // 
            // codogrammsComboBox
            // 
            this.codogrammsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codogrammsComboBox.FormattingEnabled = true;
            this.codogrammsComboBox.Location = new System.Drawing.Point(6, 381);
            this.codogrammsComboBox.Name = "codogrammsComboBox";
            this.codogrammsComboBox.Size = new System.Drawing.Size(296, 21);
            this.codogrammsComboBox.TabIndex = 11;
            // 
            // soundBox
            // 
            this.soundBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.soundBox.FormattingEnabled = true;
            this.soundBox.Location = new System.Drawing.Point(78, 469);
            this.soundBox.Name = "soundBox";
            this.soundBox.Size = new System.Drawing.Size(224, 21);
            this.soundBox.TabIndex = 11;
            this.soundBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cardMemoryTextBox
            // 
            this.cardMemoryTextBox.Enabled = false;
            this.cardMemoryTextBox.Location = new System.Drawing.Point(37, 333);
            this.cardMemoryTextBox.Name = "cardMemoryTextBox";
            this.cardMemoryTextBox.ReadOnly = true;
            this.cardMemoryTextBox.Size = new System.Drawing.Size(262, 20);
            this.cardMemoryTextBox.TabIndex = 10;
            // 
            // cardUidTextBox
            // 
            this.cardUidTextBox.Enabled = false;
            this.cardUidTextBox.Location = new System.Drawing.Point(152, 307);
            this.cardUidTextBox.Name = "cardUidTextBox";
            this.cardUidTextBox.ReadOnly = true;
            this.cardUidTextBox.Size = new System.Drawing.Size(147, 20);
            this.cardUidTextBox.TabIndex = 10;
            // 
            // cardCodeTextBox
            // 
            this.cardCodeTextBox.Enabled = false;
            this.cardCodeTextBox.Location = new System.Drawing.Point(6, 307);
            this.cardCodeTextBox.Name = "cardCodeTextBox";
            this.cardCodeTextBox.ReadOnly = true;
            this.cardCodeTextBox.Size = new System.Drawing.Size(25, 20);
            this.cardCodeTextBox.TabIndex = 10;
            this.cardCodeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cardTypeTextBox
            // 
            this.cardTypeTextBox.Enabled = false;
            this.cardTypeTextBox.Location = new System.Drawing.Point(37, 307);
            this.cardTypeTextBox.Name = "cardTypeTextBox";
            this.cardTypeTextBox.ReadOnly = true;
            this.cardTypeTextBox.Size = new System.Drawing.Size(109, 20);
            this.cardTypeTextBox.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(149, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "UID карты";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 587);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(189, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Управление контрольным выходом";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 446);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Приоритет";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 419);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Запус киндикации";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 153);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(111, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Доступные профили";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 365);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Доступные кодограммы";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Тип карты";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Установка типов считываемых карт";
            // 
            // profilesListBox
            // 
            this.profilesListBox.CheckOnClick = true;
            this.profilesListBox.FormattingEnabled = true;
            this.profilesListBox.Location = new System.Drawing.Point(6, 169);
            this.profilesListBox.Name = "profilesListBox";
            this.profilesListBox.Size = new System.Drawing.Size(293, 109);
            this.profilesListBox.TabIndex = 7;
            this.profilesListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.DoProfileCheck);
            this.profilesListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DoProfileCheckDown);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(6, 32);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(293, 109);
            this.checkedListBox1.TabIndex = 7;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(308, 332);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(96, 21);
            this.button7.TabIndex = 6;
            this.button7.Text = "Вкл. опрос";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.PollButtonClick);
            // 
            // controlOutSet
            // 
            this.controlOutSet.Location = new System.Drawing.Point(308, 605);
            this.controlOutSet.Name = "controlOutSet";
            this.controlOutSet.Size = new System.Drawing.Size(96, 23);
            this.controlOutSet.TabIndex = 6;
            this.controlOutSet.Text = "Задать сост.";
            this.controlOutSet.UseVisualStyleBackColor = true;
            this.controlOutSet.Click += new System.EventHandler(this.controlOutSet_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(308, 441);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Запустить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.StartIndicationClick);
            // 
            // clearAllProfiles
            // 
            this.clearAllProfiles.Location = new System.Drawing.Point(308, 255);
            this.clearAllProfiles.Name = "clearAllProfiles";
            this.clearAllProfiles.Size = new System.Drawing.Size(96, 23);
            this.clearAllProfiles.TabIndex = 6;
            this.clearAllProfiles.Text = "Сбросить";
            this.clearAllProfiles.UseVisualStyleBackColor = true;
            this.clearAllProfiles.Click += new System.EventHandler(this.ResetProfilesClick);
            // 
            // writeAllProfiles
            // 
            this.writeAllProfiles.Location = new System.Drawing.Point(308, 226);
            this.writeAllProfiles.Name = "writeAllProfiles";
            this.writeAllProfiles.Size = new System.Drawing.Size(96, 23);
            this.writeAllProfiles.TabIndex = 6;
            this.writeAllProfiles.Text = "Уст. все";
            this.writeAllProfiles.UseVisualStyleBackColor = true;
            this.writeAllProfiles.Click += new System.EventHandler(this.WriteAllPRofiles);
            // 
            // writeSelectedProfiles
            // 
            this.writeSelectedProfiles.Location = new System.Drawing.Point(308, 197);
            this.writeSelectedProfiles.Name = "writeSelectedProfiles";
            this.writeSelectedProfiles.Size = new System.Drawing.Size(96, 23);
            this.writeSelectedProfiles.TabIndex = 6;
            this.writeSelectedProfiles.Text = "Уст. выбран.";
            this.writeSelectedProfiles.UseVisualStyleBackColor = true;
            this.writeSelectedProfiles.Click += new System.EventHandler(this.WriteSelectedProfiles);
            // 
            // editSelectedProfile
            // 
            this.editSelectedProfile.Location = new System.Drawing.Point(308, 168);
            this.editSelectedProfile.Name = "editSelectedProfile";
            this.editSelectedProfile.Size = new System.Drawing.Size(96, 23);
            this.editSelectedProfile.TabIndex = 6;
            this.editSelectedProfile.Text = "Редактировать";
            this.editSelectedProfile.UseVisualStyleBackColor = true;
            this.editSelectedProfile.Click += new System.EventHandler(this.EditSelectedProfileClick);
            // 
            // editCodogramm
            // 
            this.editCodogramm.Location = new System.Drawing.Point(308, 380);
            this.editCodogramm.Name = "editCodogramm";
            this.editCodogramm.Size = new System.Drawing.Size(96, 23);
            this.editCodogramm.TabIndex = 6;
            this.editCodogramm.Text = "Редактировать";
            this.editCodogramm.UseVisualStyleBackColor = true;
            this.editCodogramm.Click += new System.EventHandler(this.EditCodogrammSelected);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(308, 307);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(96, 21);
            this.button6.TabIndex = 6;
            this.button6.Text = "Запросить";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.RequestStatusClick);
            // 
            // setMaskResetButton
            // 
            this.setMaskResetButton.Location = new System.Drawing.Point(308, 90);
            this.setMaskResetButton.Name = "setMaskResetButton";
            this.setMaskResetButton.Size = new System.Drawing.Size(96, 23);
            this.setMaskResetButton.TabIndex = 6;
            this.setMaskResetButton.Text = "Сбросить";
            this.setMaskResetButton.UseVisualStyleBackColor = true;
            this.setMaskResetButton.Click += new System.EventHandler(this.SetMaskResetClick);
            // 
            // setMaskAllButton
            // 
            this.setMaskAllButton.Location = new System.Drawing.Point(308, 61);
            this.setMaskAllButton.Name = "setMaskAllButton";
            this.setMaskAllButton.Size = new System.Drawing.Size(96, 23);
            this.setMaskAllButton.TabIndex = 6;
            this.setMaskAllButton.Text = "Уст. все";
            this.setMaskAllButton.UseVisualStyleBackColor = true;
            this.setMaskAllButton.Click += new System.EventHandler(this.SetMaskAllClick);
            // 
            // setMaskSelectedButton
            // 
            this.setMaskSelectedButton.Location = new System.Drawing.Point(308, 32);
            this.setMaskSelectedButton.Name = "setMaskSelectedButton";
            this.setMaskSelectedButton.Size = new System.Drawing.Size(96, 23);
            this.setMaskSelectedButton.TabIndex = 6;
            this.setMaskSelectedButton.Text = "Уст. выбран.";
            this.setMaskSelectedButton.UseVisualStyleBackColor = true;
            this.setMaskSelectedButton.Click += new System.EventHandler(this.SetMaskClick);
            // 
            // profileNumBox
            // 
            this.profileNumBox.Enabled = false;
            this.profileNumBox.Location = new System.Drawing.Point(6, 333);
            this.profileNumBox.Name = "profileNumBox";
            this.profileNumBox.ReadOnly = true;
            this.profileNumBox.Size = new System.Drawing.Size(25, 20);
            this.profileNumBox.TabIndex = 10;
            this.profileNumBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 832);
            this.Controls.Add(this.readerDataGroup);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reader interop test";
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addressUpDown)).EndInit();
            this.readerDataGroup.ResumeLayout(false);
            this.readerDataGroup.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlOutTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLibVersionText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox connectionStringTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown addressUpDown;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox readerDataGroup;
        private System.Windows.Forms.Button setMaskSelectedButton;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.TextBox cardUidTextBox;
        private System.Windows.Forms.TextBox cardTypeTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button setMaskResetButton;
        private System.Windows.Forms.Button setMaskAllButton;
        private System.Windows.Forms.TextBox cardMemoryTextBox;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ComboBox soundBox;
        private System.Windows.Forms.ComboBox redBox;
        private System.Windows.Forms.ComboBox blueBox;
        private System.Windows.Forms.ComboBox greenBox;
        private System.Windows.Forms.Button editCodogramm;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button controlOutSet;
        private System.Windows.Forms.ComboBox codogrammsComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox enableBlue;
        private System.Windows.Forms.CheckBox enableSound;
        private System.Windows.Forms.CheckBox enableRed;
        private System.Windows.Forms.CheckBox enableGreen;
        private System.Windows.Forms.ComboBox priotiryBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton toPullUp;
        private System.Windows.Forms.RadioButton toGround;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown controlOutTime;
        private System.Windows.Forms.TextBox cardCodeTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckedListBox profilesListBox;
        private System.Windows.Forms.Button clearAllProfiles;
        private System.Windows.Forms.Button writeAllProfiles;
        private System.Windows.Forms.Button writeSelectedProfiles;
        private System.Windows.Forms.Button editSelectedProfile;
        private Be.Windows.Forms.HexBox hexBox1;
        private System.Windows.Forms.TextBox profileNumBox;
    }
}

