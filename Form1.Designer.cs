namespace SOM
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_drawLines = new System.Windows.Forms.Button();
            this.btn_GenPct = new System.Windows.Forms.Button();
            this.btn_Centri = new System.Windows.Forms.Button();
            this.epoca_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(15, 14);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 738);
            this.panel1.TabIndex = 0;
            // 
            // btn_drawLines
            // 
            this.btn_drawLines.Location = new System.Drawing.Point(857, 14);
            this.btn_drawLines.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_drawLines.Name = "btn_drawLines";
            this.btn_drawLines.Size = new System.Drawing.Size(109, 39);
            this.btn_drawLines.TabIndex = 1;
            this.btn_drawLines.Text = "Draw Lines";
            this.btn_drawLines.UseVisualStyleBackColor = true;
            this.btn_drawLines.Click += new System.EventHandler(this.btn_drawLines_Click_1);
            // 
            // btn_GenPct
            // 
            this.btn_GenPct.Location = new System.Drawing.Point(857, 74);
            this.btn_GenPct.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_GenPct.Name = "btn_GenPct";
            this.btn_GenPct.Size = new System.Drawing.Size(109, 49);
            this.btn_GenPct.TabIndex = 2;
            this.btn_GenPct.Text = "Genereaza Puncte";
            this.btn_GenPct.UseVisualStyleBackColor = true;
            this.btn_GenPct.Click += new System.EventHandler(this.btn_GenPct_Click);
            // 
            // btn_Centri
            // 
            this.btn_Centri.Location = new System.Drawing.Point(857, 140);
            this.btn_Centri.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Centri.Name = "btn_Centri";
            this.btn_Centri.Size = new System.Drawing.Size(109, 49);
            this.btn_Centri.TabIndex = 3;
            this.btn_Centri.Text = "Genereaza Neuroni";
            this.btn_Centri.UseVisualStyleBackColor = true;
            this.btn_Centri.Click += new System.EventHandler(this.btn_Centri_Click);
            // 
            // epoca_label
            // 
            this.epoca_label.AutoSize = true;
            this.epoca_label.Location = new System.Drawing.Point(854, 222);
            this.epoca_label.Name = "epoca_label";
            this.epoca_label.Size = new System.Drawing.Size(68, 17);
            this.epoca_label.TabIndex = 4;
            this.epoca_label.Text = "Epoca : 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 846);
            this.Controls.Add(this.epoca_label);
            this.Controls.Add(this.btn_Centri);
            this.Controls.Add(this.btn_GenPct);
            this.Controls.Add(this.btn_drawLines);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_drawLines;
        private System.Windows.Forms.Button btn_GenPct;
        private System.Windows.Forms.Button btn_Centri;
        private System.Windows.Forms.Label epoca_label;
    }
}

