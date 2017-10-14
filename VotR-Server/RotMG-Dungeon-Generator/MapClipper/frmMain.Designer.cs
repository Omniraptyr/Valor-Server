namespace MapClipper {
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
			this.txtHist = new System.Windows.Forms.TextBox();
			this.txtCmd = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
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
			this.box.Click += new System.EventHandler(this.box_Click);
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
			this.panel1.Size = new System.Drawing.Size(560, 305);
			this.panel1.TabIndex = 1;
			// 
			// txtHist
			// 
			this.txtHist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtHist.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtHist.Location = new System.Drawing.Point(12, 323);
			this.txtHist.Multiline = true;
			this.txtHist.Name = "txtHist";
			this.txtHist.ReadOnly = true;
			this.txtHist.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtHist.Size = new System.Drawing.Size(560, 83);
			this.txtHist.TabIndex = 2;
			this.txtHist.TabStop = false;
			// 
			// txtCmd
			// 
			this.txtCmd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCmd.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCmd.Location = new System.Drawing.Point(34, 412);
			this.txtCmd.Name = "txtCmd";
			this.txtCmd.Size = new System.Drawing.Size(538, 23);
			this.txtCmd.TabIndex = 1;
			this.txtCmd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCmd_KeyDown);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 412);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(16, 20);
			this.label1.TabIndex = 4;
			this.label1.Text = ">";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 441);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtCmd);
			this.Controls.Add(this.txtHist);
			this.Controls.Add(this.panel1);
			this.Name = "frmMain";
			this.Text = "RotMG Map Clipper";
			((System.ComponentModel.ISupportInitialize)(this.box)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox box;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox txtHist;
		private System.Windows.Forms.TextBox txtCmd;
		private System.Windows.Forms.Label label1;
	}
}