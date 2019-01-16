namespace IMUSE
{
    partial class Form1
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
            this.labelStatusY = new System.Windows.Forms.Label();
            this.xLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelXMin = new System.Windows.Forms.Label();
            this.labelXMax = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.labelYMin = new System.Windows.Forms.Label();
            this.labelYMax = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelZMin = new System.Windows.Forms.Label();
            this.labelZMax = new System.Windows.Forms.Label();
            this.labelZ = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelStatusX = new System.Windows.Forms.Label();
            this.labelStatusZ = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelStatusY
            // 
            this.labelStatusY.AutoSize = true;
            this.labelStatusY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelStatusY.Location = new System.Drawing.Point(142, 121);
            this.labelStatusY.Name = "labelStatusY";
            this.labelStatusY.Size = new System.Drawing.Size(84, 20);
            this.labelStatusY.TabIndex = 0;
            this.labelStatusY.Text = "Calibrant...";
            this.labelStatusY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelStatusY.Click += new System.EventHandler(this.label1_Click);
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(12, 53);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(54, 13);
            this.xLabel.TabIndex = 1;
            this.xLabel.Text = "X mínimo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "X máximo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y mínimo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Z mínimo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Y máximo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Z máximo:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "X actual:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Y actual:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Z actual:";
            // 
            // labelXMin
            // 
            this.labelXMin.AutoSize = true;
            this.labelXMin.Location = new System.Drawing.Point(72, 53);
            this.labelXMin.Name = "labelXMin";
            this.labelXMin.Size = new System.Drawing.Size(19, 13);
            this.labelXMin.TabIndex = 10;
            this.labelXMin.Text = "42";
            // 
            // labelXMax
            // 
            this.labelXMax.AutoSize = true;
            this.labelXMax.Location = new System.Drawing.Point(72, 68);
            this.labelXMax.Name = "labelXMax";
            this.labelXMax.Size = new System.Drawing.Size(19, 13);
            this.labelXMax.TabIndex = 11;
            this.labelXMax.Text = "42";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(72, 83);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(19, 13);
            this.labelX.TabIndex = 12;
            this.labelX.Text = "42";
            // 
            // labelYMin
            // 
            this.labelYMin.AutoSize = true;
            this.labelYMin.Location = new System.Drawing.Point(73, 114);
            this.labelYMin.Name = "labelYMin";
            this.labelYMin.Size = new System.Drawing.Size(19, 13);
            this.labelYMin.TabIndex = 13;
            this.labelYMin.Text = "42";
            // 
            // labelYMax
            // 
            this.labelYMax.AutoSize = true;
            this.labelYMax.Location = new System.Drawing.Point(73, 129);
            this.labelYMax.Name = "labelYMax";
            this.labelYMax.Size = new System.Drawing.Size(19, 13);
            this.labelYMax.TabIndex = 14;
            this.labelYMax.Text = "42";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(74, 144);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(19, 13);
            this.labelY.TabIndex = 15;
            this.labelY.Text = "42";
            // 
            // labelZMin
            // 
            this.labelZMin.AutoSize = true;
            this.labelZMin.Location = new System.Drawing.Point(72, 174);
            this.labelZMin.Name = "labelZMin";
            this.labelZMin.Size = new System.Drawing.Size(19, 13);
            this.labelZMin.TabIndex = 16;
            this.labelZMin.Text = "42";
            // 
            // labelZMax
            // 
            this.labelZMax.AutoSize = true;
            this.labelZMax.Location = new System.Drawing.Point(72, 189);
            this.labelZMax.Name = "labelZMax";
            this.labelZMax.Size = new System.Drawing.Size(19, 13);
            this.labelZMax.TabIndex = 17;
            this.labelZMax.Text = "42";
            // 
            // labelZ
            // 
            this.labelZ.AutoSize = true;
            this.labelZ.Location = new System.Drawing.Point(72, 204);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(19, 13);
            this.labelZ.TabIndex = 18;
            this.labelZ.Text = "42";
            this.labelZ.Click += new System.EventHandler(this.labelZ_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 12);
            this.progressBar1.Maximum = 200;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(243, 23);
            this.progressBar1.TabIndex = 19;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // labelStatusX
            // 
            this.labelStatusX.AutoSize = true;
            this.labelStatusX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelStatusX.Location = new System.Drawing.Point(142, 61);
            this.labelStatusX.Name = "labelStatusX";
            this.labelStatusX.Size = new System.Drawing.Size(84, 20);
            this.labelStatusX.TabIndex = 20;
            this.labelStatusX.Text = "Calibrant...";
            this.labelStatusX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStatusZ
            // 
            this.labelStatusZ.AutoSize = true;
            this.labelStatusZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelStatusZ.Location = new System.Drawing.Point(149, 181);
            this.labelStatusZ.Name = "labelStatusZ";
            this.labelStatusZ.Size = new System.Drawing.Size(82, 20);
            this.labelStatusZ.TabIndex = 21;
            this.labelStatusZ.Text = "No feu clic";
            this.labelStatusZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 252);
            this.Controls.Add(this.labelStatusZ);
            this.Controls.Add(this.labelStatusX);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelZ);
            this.Controls.Add(this.labelZMax);
            this.Controls.Add(this.labelZMin);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelYMax);
            this.Controls.Add(this.labelYMin);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.labelXMax);
            this.Controls.Add(this.labelXMin);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.xLabel);
            this.Controls.Add(this.labelStatusY);
            this.Name = "Form1";
            this.Text = "IMUSE Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStatusY;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelXMin;
        private System.Windows.Forms.Label labelXMax;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelYMin;
        private System.Windows.Forms.Label labelYMax;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelZMin;
        private System.Windows.Forms.Label labelZMax;
        private System.Windows.Forms.Label labelZ;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelStatusX;
        private System.Windows.Forms.Label labelStatusZ;
    }
}

