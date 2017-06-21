namespace Live_Performance
{
    partial class ChangePartyName
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
            this.tbNewPartyName = new System.Windows.Forms.TextBox();
            this.btnChangePartyName = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbNewPartyName
            // 
            this.tbNewPartyName.Location = new System.Drawing.Point(12, 40);
            this.tbNewPartyName.Name = "tbNewPartyName";
            this.tbNewPartyName.Size = new System.Drawing.Size(303, 22);
            this.tbNewPartyName.TabIndex = 0;
            // 
            // btnChangePartyName
            // 
            this.btnChangePartyName.Location = new System.Drawing.Point(121, 82);
            this.btnChangePartyName.Name = "btnChangePartyName";
            this.btnChangePartyName.Size = new System.Drawing.Size(87, 25);
            this.btnChangePartyName.TabIndex = 1;
            this.btnChangePartyName.Text = "Opslaan";
            this.btnChangePartyName.UseVisualStyleBackColor = true;
            this.btnChangePartyName.Click += new System.EventHandler(this.btnChangePartyName_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nieuwe naam:";
            // 
            // ChangePartyName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(327, 119);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChangePartyName);
            this.Controls.Add(this.tbNewPartyName);
            this.Name = "ChangePartyName";
            this.Text = "Verander naam";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbNewPartyName;
        private System.Windows.Forms.Button btnChangePartyName;
        private System.Windows.Forms.Label label1;
    }
}