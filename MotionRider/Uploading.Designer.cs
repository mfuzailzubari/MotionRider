namespace MotionRider
{
    partial class frmUploading
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
            this.progbarUploading = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // progbarUploading
            // 
            this.progbarUploading.Location = new System.Drawing.Point(12, 12);
            this.progbarUploading.Name = "progbarUploading";
            this.progbarUploading.Size = new System.Drawing.Size(360, 23);
            this.progbarUploading.TabIndex = 0;
            this.progbarUploading.UseWaitCursor = true;
            // 
            // frmUploading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 46);
            this.ControlBox = false;
            this.Controls.Add(this.progbarUploading);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUploading";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Please Wait While Uploading The Data";
            this.UseWaitCursor = true;
            this.Shown += new System.EventHandler(this.frmUploading_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progbarUploading;
    }
}