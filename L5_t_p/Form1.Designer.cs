namespace L5_t_p
{
    partial class Form1
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
            button1 = new Button();
            listBox1 = new ListBox();
            label1 = new Label();
            findwayButton = new Button();
            StartStation = new Label();
            EndStation = new Label();
            listBox2 = new ListBox();
            WaylenthLabel = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(50, 62);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(141, 44);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 30;
            listBox1.Location = new Point(18, 114);
            listBox1.Margin = new Padding(4);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(223, 154);
            listBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(100, 314);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(68, 30);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // findwayButton
            // 
            findwayButton.Location = new Point(48, 379);
            findwayButton.Name = "findwayButton";
            findwayButton.Size = new Size(131, 40);
            findwayButton.TabIndex = 3;
            findwayButton.Text = "button2";
            findwayButton.UseVisualStyleBackColor = true;
            findwayButton.Click += findwayButton_Click;
            // 
            // StartStation
            // 
            StartStation.AutoSize = true;
            StartStation.Location = new Point(311, 69);
            StartStation.Name = "StartStation";
            StartStation.Size = new Size(68, 30);
            StartStation.TabIndex = 4;
            StartStation.Text = "label2";
            // 
            // EndStation
            // 
            EndStation.AutoSize = true;
            EndStation.Location = new Point(311, 126);
            EndStation.Name = "EndStation";
            EndStation.Size = new Size(68, 30);
            EndStation.TabIndex = 5;
            EndStation.Text = "label2";
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 30;
            listBox2.Location = new Point(560, 62);
            listBox2.Margin = new Padding(4);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(223, 154);
            listBox2.TabIndex = 6;
            // 
            // WaylenthLabel
            // 
            WaylenthLabel.AutoSize = true;
            WaylenthLabel.Location = new Point(617, 220);
            WaylenthLabel.Margin = new Padding(4, 0, 4, 0);
            WaylenthLabel.Name = "WaylenthLabel";
            WaylenthLabel.Size = new Size(68, 30);
            WaylenthLabel.TabIndex = 7;
            WaylenthLabel.Text = "label2";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2772, 1569);
            Controls.Add(WaylenthLabel);
            Controls.Add(listBox2);
            Controls.Add(EndStation);
            Controls.Add(StartStation);
            Controls.Add(findwayButton);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Controls.Add(button1);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            MouseDown += Form1_MouseDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ListBox listBox1;
        private Label label1;
        private Button findwayButton;
        private Label StartStation;
        private Label EndStation;
        private ListBox listBox2;
        private Label WaylenthLabel;
    }
}
