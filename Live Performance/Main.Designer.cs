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
            this.btnPartyList = new System.Windows.Forms.Button();
            this.btnNewElection = new System.Windows.Forms.Button();
            this.btnCoalitionList = new System.Windows.Forms.Button();
            this.btnElectionList = new System.Windows.Forms.Button();
            this.navPanel = new System.Windows.Forms.Panel();
            this.listPanel = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnExportCoalition = new System.Windows.Forms.Button();
            this.btnNewParty = new System.Windows.Forms.Button();
            this.btnCalcCoalition = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.btnViewParty = new System.Windows.Forms.Button();
            this.navPanel.SuspendLayout();
            this.listPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPartyList
            // 
            this.btnPartyList.BackColor = System.Drawing.Color.Transparent;
            this.btnPartyList.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnPartyList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPartyList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPartyList.Location = new System.Drawing.Point(5, 12);
            this.btnPartyList.Name = "btnPartyList";
            this.btnPartyList.Size = new System.Drawing.Size(113, 48);
            this.btnPartyList.TabIndex = 0;
            this.btnPartyList.Text = "Partijen";
            this.btnPartyList.UseVisualStyleBackColor = false;
            this.btnPartyList.Click += new System.EventHandler(this.btnPartyList_Click);
            // 
            // btnNewElection
            // 
            this.btnNewElection.BackColor = System.Drawing.Color.Transparent;
            this.btnNewElection.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnNewElection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewElection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewElection.Location = new System.Drawing.Point(444, 12);
            this.btnNewElection.Name = "btnNewElection";
            this.btnNewElection.Size = new System.Drawing.Size(277, 48);
            this.btnNewElection.TabIndex = 1;
            this.btnNewElection.Text = "Nieuwe verkiezingsuitslag";
            this.btnNewElection.UseVisualStyleBackColor = false;
            this.btnNewElection.Click += new System.EventHandler(this.btnNewElection_Click);
            // 
            // btnCoalitionList
            // 
            this.btnCoalitionList.BackColor = System.Drawing.Color.Transparent;
            this.btnCoalitionList.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnCoalitionList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCoalitionList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCoalitionList.Location = new System.Drawing.Point(346, 12);
            this.btnCoalitionList.Name = "btnCoalitionList";
            this.btnCoalitionList.Size = new System.Drawing.Size(113, 48);
            this.btnCoalitionList.TabIndex = 2;
            this.btnCoalitionList.Text = "Coalities";
            this.btnCoalitionList.UseVisualStyleBackColor = false;
            this.btnCoalitionList.Click += new System.EventHandler(this.btnCoalitionList_Click);
            // 
            // btnElectionList
            // 
            this.btnElectionList.BackColor = System.Drawing.Color.Transparent;
            this.btnElectionList.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnElectionList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnElectionList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnElectionList.Location = new System.Drawing.Point(130, 12);
            this.btnElectionList.Name = "btnElectionList";
            this.btnElectionList.Size = new System.Drawing.Size(210, 48);
            this.btnElectionList.TabIndex = 3;
            this.btnElectionList.Text = "Verkiezingsuitslagen";
            this.btnElectionList.UseVisualStyleBackColor = false;
            this.btnElectionList.Click += new System.EventHandler(this.btnElectionList_Click);
            // 
            // navPanel
            // 
            this.navPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.navPanel.Controls.Add(this.btnElectionList);
            this.navPanel.Controls.Add(this.btnPartyList);
            this.navPanel.Controls.Add(this.btnNewElection);
            this.navPanel.Controls.Add(this.btnCoalitionList);
            this.navPanel.Location = new System.Drawing.Point(0, 0);
            this.navPanel.Name = "navPanel";
            this.navPanel.Size = new System.Drawing.Size(724, 74);
            this.navPanel.TabIndex = 5;
            // 
            // listPanel
            // 
            this.listPanel.Controls.Add(this.btnViewParty);
            this.listPanel.Controls.Add(this.lblInfo);
            this.listPanel.Controls.Add(this.btnExportCoalition);
            this.listPanel.Controls.Add(this.btnNewParty);
            this.listPanel.Controls.Add(this.btnCalcCoalition);
            this.listPanel.Controls.Add(this.listView);
            this.listPanel.Location = new System.Drawing.Point(0, 80);
            this.listPanel.Name = "listPanel";
            this.listPanel.Size = new System.Drawing.Size(724, 589);
            this.listPanel.TabIndex = 6;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(12, 541);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(375, 17);
            this.lblInfo.TabIndex = 4;
            this.lblInfo.Text = "Dubbelklik op een verkiezingsuitslag voor meer informatie.";
            this.lblInfo.Visible = false;
            // 
            // btnExportCoalition
            // 
            this.btnExportCoalition.Location = new System.Drawing.Point(576, 522);
            this.btnExportCoalition.Name = "btnExportCoalition";
            this.btnExportCoalition.Size = new System.Drawing.Size(127, 55);
            this.btnExportCoalition.TabIndex = 3;
            this.btnExportCoalition.Text = "Exporteren";
            this.btnExportCoalition.UseVisualStyleBackColor = true;
            this.btnExportCoalition.Visible = false;
            // 
            // btnNewParty
            // 
            this.btnNewParty.Location = new System.Drawing.Point(368, 522);
            this.btnNewParty.Name = "btnNewParty";
            this.btnNewParty.Size = new System.Drawing.Size(127, 55);
            this.btnNewParty.TabIndex = 2;
            this.btnNewParty.Text = "Nieuwe partij";
            this.btnNewParty.UseVisualStyleBackColor = true;
            this.btnNewParty.Visible = false;
            // 
            // btnCalcCoalition
            // 
            this.btnCalcCoalition.Location = new System.Drawing.Point(511, 522);
            this.btnCalcCoalition.Name = "btnCalcCoalition";
            this.btnCalcCoalition.Size = new System.Drawing.Size(192, 55);
            this.btnCalcCoalition.TabIndex = 1;
            this.btnCalcCoalition.Text = "Meerderheid berekenen";
            this.btnCalcCoalition.UseVisualStyleBackColor = true;
            this.btnCalcCoalition.Visible = false;
            // 
            // listView
            // 
            this.listView.GridLines = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(12, 18);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(691, 489);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // btnViewParty
            // 
            this.btnViewParty.Location = new System.Drawing.Point(235, 522);
            this.btnViewParty.Name = "btnViewParty";
            this.btnViewParty.Size = new System.Drawing.Size(127, 55);
            this.btnViewParty.TabIndex = 5;
            this.btnViewParty.Text = "Partij bekijken";
            this.btnViewParty.UseVisualStyleBackColor = true;
            this.btnViewParty.Visible = false;
            this.btnViewParty.Click += new System.EventHandler(this.btnViewParty_Click);
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
            this.listPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPartyList;
        private System.Windows.Forms.Button btnNewElection;
        private System.Windows.Forms.Button btnCoalitionList;
        private System.Windows.Forms.Button btnElectionList;
        private System.Windows.Forms.Panel navPanel;
        private System.Windows.Forms.Panel listPanel;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Button btnNewParty;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnExportCoalition;
        private System.Windows.Forms.Button btnCalcCoalition;
        private System.Windows.Forms.Button btnViewParty;
    }
}

