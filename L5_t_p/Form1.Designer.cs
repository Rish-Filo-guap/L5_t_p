namespace L5_t_p
{
    partial class Form1
    {

        private System.ComponentModel.IContainer components = null;

        
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
            label1 = new Label();
            StartStation = new Label();
            EndStation = new Label();
            listBox2 = new ListBox();
            WaylenthLabel = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ShowAllWeight_Button = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(1461, 555);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 2;
            label1.Text = "Маршрут";
            // 
            // StartStation
            // 
            StartStation.AutoSize = true;
            StartStation.Location = new Point(143, 18);
            StartStation.Margin = new Padding(2, 0, 2, 0);
            StartStation.Name = "StartStation";
            StartStation.Size = new Size(50, 20);
            StartStation.TabIndex = 4;
            StartStation.Text = "label2";
            // 
            // EndStation
            // 
            EndStation.AutoSize = true;
            EndStation.Location = new Point(385, 18);
            EndStation.Margin = new Padding(2, 0, 2, 0);
            EndStation.Name = "EndStation";
            EndStation.Size = new Size(50, 20);
            EndStation.TabIndex = 5;
            EndStation.Text = "label2";
            // 
            // listBox2
            // 
            listBox2.Anchor = AnchorStyles.None;
            listBox2.Font = new Font("Segoe UI", 10F);
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 23;
            listBox2.Location = new Point(1439, 590);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(397, 418);
            listBox2.TabIndex = 6;
            // 
            // WaylenthLabel
            // 
            WaylenthLabel.Anchor = AnchorStyles.None;
            WaylenthLabel.AutoSize = true;
            WaylenthLabel.Location = new Point(1737, 555);
            WaylenthLabel.Name = "WaylenthLabel";
            WaylenthLabel.Size = new Size(50, 20);
            WaylenthLabel.TabIndex = 7;
            WaylenthLabel.Text = "label2";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 18);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(96, 20);
            label2.TabIndex = 8;
            label2.Text = "Маршрут из:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(321, 18);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(20, 20);
            label3.TabIndex = 9;
            label3.Text = "в:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Location = new Point(1737, 523);
            label4.Name = "label4";
            label4.Size = new Size(54, 20);
            label4.TabIndex = 10;
            label4.Text = "Время";
            // 
            // ShowAllWeight_Button
            // 
            ShowAllWeight_Button.Location = new Point(11, 57);
            ShowAllWeight_Button.Margin = new Padding(2);
            ShowAllWeight_Button.Name = "ShowAllWeight_Button";
            ShowAllWeight_Button.Size = new Size(102, 59);
            ShowAllWeight_Button.TabIndex = 11;
            ShowAllWeight_Button.Text = "Показать все веса";
            ShowAllWeight_Button.UseVisualStyleBackColor = true;
            ShowAllWeight_Button.Click += ShowAllWeight_Button_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1848, 1046);
            Controls.Add(ShowAllWeight_Button);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(WaylenthLabel);
            Controls.Add(listBox2);
            Controls.Add(EndStation);
            Controls.Add(StartStation);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            MouseDown += Form1_MouseDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label StartStation;
        private Label EndStation;
        private ListBox listBox2;
        private Label WaylenthLabel;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button ShowAllWeight_Button;
    }
}
