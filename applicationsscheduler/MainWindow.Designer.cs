namespace applicationsscheduler
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            label1 = new Label();
            searchProcessBox = new TextBox();
            processListBox = new ListBox();
            killProcessBtn = new Button();
            refreshProcessBtn = new Button();
            label2 = new Label();
            selectedProcessLabel = new Label();
            label3 = new Label();
            label4 = new Label();
            dateStart = new DateTimePicker();
            dateEnd = new DateTimePicker();
            sleepTextBox = new TextBox();
            sleepButton = new Button();
            currentTimeLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 0;
            label1.Text = "Search process:";
            // 
            // searchProcessBox
            // 
            searchProcessBox.Location = new Point(101, 6);
            searchProcessBox.Name = "searchProcessBox";
            searchProcessBox.PlaceholderText = "Search";
            searchProcessBox.Size = new Size(93, 23);
            searchProcessBox.TabIndex = 1;
            searchProcessBox.TextChanged += searchProcessBox_TextChanged;
            // 
            // processListBox
            // 
            processListBox.FormattingEnabled = true;
            processListBox.ItemHeight = 15;
            processListBox.Location = new Point(12, 35);
            processListBox.Name = "processListBox";
            processListBox.Size = new Size(182, 169);
            processListBox.TabIndex = 2;
            processListBox.SelectedValueChanged += processListBox_SelectedValueChanged;
            // 
            // killProcessBtn
            // 
            killProcessBtn.Location = new Point(12, 210);
            killProcessBtn.Name = "killProcessBtn";
            killProcessBtn.Size = new Size(46, 23);
            killProcessBtn.TabIndex = 3;
            killProcessBtn.Text = "Kill";
            killProcessBtn.UseVisualStyleBackColor = true;
            killProcessBtn.Click += killProcessBtn_Click;
            // 
            // refreshProcessBtn
            // 
            refreshProcessBtn.Location = new Point(64, 210);
            refreshProcessBtn.Name = "refreshProcessBtn";
            refreshProcessBtn.Size = new Size(67, 23);
            refreshProcessBtn.TabIndex = 4;
            refreshProcessBtn.Text = "Refresh";
            refreshProcessBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(214, 9);
            label2.Name = "label2";
            label2.Size = new Size(97, 15);
            label2.TabIndex = 5;
            label2.Text = "Selected process:";
            // 
            // selectedProcessLabel
            // 
            selectedProcessLabel.AutoSize = true;
            selectedProcessLabel.Location = new Point(314, 9);
            selectedProcessLabel.Name = "selectedProcessLabel";
            selectedProcessLabel.Size = new Size(0, 15);
            selectedProcessLabel.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(214, 52);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 7;
            label3.Text = "Start";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(214, 81);
            label4.Name = "label4";
            label4.Size = new Size(27, 15);
            label4.TabIndex = 8;
            label4.Text = "End";
            // 
            // dateStart
            // 
            dateStart.Format = DateTimePickerFormat.Custom;
            dateStart.Location = new Point(251, 46);
            dateStart.Name = "dateStart";
            dateStart.Size = new Size(162, 23);
            dateStart.TabIndex = 9;
            // 
            // dateEnd
            // 
            dateEnd.Format = DateTimePickerFormat.Custom;
            dateEnd.Location = new Point(251, 75);
            dateEnd.Name = "dateEnd";
            dateEnd.Size = new Size(162, 23);
            dateEnd.TabIndex = 10;
            // 
            // sleepTextBox
            // 
            sleepTextBox.Location = new Point(214, 133);
            sleepTextBox.Multiline = true;
            sleepTextBox.Name = "sleepTextBox";
            sleepTextBox.ReadOnly = true;
            sleepTextBox.Size = new Size(199, 71);
            sleepTextBox.TabIndex = 11;
            // 
            // sleepButton
            // 
            sleepButton.Location = new Point(214, 104);
            sleepButton.Name = "sleepButton";
            sleepButton.Size = new Size(199, 23);
            sleepButton.TabIndex = 12;
            sleepButton.Text = "Sleep";
            sleepButton.UseVisualStyleBackColor = true;
            // 
            // currentTimeLabel
            // 
            currentTimeLabel.AutoSize = true;
            currentTimeLabel.Location = new Point(364, 217);
            currentTimeLabel.Name = "currentTimeLabel";
            currentTimeLabel.Size = new Size(49, 15);
            currentTimeLabel.TabIndex = 13;
            currentTimeLabel.Text = "23:23:23";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(425, 241);
            Controls.Add(currentTimeLabel);
            Controls.Add(sleepButton);
            Controls.Add(sleepTextBox);
            Controls.Add(dateEnd);
            Controls.Add(dateStart);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(selectedProcessLabel);
            Controls.Add(label2);
            Controls.Add(refreshProcessBtn);
            Controls.Add(killProcessBtn);
            Controls.Add(processListBox);
            Controls.Add(searchProcessBox);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Applications scheduler";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox searchProcessBox;
        private ListBox processListBox;
        private Button killProcessBtn;
        private Button refreshProcessBtn;
        private Label label2;
        private Label selectedProcessLabel;
        private Label label3;
        private Label label4;
        private DateTimePicker dateStart;
        private DateTimePicker dateEnd;
        private TextBox sleepTextBox;
        private Button sleepButton;
        private Label currentTimeLabel;
    }
}