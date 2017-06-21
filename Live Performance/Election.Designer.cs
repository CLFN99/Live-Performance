namespace Live_Performance
{
    partial class Election
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.listView = new System.Windows.Forms.ListView();
            this.chParty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVotes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPercentage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSeats = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnUpdateElection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(12, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Naam";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(13, 40);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(49, 17);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Datum";
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chParty,
            this.chVotes,
            this.chPercentage,
            this.chSeats});
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(12, 72);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(540, 350);
            this.listView.TabIndex = 2;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // chParty
            // 
            this.chParty.Text = "Partij";
            // 
            // chVotes
            // 
            this.chVotes.Text = "Stemmen";
            this.chVotes.Width = 79;
            // 
            // chPercentage
            // 
            this.chPercentage.Text = "Percentage";
            this.chPercentage.Width = 89;
            // 
            // chSeats
            // 
            this.chSeats.Text = "Zetels";
            // 
            // btnUpdateElection
            // 
            this.btnUpdateElection.Location = new System.Drawing.Point(458, 33);
            this.btnUpdateElection.Name = "btnUpdateElection";
            this.btnUpdateElection.Size = new System.Drawing.Size(94, 31);
            this.btnUpdateElection.TabIndex = 3;
            this.btnUpdateElection.Text = "Wijzigen";
            this.btnUpdateElection.UseVisualStyleBackColor = true;
            // 
            // Election
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(568, 433);
            this.Controls.Add(this.btnUpdateElection);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblName);
            this.Name = "Election";
            this.Text = "Verkiezingsuitslag";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader chParty;
        private System.Windows.Forms.ColumnHeader chVotes;
        private System.Windows.Forms.ColumnHeader chPercentage;
        private System.Windows.Forms.ColumnHeader chSeats;
        private System.Windows.Forms.Button btnUpdateElection;
    }
}