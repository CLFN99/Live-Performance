namespace Live_Performance
{
    partial class Main
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.navPanel = new System.Windows.Forms.Panel();
            this.listPanel = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ch1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.navPanel.SuspendLayout();
            this.listPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(5, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 48);
            this.button1.TabIndex = 0;
            this.button1.Text = "Partijen";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(109, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(277, 48);
            this.button2.TabIndex = 1;
            this.button2.Text = "Nieuwe verkiezingsuitslag";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(392, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 48);
            this.button3.TabIndex = 2;
            this.button3.Text = "Coalities";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(511, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(210, 48);
            this.button4.TabIndex = 3;
            this.button4.Text = "Verkiezingsuitslagen";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // navPanel
            // 
            this.navPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.navPanel.Controls.Add(this.button4);
            this.navPanel.Controls.Add(this.button1);
            this.navPanel.Controls.Add(this.button2);
            this.navPanel.Controls.Add(this.button3);
            this.navPanel.Location = new System.Drawing.Point(0, 0);
            this.navPanel.Name = "navPanel";
            this.navPanel.Size = new System.Drawing.Size(724, 74);
            this.navPanel.TabIndex = 5;
            // 
            // listPanel
            // 
            this.listPanel.Controls.Add(this.button6);
            this.listPanel.Controls.Add(this.button5);
            this.listPanel.Controls.Add(this.listView1);
            this.listPanel.Location = new System.Drawing.Point(0, 80);
            this.listPanel.Name = "listPanel";
            this.listPanel.Size = new System.Drawing.Size(724, 589);
            this.listPanel.TabIndex = 6;
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch1,
            this.ch2,
            this.ch3,
            this.ch4});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(12, 18);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(691, 489);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // ch1
            // 
            this.ch1.Text = "Partij";
            this.ch1.Width = 73;
            // 
            // ch2
            // 
            this.ch2.Text = "Partijnaam";
            this.ch2.Width = 285;
            // 
            // ch3
            // 
            this.ch3.Text = "Lijsttrekker";
            this.ch3.Width = 179;
            // 
            // ch4
            // 
            this.ch4.Text = "Zetels";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(511, 522);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(192, 55);
            this.button5.TabIndex = 1;
            this.button5.Text = "Meerderheid berekenen";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(368, 522);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(127, 55);
            this.button6.TabIndex = 2;
            this.button6.Text = "Nieuwe partij";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(724, 669);
            this.Controls.Add(this.listPanel);
            this.Controls.Add(this.navPanel);
            this.Name = "Main";
            this.Text = "Main";
            this.navPanel.ResumeLayout(false);
            this.listPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel navPanel;
        private System.Windows.Forms.Panel listPanel;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ch1;
        private System.Windows.Forms.ColumnHeader ch2;
        private System.Windows.Forms.ColumnHeader ch3;
        private System.Windows.Forms.ColumnHeader ch4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}

