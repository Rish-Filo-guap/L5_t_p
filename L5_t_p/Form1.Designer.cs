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
            button1.Location = new Point(33, 41);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(12, 76);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(150, 104);
            listBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(67, 209);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // findwayButton
            // 
            findwayButton.Location = new Point(32, 253);
            findwayButton.Margin = new Padding(2);
            findwayButton.Name = "findwayButton";
            findwayButton.Size = new Size(87, 27);
            findwayButton.TabIndex = 3;
            findwayButton.Text = "button2";
            findwayButton.UseVisualStyleBackColor = true;
            findwayButton.Click += findwayButton_Click;
            // 
            // StartStation
            // 
            StartStation.AutoSize = true;
            StartStation.Location = new Point(207, 46);
            StartStation.Margin = new Padding(2, 0, 2, 0);
            StartStation.Name = "StartStation";
            StartStation.Size = new Size(50, 20);
            StartStation.TabIndex = 4;
            StartStation.Text = "label2";
            // 
            // EndStation
            // 
            EndStation.AutoSize = true;
            EndStation.Location = new Point(207, 84);
            EndStation.Margin = new Padding(2, 0, 2, 0);
            EndStation.Name = "EndStation";
            EndStation.Size = new Size(50, 20);
            EndStation.TabIndex = 5;
            EndStation.Text = "label2";
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.Location = new Point(373, 41);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(150, 104);
            listBox2.TabIndex = 6;
            // 
            // WaylenthLabel
            // 
            WaylenthLabel.AutoSize = true;
            WaylenthLabel.Location = new Point(411, 147);
            WaylenthLabel.Name = "WaylenthLabel";
            WaylenthLabel.Size = new Size(50, 20);
            WaylenthLabel.TabIndex = 7;
            WaylenthLabel.Text = "label2";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1848, 1046);
            Controls.Add(WaylenthLabel);
            Controls.Add(listBox2);
            Controls.Add(EndStation);
            Controls.Add(StartStation);
            Controls.Add(findwayButton);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Controls.Add(button1);
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
