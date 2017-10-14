namespace DungeonGenerator {
	partial class frmMain {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.box = new System.Windows.Forms.PictureBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.stepsPane = new System.Windows.Forms.FlowLayoutPanel();
			this.btnNew = new System.Windows.Forms.Button();
			this.btnNewStep = new System.Windows.Forms.Button();
			this.cbBorder = new System.Windows.Forms.CheckBox();
			this.comTemplates = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.box)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// box
			// 
			this.box.Location = new System.Drawing.Point(0, 0);
			this.box.Name = "box";
			this.box.Size = new System.Drawing.Size(10, 10);
			this.box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.box.TabIndex = 0;
			this.box.TabStop = false;
			this.box.DoubleClick += new System.EventHandler(this.box_DoubleClick);
			this.box.MouseClick += new System.Windows.Forms.MouseEventHandler(this.box_MouseClick);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.box);
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(560, 355);
			this.panel1.TabIndex = 1;
			// 
			// stepsPane
			// 
			this.stepsPane.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.stepsPane.Location = new System.Drawing.Point(199, 373);
			this.stepsPane.Name = "stepsPane";
			this.stepsPane.Size = new System.Drawing.Size(373, 56);
			this.stepsPane.TabIndex = 2;
			// 
			// btnNew
			// 
			this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnNew.Location = new System.Drawing.Point(12, 373);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(70, 25);
			this.btnNew.TabIndex = 3;
			this.btnNew.Text = "New";
			this.btnNew.UseVisualStyleBackColor = true;
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// btnNewStep
			// 
			this.btnNewStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnNewStep.Location = new System.Drawing.Point(12, 404);
			this.btnNewStep.Name = "btnNewStep";
			this.btnNewStep.Size = new System.Drawing.Size(70, 25);
			this.btnNewStep.TabIndex = 5;
			this.btnNewStep.Text = "New Step";
			this.btnNewStep.UseVisualStyleBackColor = true;
			this.btnNewStep.Click += new System.EventHandler(this.btnNewStep_Click);
			// 
			// cbBorder
			// 
			this.cbBorder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cbBorder.AutoSize = true;
			this.cbBorder.Location = new System.Drawing.Point(88, 378);
			this.cbBorder.Name = "cbBorder";
			this.cbBorder.Size = new System.Drawing.Size(95, 17);
			this.cbBorder.TabIndex = 6;
			this.cbBorder.Text = "Render Border";
			this.cbBorder.UseVisualStyleBackColor = true;
			this.cbBorder.CheckedChanged += new System.EventHandler(this.cbBorder_CheckedChanged);
			// 
			// comTemplates
			// 
			this.comTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.comTemplates.DisplayMember = "Name";
			this.comTemplates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comTemplates.FormattingEnabled = true;
			this.comTemplates.Location = new System.Drawing.Point(88, 407);
			this.comTemplates.Name = "comTemplates";
			this.comTemplates.Size = new System.Drawing.Size(95, 21);
			this.comTemplates.Sorted = true;
			this.comTemplates.TabIndex = 1;
			this.comTemplates.SelectedIndexChanged += new System.EventHandler(this.comTemplates_SelectedIndexChanged);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 441);
			this.Controls.Add(this.comTemplates);
			this.Controls.Add(this.cbBorder);
			this.Controls.Add(this.btnNewStep);
			this.Controls.Add(this.btnNew);
			this.Controls.Add(this.stepsPane);
			this.Controls.Add(this.panel1);
			this.Name = "frmMain";
			this.Text = "RotMG Dungeon Generator";
			this.Load += new System.EventHandler(this.frmMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.box)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox box;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.FlowLayoutPanel stepsPane;
		private System.Windows.Forms.Button btnNew;
		private System.Windows.Forms.Button btnNewStep;
		private System.Windows.Forms.CheckBox cbBorder;
		private System.Windows.Forms.ComboBox comTemplates;
	}
}