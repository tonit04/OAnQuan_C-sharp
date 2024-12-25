namespace OAnQuan
{
    partial class frmChonHuongDi
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

        private void InitializeComponent()
        {
            this.btnLeft = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(79, 119);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(126, 36);
            this.btnLeft.TabIndex = 2;
            this.btnLeft.Text = "Trái";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(73, 66);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(331, 32);
            this.lbl1.TabIndex = 1;
            this.lbl1.Text = "Bạn muốn đi hướng nào?";
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(257, 119);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(117, 36);
            this.btnRight.TabIndex = 1;
            this.btnRight.Text = "Phải";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(182, 183);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 50);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmChonHuongDi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 270);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.btnLeft);
            this.Name = "frmChonHuongDi";
            this.Text = "frmChonHuongDi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnCancel;
    

    }
}