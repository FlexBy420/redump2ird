namespace Redump2IRD {
    partial class MainMenu {
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
            this.bCreateIRD = new System.Windows.Forms.Button();
            this.lD1Dec = new System.Windows.Forms.Label();
            this.lD1Enc = new System.Windows.Forms.Label();
            this.gbD1 = new System.Windows.Forms.GroupBox();
            this.tbD1Enc = new System.Windows.Forms.TextBox();
            this.tbD1Dec = new System.Windows.Forms.TextBox();
            this.gbD2 = new System.Windows.Forms.GroupBox();
            this.tbD2Enc = new System.Windows.Forms.TextBox();
            this.tbD2Dec = new System.Windows.Forms.TextBox();
            this.lD2Dec = new System.Windows.Forms.Label();
            this.lD2Enc = new System.Windows.Forms.Label();
            this.gbPic = new System.Windows.Forms.GroupBox();
            this.tbPic = new System.Windows.Forms.TextBox();
            this.pbCreateIRD = new System.Windows.Forms.ProgressBar();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.gbOutput = new System.Windows.Forms.GroupBox();
            this.cbRedumpMode = new System.Windows.Forms.CheckBox();
            this.bCancel = new System.Windows.Forms.Button();
            this.gbD1.SuspendLayout();
            this.gbD2.SuspendLayout();
            this.gbPic.SuspendLayout();
            this.gbOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // bCreateIRD
            // 
            this.bCreateIRD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCreateIRD.Location = new System.Drawing.Point(303, 537);
            this.bCreateIRD.Name = "bCreateIRD";
            this.bCreateIRD.Size = new System.Drawing.Size(75, 23);
            this.bCreateIRD.TabIndex = 0;
            this.bCreateIRD.Text = "Create IRD";
            this.bCreateIRD.UseVisualStyleBackColor = true;
            this.bCreateIRD.Click += new System.EventHandler(this.bCreateIRD_Click);
            // 
            // lD1Dec
            // 
            this.lD1Dec.AutoSize = true;
            this.lD1Dec.Location = new System.Drawing.Point(5, 22);
            this.lD1Dec.Name = "lD1Dec";
            this.lD1Dec.Size = new System.Drawing.Size(103, 13);
            this.lD1Dec.TabIndex = 1;
            this.lD1Dec.Text = "Decrypted D1 (Key):";
            // 
            // lD1Enc
            // 
            this.lD1Enc.AutoSize = true;
            this.lD1Enc.Location = new System.Drawing.Point(6, 48);
            this.lD1Enc.Name = "lD1Enc";
            this.lD1Enc.Size = new System.Drawing.Size(102, 13);
            this.lD1Enc.TabIndex = 2;
            this.lD1Enc.Text = "Encrypted D1 (Key):";
            // 
            // gbD1
            // 
            this.gbD1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbD1.Controls.Add(this.tbD1Enc);
            this.gbD1.Controls.Add(this.tbD1Dec);
            this.gbD1.Controls.Add(this.lD1Dec);
            this.gbD1.Controls.Add(this.lD1Enc);
            this.gbD1.Location = new System.Drawing.Point(12, 12);
            this.gbD1.Name = "gbD1";
            this.gbD1.Size = new System.Drawing.Size(366, 70);
            this.gbD1.TabIndex = 5;
            this.gbD1.TabStop = false;
            this.gbD1.Text = "D1 - Disc Key (Redump\'s D1 Data is ENCRYPTED)";
            // 
            // tbD1Enc
            // 
            this.tbD1Enc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbD1Enc.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbD1Enc.Location = new System.Drawing.Point(114, 45);
            this.tbD1Enc.Name = "tbD1Enc";
            this.tbD1Enc.Size = new System.Drawing.Size(246, 20);
            this.tbD1Enc.TabIndex = 7;
            this.tbD1Enc.TextChanged += new System.EventHandler(this.tbD1Enc_TextChanged);
            // 
            // tbD1Dec
            // 
            this.tbD1Dec.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbD1Dec.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbD1Dec.Location = new System.Drawing.Point(114, 19);
            this.tbD1Dec.Name = "tbD1Dec";
            this.tbD1Dec.ReadOnly = true;
            this.tbD1Dec.Size = new System.Drawing.Size(246, 20);
            this.tbD1Dec.TabIndex = 5;
            this.tbD1Dec.TextChanged += new System.EventHandler(this.tbD1Dec_TextChanged);
            // 
            // gbD2
            // 
            this.gbD2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbD2.Controls.Add(this.tbD2Enc);
            this.gbD2.Controls.Add(this.tbD2Dec);
            this.gbD2.Controls.Add(this.lD2Dec);
            this.gbD2.Controls.Add(this.lD2Enc);
            this.gbD2.Location = new System.Drawing.Point(12, 88);
            this.gbD2.Name = "gbD2";
            this.gbD2.Size = new System.Drawing.Size(366, 70);
            this.gbD2.TabIndex = 8;
            this.gbD2.TabStop = false;
            this.gbD2.Text = "D2 - Disc ID (Redump\'s D2 Data is DECRYPTED)";
            // 
            // tbD2Enc
            // 
            this.tbD2Enc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbD2Enc.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbD2Enc.Location = new System.Drawing.Point(114, 45);
            this.tbD2Enc.Name = "tbD2Enc";
            this.tbD2Enc.ReadOnly = true;
            this.tbD2Enc.Size = new System.Drawing.Size(246, 20);
            this.tbD2Enc.TabIndex = 7;
            this.tbD2Enc.TextChanged += new System.EventHandler(this.tbD2Enc_TextChanged);
            // 
            // tbD2Dec
            // 
            this.tbD2Dec.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbD2Dec.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbD2Dec.Location = new System.Drawing.Point(114, 19);
            this.tbD2Dec.Name = "tbD2Dec";
            this.tbD2Dec.Size = new System.Drawing.Size(246, 20);
            this.tbD2Dec.TabIndex = 5;
            this.tbD2Dec.TextChanged += new System.EventHandler(this.tbD2Dec_TextChanged);
            // 
            // lD2Dec
            // 
            this.lD2Dec.AutoSize = true;
            this.lD2Dec.Location = new System.Drawing.Point(12, 22);
            this.lD2Dec.Name = "lD2Dec";
            this.lD2Dec.Size = new System.Drawing.Size(96, 13);
            this.lD2Dec.TabIndex = 1;
            this.lD2Dec.Text = "Decrypted D2 (ID):";
            // 
            // lD2Enc
            // 
            this.lD2Enc.AutoSize = true;
            this.lD2Enc.Location = new System.Drawing.Point(13, 48);
            this.lD2Enc.Name = "lD2Enc";
            this.lD2Enc.Size = new System.Drawing.Size(95, 13);
            this.lD2Enc.TabIndex = 2;
            this.lD2Enc.Text = "Encrypted D2 (ID):";
            // 
            // gbPic
            // 
            this.gbPic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPic.Controls.Add(this.tbPic);
            this.gbPic.Location = new System.Drawing.Point(12, 164);
            this.gbPic.Name = "gbPic";
            this.gbPic.Size = new System.Drawing.Size(366, 182);
            this.gbPic.TabIndex = 9;
            this.gbPic.TabStop = false;
            this.gbPic.Text = "Permanent Information && Control (PIC) Data (In Hex)";
            // 
            // tbPic
            // 
            this.tbPic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPic.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPic.Location = new System.Drawing.Point(6, 19);
            this.tbPic.Multiline = true;
            this.tbPic.Name = "tbPic";
            this.tbPic.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbPic.Size = new System.Drawing.Size(354, 157);
            this.tbPic.TabIndex = 0;
            this.tbPic.WordWrap = false;
            // 
            // pbCreateIRD
            // 
            this.pbCreateIRD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCreateIRD.Location = new System.Drawing.Point(12, 508);
            this.pbCreateIRD.Name = "pbCreateIRD";
            this.pbCreateIRD.Size = new System.Drawing.Size(366, 23);
            this.pbCreateIRD.TabIndex = 10;
            // 
            // tbOutput
            // 
            this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOutput.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOutput.Location = new System.Drawing.Point(6, 19);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ReadOnly = true;
            this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbOutput.Size = new System.Drawing.Size(354, 125);
            this.tbOutput.TabIndex = 11;
            this.tbOutput.WordWrap = false;
            // 
            // gbOutput
            // 
            this.gbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOutput.Controls.Add(this.tbOutput);
            this.gbOutput.Location = new System.Drawing.Point(12, 352);
            this.gbOutput.Name = "gbOutput";
            this.gbOutput.Size = new System.Drawing.Size(366, 150);
            this.gbOutput.TabIndex = 12;
            this.gbOutput.TabStop = false;
            this.gbOutput.Text = "IsoTool\'s Output";
            // 
            // cbRedumpMode
            // 
            this.cbRedumpMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbRedumpMode.AutoSize = true;
            this.cbRedumpMode.Checked = true;
            this.cbRedumpMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRedumpMode.Location = new System.Drawing.Point(12, 541);
            this.cbRedumpMode.Name = "cbRedumpMode";
            this.cbRedumpMode.Size = new System.Drawing.Size(96, 17);
            this.cbRedumpMode.TabIndex = 13;
            this.cbRedumpMode.Text = "Redump Mode";
            this.cbRedumpMode.UseVisualStyleBackColor = true;
            this.cbRedumpMode.CheckedChanged += new System.EventHandler(this.cbRedumpMode_CheckedChanged);
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.Enabled = false;
            this.bCancel.Location = new System.Drawing.Point(222, 537);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 14;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 568);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.cbRedumpMode);
            this.Controls.Add(this.gbOutput);
            this.Controls.Add(this.pbCreateIRD);
            this.Controls.Add(this.gbPic);
            this.Controls.Add(this.gbD2);
            this.Controls.Add(this.gbD1);
            this.Controls.Add(this.bCreateIRD);
            this.MinimumSize = new System.Drawing.Size(406, 523);
            this.Name = "MainMenu";
            this.Text = "Redump2IRD";
            this.gbD1.ResumeLayout(false);
            this.gbD1.PerformLayout();
            this.gbD2.ResumeLayout(false);
            this.gbD2.PerformLayout();
            this.gbPic.ResumeLayout(false);
            this.gbPic.PerformLayout();
            this.gbOutput.ResumeLayout(false);
            this.gbOutput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bCreateIRD;
        private System.Windows.Forms.Label lD1Dec;
        private System.Windows.Forms.Label lD1Enc;
        private System.Windows.Forms.GroupBox gbD1;
        private System.Windows.Forms.TextBox tbD1Enc;
        private System.Windows.Forms.TextBox tbD1Dec;
        private System.Windows.Forms.GroupBox gbD2;
        private System.Windows.Forms.TextBox tbD2Enc;
        private System.Windows.Forms.TextBox tbD2Dec;
        private System.Windows.Forms.Label lD2Dec;
        private System.Windows.Forms.Label lD2Enc;
        private System.Windows.Forms.GroupBox gbPic;
        private System.Windows.Forms.TextBox tbPic;
        private System.Windows.Forms.ProgressBar pbCreateIRD;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.GroupBox gbOutput;
        private System.Windows.Forms.CheckBox cbRedumpMode;
        private System.Windows.Forms.Button bCancel;
    }
}

