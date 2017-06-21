namespace Live_Performance
{
    partial class Party
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
            this.lbPartyMembers = new System.Windows.Forms.ListBox();
            this.lblPartyName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lblPartyAfk = new System.Windows.Forms.Label();
            this.lblPartyRep = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.lblSeats = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbPartyMembers
            // 
            this.lbPartyMembers.FormattingEnabled = true;
            this.lbPartyMembers.ItemHeight = 16;
            this.lbPartyMembers.Location = new System.Drawing.Point(12, 146);
            this.lbPartyMembers.Name = "lbPartyMembers";
            this.lbPartyMembers.Size = new System.Drawing.Size(224, 244);
            this.lbPartyMembers.TabIndex = 0;
            // 
            // lblPartyName
            // 
            this.lblPartyName.AutoSize = true;
            this.lblPartyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartyName.Location = new System.Drawing.Point(8, 9);
            this.lblPartyName.Name = "lblPartyName";
            this.lblPartyName.Size = new System.Drawing.Size(97, 24);
            this.lblPartyName.TabIndex = 1;
            this.lblPartyName.Text = "Partijnaam";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Leden:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(242, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "Nieuw lid";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(242, 180);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 29);
            this.button2.TabIndex = 4;
            this.button2.Text = "Lid verwijderen";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(435, 361);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 29);
            this.button3.TabIndex = 5;
            this.button3.Text = "Partij verwijderen";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(435, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(150, 29);
            this.button4.TabIndex = 6;
            this.button4.Text = "Naam wijzigen";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // lblPartyAfk
            // 
            this.lblPartyAfk.AutoSize = true;
            this.lblPartyAfk.Location = new System.Drawing.Point(9, 40);
            this.lblPartyAfk.Name = "lblPartyAfk";
            this.lblPartyAfk.Size = new System.Drawing.Size(63, 17);
            this.lblPartyAfk.TabIndex = 8;
            this.lblPartyAfk.Text = "afkorting";
            // 
            // lblPartyRep
            // 
            this.lblPartyRep.AutoSize = true;
            this.lblPartyRep.Location = new System.Drawing.Point(9, 66);
            this.lblPartyRep.Name = "lblPartyRep";
            this.lblPartyRep.Size = new System.Drawing.Size(85, 17);
            this.lblPartyRep.TabIndex = 9;
            this.lblPartyRep.Text = "Lijsttrekker: ";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(435, 60);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(150, 29);
            this.button5.TabIndex = 10;
            this.button5.Text = "Lijsttrekker wijzigen";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // lblSeats
            // 
            this.lblSeats.AutoSize = true;
            this.lblSeats.Location = new System.Drawing.Point(9, 92);
            this.lblSeats.Name = "lblSeats";
            this.lblSeats.Size = new System.Drawing.Size(51, 17);
            this.lblSeats.TabIndex = 11;
            this.lblSeats.Text = "Zetels:";
            // 
            // Party
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(597, 402);
            this.Controls.Add(this.lblSeats);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.lblPartyRep);
            this.Controls.Add(this.lblPartyAfk);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPartyName);
            this.Controls.Add(this.lbPartyMembers);
            this.Name = "Party";
            this.Text = "Partij";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbPartyMembers;
        private System.Windows.Forms.Label lblPartyName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblPartyAfk;
        private System.Windows.Forms.Label lblPartyRep;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label lblSeats;
    }
}