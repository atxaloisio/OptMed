namespace optmed
{
    partial class frmUtilCamera
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
            this.imgCamera = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCamera = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgCamera)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgCamera
            // 
            this.imgCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgCamera.Location = new System.Drawing.Point(0, 0);
            this.imgCamera.Name = "imgCamera";
            this.imgCamera.Size = new System.Drawing.Size(284, 260);
            this.imgCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgCamera.TabIndex = 0;
            this.imgCamera.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCamera);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 260);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 33);
            this.panel1.TabIndex = 1;
            // 
            // btnCamera
            // 
            this.btnCamera.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnCamera.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCamera.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCamera.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCamera.Image = global::optmed.Properties.Resources.camera1;
            this.btnCamera.Location = new System.Drawing.Point(0, 0);
            this.btnCamera.Name = "btnCamera";
            this.btnCamera.Size = new System.Drawing.Size(284, 32);
            this.btnCamera.TabIndex = 81;
            this.btnCamera.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCamera.UseVisualStyleBackColor = false;
            this.btnCamera.Click += new System.EventHandler(this.btnCamera_Click);
            // 
            // frmUtilCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(284, 293);
            this.Controls.Add(this.imgCamera);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmUtilCamera";
            this.Text = "Camera";
            ((System.ComponentModel.ISupportInitialize)(this.imgCamera)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgCamera;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnCamera;
    }
}
